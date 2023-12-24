using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vis9
{

    
    class MSearch
    {
        private int[][] mat;
        private int maxSum;
        private int RowIndex;

        public MSearch(int[][] matrix)
        {
            this.mat = matrix;
            maxSum = 0;
            RowIndex = -1;
        }

        public void FindMaxSumMatrix()
        {
            Thread[] threads = new Thread[mat.Length];

            for (int i = 0; i < mat.Length; i++)
            {
                int row = i;
                threads[i] = new Thread(() => FindMaxSumInRow(row));
                threads[i].Start();
            }

            for (int i = 0; i < mat.Length; i++)
            {
                threads[i].Join();
            }
        }

        private void FindMaxSumInRow(int rowIndex)
        {
            int[] row = mat[rowIndex];
            int sum = 0;

            for (int i = 0; i < row.Length; i++)
            {
                sum += row[i];
            if (sum > maxSum)
            {
                lock (this)
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        RowIndex = rowIndex;
                    }
                }
            }
        }
        }

        public int GetMaxSum()
        {
            return maxSum;
        }
        public int GetMaxSumRowIndex()
        {
            return RowIndex;
        }
    }
}
