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
    }
}