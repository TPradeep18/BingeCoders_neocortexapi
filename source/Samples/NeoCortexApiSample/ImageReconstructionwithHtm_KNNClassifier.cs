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

        }
    }
    }