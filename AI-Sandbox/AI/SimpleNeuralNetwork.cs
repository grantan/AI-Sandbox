using AI_Sandbox.MathUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI_Sandbox.AI
{
    public class SimpleNeuralNetwork
    {
        // We model a single neuron, with 3 input connections and 1 output connection.
        // We assign random weights to a 3 x 1 matrix, with values in the range -1 to 1
        // and mean 0.
        
        public int[,] TrainingInputsXL0 { get; set; }

        //desired result from inputs
        public int[,] TrainingOutputY { get; set; }

        //calculated result of training inputs
        public int[,] TrainingOutputYL1 { get; set; }

        public float[,] SynapticWeightsInitial { get; set; }

        public float[,] SynapticWeightsSyn0 { get; set; }

        public float[,] XL0DotWeights { get; set; }  
        
        public float[,] NormalizedWeightedSum { get; set; }

        public float[,] Error { get; set; }

        public float[,] ErrorDelta { get; set; }

        public float[,] SigmoidGradient { get; set; }

        public float[,] Adjustment { get; set; }

        public SimpleNeuralNetwork()
        {
            
        }

        public SimpleNeuralNetwork(int[,] inputsXL0, int[,] outputY)
        {

            TrainingInputsXL0 = inputsXL0;  //4X3
            int trainingSetRows = TrainingInputsXL0.GetLength(0);  //4
            int trainingSetColumns = TrainingInputsXL0.GetLength(1);  //3

            TrainingOutputY = outputY;  //4X1
            int outputConnectionRows = TrainingOutputY.GetLength(0);  //4
            int outputConnectionColumns = TrainingOutputY.GetLength(1);  //1

            NormalizedWeightedSum = new float[trainingSetRows, outputConnectionColumns];
            Error = new float[trainingSetRows, outputConnectionColumns];
            ErrorDelta = new float[trainingSetRows, outputConnectionColumns];
            SigmoidGradient = new float[trainingSetRows, outputConnectionColumns];

            int trainingReps = 10;

            //https://msdn.microsoft.com/en-us/library/system.random.nextdouble(v=vs.110).aspx
            int seed = 1;
            //Random fixRand = new Random(seed);

            //3 rows, 1 column
            SynapticWeightsInitial = RandomOperations.GetRandomWeights(seed, trainingSetColumns, outputConnectionColumns);
            SynapticWeightsSyn0 = SynapticWeightsInitial;

            for (int reps = 0; reps < trainingReps; reps++)
            {
                XL0DotWeights = MatrixOperations.DotProduct(TrainingInputsXL0, SynapticWeightsSyn0);
                NormalizedWeightedSum = MatrixOperations.NormalizeSigmoid(XL0DotWeights);

                Error = MatrixOperations.Difference(TrainingOutputY, NormalizedWeightedSum);
                SigmoidGradient = MatrixOperations.SigmoidGradient(NormalizedWeightedSum);
                ErrorDelta = MatrixOperations.ProductByElement(Error, SigmoidGradient);

                int[,] L0Transpose = MatrixOperations.TransposeInt(TrainingInputsXL0);   //generics

                Adjustment = MatrixOperations.DotProduct(L0Transpose, ErrorDelta);

                SynapticWeightsSyn0 = MatrixOperations.Sum(SynapticWeightsSyn0, Adjustment);
            }

            

            //Seed the random# generator, then randomly assign values to the weights. Random numbers should have a mean of 0
            //syn0 = 2 * np.random.random((3, 1)) - 1
            //From https://docs.scipy.org/doc/numpy/reference/generated/numpy.random.random.html#numpy.random.random
            //Results are from the “continuous uniform” distribution over the stated interval.To sample Unif[a, b), b > a multiply the output of random_sample by(b-a) and add a:
            //(b - a) * random_sample() + a.
            //So, 2 * np.random.random((3, 1)) - 1   MEANS THAT a = -1, and b = 1.

        }


    }
}