using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3_TogzhanTolegen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Decalring variables
            int[,] tempArray;
            int rows, columns;
            bool quit = false;

            do
            {
                //Calling ArrayData method with return two - dimension array
                tempArray = ArrayData(out rows, out columns);

                //Writing message for print array data
                Console.WriteLine("The Original Two Dimension Array Data:");
                DisplayArray(tempArray, rows, columns);

                Console.WriteLine("\nEnter any key to continue:");  
                Console.ReadKey();  //Pausing the program           

                //swapRow method
                SwapRow(tempArray);
                Console.WriteLine("\nSwap Row method output: ");
                DisplayArray(tempArray, rows, columns);

                Console.WriteLine("\nEnter any key to continue:");
                Console.ReadKey();

                //swapColumn method
                SwapColumn(tempArray);
                Console.WriteLine("\nSwap Column method output: ");
                DisplayArray(tempArray, rows, columns);

                Console.WriteLine("\nEnter any key to continue:");
                Console.ReadKey();

                //RotateLeftDiagonal method
                RotateLeftDiagonal(tempArray);
                Console.WriteLine("\nRotateLeftDiagonal method output: ");
                DisplayArray(tempArray, rows, columns);

                Console.WriteLine("\nEnter any key to continue:");
                Console.ReadKey();

                //RotateRightDiagonal method
                RotateRightDiagonal(tempArray);
                Console.WriteLine("\nRotateRightDiagonal method output: ");
                DisplayArray(tempArray, rows, columns);

                // Ask the user if they want to quit or continue
                Console.Write("Do you want to quit? (y/n): ");
                string input = Console.ReadLine().ToLower();
                quit = (input == "y" || input == "yes");

            } while (!quit);
        }

        //Calling ArrayData method with return two-dimension array
        public static int[,] ArrayData(out int rows, out int columns)
        {
            //Promting the user's input
            Console.WriteLine("Enter the number of rows for the 2D array: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of columns for the 2D array: ");
            columns = Convert.ToInt32(Console.ReadLine());

            //Allocating a new 2D array to the specified size
            int[,] matrix = new int[rows, columns];
            Random randNum = new Random();

            //Generating unique random number code 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = randNum.Next(1, 101);
                }
            }

            return matrix;
        }

        public static void DisplayArray(int[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }




        //SwapRow method
        public static void SwapRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[rows - 1 - i, j];
                    matrix[rows - i - 1, j] = temp;
                }
            }

        }




        //SwapColumn method
        public static void SwapColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - j - 1];
                    matrix[i, cols - j - 1] = temp;
                }
            }
        }




        //RotateLeftDiagonal method
        public static void RotateLeftDiagonal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                Console.WriteLine("Matrix is not square");
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < cols; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            // Swap the number of rows and columns
            int tempSize = rows;
            rows = cols;
            cols = tempSize;
        }



        //RotateRightDiagonal
        public static void RotateRightDiagonal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                Console.WriteLine("Matrix is not square");
                return;
            }

            // Exchange elements along the right diagonal
            for (int i = 0; i < rows / 2; i++)
            {
                int j = cols - i - 1;
                int temp = matrix[i, i];
                matrix[i, i] = matrix[j, j];
                matrix[j, j] = temp;
            }

            // Swap the number of rows and columns
            int tempSize = rows;
            rows = cols;
            cols = tempSize;
        }


    }
}
