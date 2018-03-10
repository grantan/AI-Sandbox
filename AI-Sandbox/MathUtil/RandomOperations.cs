using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI_Sandbox.MathUtil
{
    public static class RandomOperations
    {
        public static float[,] GetRandomWeights(int seed, int outputs, int columns)
        {
            Random rand = new Random(seed);
            var randomWeights = new float[outputs, columns];  

            // Generate the n random doubles. (0-1)
            for (int i = 0; i < outputs; i++)
            {
                float weight =  2.0f * (float)(rand.NextDouble() - 0.5f);
                randomWeights[i, columns-1] = weight;
            }               

            return randomWeights;

        }
    }
}