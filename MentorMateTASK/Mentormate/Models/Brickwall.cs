using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Brickwork.Models
{
    public class Brickwall
    {
        private int row;
        private int col;
        private int[][] matrix;
        private const string INVALID_BRICK = "-1. No solution exists";

        public Brickwall(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.matrix = new int[row][];
        }
        public int Row 
        {
            get
            {
                return this.row;
            }
            private set
            {
                InvalidRowColException.Validate(value);
                this.row = value;
            }
        }
        public int Col 
        {
            get
            {
                return this.col;
            }
            private set
            {
                InvalidRowColException.Validate(value);
                this.col = value;
            }
        }

        private bool ValidateMatrix()
        {
            for (int row = 0; row <= this.Row-3; row+=3)
            {
                for (int col = 0; col <= this.Col-3; col+=3)
                {
                    if (this.matrix[row][col] == this.matrix[row][col+1] &&
                        this.matrix[row][col+1] == this.matrix[row][col+2])
                    {
                        throw new Exception(INVALID_BRICK);
                    }
                    else if (this.matrix[row][col] == this.matrix[row+1][col] &&
                        this.matrix[row+1][col] == this.matrix[row+2][col])
                    {
                        throw new Exception(INVALID_BRICK);
                    }
                }
            }

            return false;
        }

        public void CreateMatrix(int row, int[] nums)
        {
            this.matrix[row] = nums;
        }

        public int[][] FinalLayout()
        {
            int length = this.matrix.Length-1;

            //Check is matrix has no bricks spanning 3 rows/cols
            ValidateMatrix();

            //Make first and last indexes of the matrix zero.
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    this.matrix[i][0] = 0;
                    this.matrix[length - i][Col - 1] = 0;
                    break;
                }
            }

            //Move last bricks on both sides
            for (int row = 0; row < this.Row-1; row+=2)
            {
                //Make last number first
                int currentNum = this.matrix[row][this.Col - 2];
                this.matrix[row][0] = currentNum;
                this.matrix[row + 1][0] = currentNum;

                //Make last number on last indexes
                int current = this.matrix[row+1][this.Col - 2];
                this.matrix[row][this.Col-1] = current;
                this.matrix[row + 1][this.Col-1] = current;
            }

            //Make the matrix pretty
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 1; j < this.Col-1; j+=2)
                {
                    if (this.matrix[i][j] != this.matrix[i][j+1])
                    {
                        this.matrix[i][j + 1] = this.matrix[i][j];
                    }
                }
            }

            return this.matrix;
        }

        //Print final matrix
        public void PrintMatrix()
        {
            for (int i = 0; i < this.Row; i++)
            {
                Console.WriteLine(string.Join(" ",this.matrix[i]));
            }
        }
    }
}
