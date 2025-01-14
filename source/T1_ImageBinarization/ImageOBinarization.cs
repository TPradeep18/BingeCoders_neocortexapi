

using Daenet.Binarizer.Entities;
using Daenet.Binarizer;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Provides methods to binarize images.
/// </summary>
public class ImgBinarize
{
    /// <summary>
    /// Binarizes images in a folder and saves the binarized image data to text files.
    /// </summary>
    /// <param name="folderPath">The path to the folder containing images to binarize.</param>

    public static int[] ConvertImagesToBinaryForm(string folderPath)
    {
        // Dictionary to hold image paths and their binary data.
        Dictionary<string, int[]> binarizedImages = new Dictionary<string, int[]>();

        // Output folder path.
        string outputFolder = Path.GetFullPath("output");
        Directory.CreateDirectory(outputFolder);

        // Iterate through all images in the folder.
        foreach (var imagePath in Directory.GetFiles(folderPath, ".", SearchOption.AllDirectories)
                        .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)))
        {
            // Define binarization parameters for each image.
            var parameters = new BinarizerParams
            {
                InputImagePath = imagePath,
                ImageHeight = 32,
                ImageWidth = 32,
            };


            ImageBinarizer IB = new ImageBinarizer(parameters);
            var doubleArray = IB.GetArrayBinary();

            int height = doubleArray.GetLength(1);
            int width = doubleArray.GetLength(0);
            int[] intArray = new int[height * width];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    intArray[j * width + i] = (int)doubleArray[i, j, 0];
                }
            }

            // Add the result to the dictionary.
            binarizedImages[imagePath] = intArray;

            // Save the binary data to a text file with 32 values per line.
            string outputFilePath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(imagePath) + "_binarized.txt");
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < intArray.Length; i += 32)
                {
                    // Write 32 values on one line.
                    var line = string.Join(" ", intArray.Skip(i).Take(32));
                    writer.WriteLine(line);
                }
            }
        }

        // Combine all binary data into a single array.
        var combinedBinaryData = binarizedImages.Values.SelectMany(x => x).ToArray();

        // Return the combined binary data as a single 1D array.
        return combinedBinaryData;
    }
}
