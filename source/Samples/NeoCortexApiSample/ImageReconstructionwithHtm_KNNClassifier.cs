using NeoCortex;
using NeoCortexApi.Entities;
using NeoCortexApi.Utility;
using NeoCortexApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoCortexApi.Classifiers;

namespace NeoCortexApiSample
{
    internal class ImageReconstructionwithHtm_KNNClassifier
    {

        /// <summary>
        /// Implements an experiment that demonstrates how to learn spatial patterns.
        /// SP will learn every presented Image input in multiple iterations.
        /// </summary>

        //Implementing the HTM & KNN Classifier

        public void Run()
        {
            Console.WriteLine($"Hello NeocortexApi! Experiment {nameof(ImageReconstructionwithHtm_KNNClassifier)}");

            Console.WriteLine($"Hello NeocortexApi! Experiment {nameof(ImageReconstructionwithHtm_KNNClassifier)}");

            double minOctOverlapCycles = 1.0;
            double maxBoost = 5.0;
            // We will build a slice of the cortex with the given number of mini-columns
            int numColumns = 64 * 64;


            // The Size of the Image Height and width is 32 pixel

            int imageSize = 32;
            var colDims = new int[] { 64, 64 }; 

            // This is a set of configuration parameters used in the experiment.
            HtmConfig cfg = new HtmConfig(new int[] { imageSize, imageSize }, new int[] { numColumns })
            {
                CellsPerColumn = 10,
                InputDimensions = new int[] { imageSize, imageSize },
                NumInputs = imageSize * imageSize,
                ColumnDimensions = colDims,
                MaxBoost = maxBoost,
                DutyCyclePeriod = 100,
                MinPctOverlapDutyCycles = minOctOverlapCycles,
                GlobalInhibition = false,
                NumActiveColumnsPerInhArea = 0.02 * numColumns,
                PotentialRadius = (int)(0.15 * imageSize * imageSize),
                LocalAreaDensity = -1,
                ActivationThreshold = 10,
                MaxSynapsesPerSegment = (int)(0.01 * numColumns),
                Random = new ThreadSafeRandom(42),
                StimulusThreshold = 10,
            }; 
        }
    }
}