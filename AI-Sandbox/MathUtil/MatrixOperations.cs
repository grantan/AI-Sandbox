using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI_Sandbox.MathUtil
{
    public static class MatrixOperations
    {
        public static float[,] DotProduct(int[,] leftMatrix, float[,] rightMatrix)  //again with the generics
        {
            //mxn dot pxr = size mxr
            int m = leftMatrix.GetLength(0);   //4
            int n = leftMatrix.GetLength(1);   //3
            int p = rightMatrix.GetLength(0);   //3
            int r = rightMatrix.GetLength(1);   //1

            //count of columns of LO must = count of rows of syn0
            //test if (n == p)

            float[,] returnMatrix = new float[m, r];

            //int resultCol = 0;
            for (int returnCol = 0; returnCol < r; returnCol++)
            {
                for (int inputRow = 0; inputRow < m; inputRow++)
                {
                    float val = 0f;

                    for (int inputCol = 0; inputCol < n; inputCol++)
                    {
                        val += leftMatrix[inputRow, inputCol] * rightMatrix[inputCol, returnCol];
                    }

                    returnMatrix[inputRow, returnCol] = val;
                }
            }
            return returnMatrix;
        }

        public static float[,] NormalizeSigmoid(float[,] xL0DotWeights)
        {
            int m = xL0DotWeights.GetLength(0);   //4
            int n = xL0DotWeights.GetLength(1);   //1
            float[,] normalizedWeights = new float[m, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    float val = (float)(1 / (1 + Math.Exp((double)xL0DotWeights[row, col])));

                    normalizedWeights[row, col] = val;
                }
            }
            return normalizedWeights;
        }

        public static float[,] Difference(int[,] trainingOutputY, float[,] normalizedWeightedSum)
        {
            int m = normalizedWeightedSum.GetLength(0);   //4  both matrices should have the same dimension .  Testing?
            int n = normalizedWeightedSum.GetLength(1);   //1
            float[,] difference = new float[m, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    float val = trainingOutputY[row, col] - normalizedWeightedSum[row, col];

                    difference[row, col] = val;
                }
            }
            return difference;
        }

        public static float[,] Sum(float[,] matrix1, float[,] matrix2)
        {
            int m = matrix1.GetLength(0);   //4  both matrices should have the same dimension .  Testing?
            int n = matrix1.GetLength(1);   //1
            float[,] sum = new float[m, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    float val = matrix1[row, col] + matrix2[row, col];

                    sum[row, col] = val;
                }
            }
            return sum;
        }

        public static float[,] SigmoidGradient(float[,] normalizedWeightedSum)
        {
            int m = normalizedWeightedSum.GetLength(0);   //4  both matrices should have the same dimension .  Testing?
            int n = normalizedWeightedSum.GetLength(1);   //1
            float[,] gradient = new float[m, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    float val = normalizedWeightedSum[row, col] * (1 - normalizedWeightedSum[row, col]);

                    gradient[row, col] = val;
                }
            }
            return gradient;
        }

        

        public static float[,] ProductByElement(float[,] matrix1, float[,] matrix2)
        {
            int m = matrix1.GetLength(0);   //4  both matrices should have the same dimension .  Testing?
            int n = matrix1.GetLength(1);   //1
            float[,] product = new float[m, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    float val = matrix1[row, col] * matrix2[row, col];

                    product[row, col] = val;
                }
            }
            return product;
        }

        public static int[,] TransposeInt(int[,] matrix1)
        {
            int m = matrix1.GetLength(0);   //4  both matrices should have the same dimension .  Testing?
            int n = matrix1.GetLength(1);   //1
            int[,] transpose = new int[n, m];  //1X4
            
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < m; row++)
                {
                    transpose[col, row] = matrix1[row, col];
                }
            }

            return transpose;
        }
    }
}