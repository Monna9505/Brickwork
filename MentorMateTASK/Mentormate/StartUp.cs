using Brickwork.Models;
using System;
using System.Linq;

namespace Brickwork
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            try
            {
                Brickwall matrix = new Brickwall(rowCol[0], rowCol[1]);
                FillMatrix(matrix, rowCol[0], rowCol[1]);
                Console.WriteLine();
                matrix.FinalLayout();
                matrix.PrintMatrix();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FillMatrix(Brickwall matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                int[] currentRow = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
                matrix.CreateMatrix(i, currentRow);
            }
        }
    }
}
