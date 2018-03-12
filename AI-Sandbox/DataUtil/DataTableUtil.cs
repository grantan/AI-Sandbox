using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AI_Sandbox.DataUtil
{
    public static class DataTableUtil
    {
        public static DataTable ArrayToDataTableFloat(float[,] fArray, string columnHeaderPrefix)   //Generics would be good
        {
            DataTable dt = new DataTable();
            int rowCount = fArray.GetLength(0);
            int colCount = fArray.GetLength(1);

            // table schema
            // DataColumn you can use constructor DataColumn(name,type);
            for (int cols = 0; cols < colCount; cols++)
            {
                DataColumn dc = new DataColumn(columnHeaderPrefix + cols );
                dt.Columns.Add(dc);

            }     

            for (int i = 0; i < rowCount ; i++)    //first dimension size of array (rows, in our 2D array)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < colCount;  j++)   //second dimension size of array (cols)
                {                    
                    dr[j] = fArray[i, j];                       
                }

                dt.Rows.Add(dr);   //why?  if it's create from dt.NewRow() ???
            }            

            return dt;
        }

        public static object ArrayToDataTableInt(int[,] iArray, string columnHeaderPrefix)
        {
            DataTable dt = new DataTable();
            int rowCount = iArray.GetLength(0);
            int colCount = iArray.GetLength(1);

            // table schema
            // DataColumn you can use constructor DataColumn(name,type);
            for (int cols = 0; cols < colCount; cols++)
            {
                DataColumn dc = new DataColumn( columnHeaderPrefix + cols);
                dt.Columns.Add(dc);

            }

            for (int i = 0; i < rowCount; i++)    //first dimension size of array (rows, in our 2D array)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < colCount; j++)   //second dimension size of array (cols)
                {
                    dr[j] = iArray[i, j];
                }

                dt.Rows.Add(dr);  //why?  if it's create from dt.NewRow() ???
            }

            return dt;
        }
    }
}