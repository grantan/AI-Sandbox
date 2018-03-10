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
        public int[,] TrainingOutputYL1 { get; set; }
        public float[,] SynapticWeightsSyn0 { get; set; }

        public SimpleNeuralNetwork()
        {
            //seed the random generator
            // = 2 * random.random((3, 1)) - 1

            //Example: create matrices based on hard-coded values
            const int trainingSetSize = 3;  //columns
            const int inputConnectionsCount = 4;     //start with 3 then infer 4?
            int outputConnectionSize = 1;

            //TrainingInputsXL0 = new int[inputConnectionsCount, trainingSetSize];      
            TrainingOutputYL1 = new int[inputConnectionsCount, outputConnectionSize];  //4 rows, 1 column
            //SynapticWeightsSyn0 = new float[trainingSetSize, outputConnectionSize];   


            //https://msdn.microsoft.com/en-us/library/system.random.nextdouble(v=vs.110).aspx
            int seed = 1;
            //Random fixRand = new Random(seed);


            // Generate the n random doubles. (0-1)
            //for (int j = 0; j < 6; j++)
            //    Console.Write(" {0:F8} ", fixRand.NextDouble());
            //Console.WriteLine();

            //float[,] randomWeights = new float[3,1] { { -0.75f }, { .5f }, { .25f } };  //mean of 0?  How do you get that randomly?

            //4 rows, 3 columns
            TrainingInputsXL0 = new int[inputConnectionsCount, trainingSetSize] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 }, { 0, 0, 1 } };

            //3 rows, 1 column
            SynapticWeightsSyn0 = RandomOperations.GetRandomWeights(seed, trainingSetSize, outputConnectionSize);

            //Apply dot product between X (test inputs) and syn0 (weights).
            // 4x3 matrix dot 3x1 matrix = 4x1 matrix

            //float[,] L0_dot_syn0 = MatrixOperations.DotProduct(TrainingInputsXL0, SynapticWeightsSyn0);


 


        }

        public SimpleNeuralNetwork(int[,] inputConnections, int[,] outputConnections, int trainingSetSize)
        {
            //Seed the random# generator, then randomly assign values to the weights. Random numbers should have a mean of 0
            //syn0 = 2 * np.random.random((3, 1)) - 1
            //From https://docs.scipy.org/doc/numpy/reference/generated/numpy.random.random.html#numpy.random.random
            //Results are from the “continuous uniform” distribution over the stated interval.To sample Unif[a, b), b > a multiply the output of random_sample by(b-a) and add a:
            //(b - a) * random_sample() + a.
            //So, 2 * np.random.random((3, 1)) - 1   MEANS THAT a = -1, and b = 1.
            




        }
    }
}