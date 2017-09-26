using System;

namespace Demo
{
    /// <summary>
    /// A C# Implementation of https://jeremykun.com/2012/07/25/dynamic-time-warping/
    /// Compare two sequences for similar 'shapes', ignoring specific position.
    /// </summary>
    public class DynamicTimewarp
    {
        public static int Compare(int[] seqA, int[] seqB, Func<int, int, int> costFunc)
        {
            // cost matrix
            var numRows = seqA.Length;
            var numCols = seqB.Length;

            if (numRows < 1 || numCols < 1) return 0;
            if (numRows == 1 && numCols == 1) return costFunc(seqA[0], seqB[0]);

            var cost = new int[numRows, numCols];

            // fill in the first row and column
            cost[0, 0] = costFunc(seqA[0], seqB[0]);
            for (int i = 1; i < numRows; i++)
                cost[i, 0] = cost[i - 1, 0] + costFunc(seqA[i], seqB[0]);

            for (int j = 1; j < numCols; j++)
                cost[0, j] = cost[0,j - 1] + costFunc(seqA[0], seqB[j]);

            // calculate the rest of the matrix
            for (int i = 1; i < numRows; i++)
            {
                for (int j = 1; j < numCols; j++)
                {
                    var minChoice = Math.Min(cost[i-1,j], Math.Min(cost[i, j-1], cost[i-1,j-1]));
                    cost[i, j] = minChoice + costFunc(seqA[i], seqB[j]);
                }
            }

            // Write a diagnostic to the console
            LogArray(cost);

            return cost[numRows - 1, numCols - 1];
        }

        private static void LogArray(int[,] arr)
        {
            Console.WriteLine(new string('-', arr.GetLength(1) * 5));
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    Console.Write((arr[i,j]+"      ").Substring(0,5));
                }
                Console.WriteLine();
            }
        }
    }
}