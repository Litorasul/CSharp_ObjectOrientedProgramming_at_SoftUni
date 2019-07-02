using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int matrixX = dimestions[0];
            int matrixY = dimestions[1];

            int[,] matrix = new int[matrixX, matrixY];
            FillInMatrix(matrixX, matrixY, matrix);

            long sum = StarsIvoCollected(matrix);

            Console.WriteLine(sum);

        }

        private static long StarsIvoCollected(int[,] matrix)
        {
            long sum = 0;
            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                EvilDestroy(matrix, evil);

                sum = IvoCollect(matrix, sum, ivoS);

                command = Console.ReadLine();
            }

            return sum;
        }

        private static long IvoCollect(int[,] matrix, long sum, int[] ivoS)
        {
            int ivoX = ivoS[0];
            int ivoY = ivoS[1];

            while (ivoX >= 0 && ivoY < matrix.GetLength(1))
            {
                if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
                {
                    sum += matrix[ivoX, ivoY];
                }

                ivoY++;
                ivoX--;
            }

            return sum;
        }

        private static void EvilDestroy(int[,] matrix, int[] evil)
        {
            int evilX = evil[0];
            int evilY = evil[1];

            while (evilX >= 0 && evilY >= 0)
            {
                if (evilX >= 0 && evilX < matrix.GetLength(0) && evilY >= 0 && evilY < matrix.GetLength(1))
                {
                    matrix[evilX, evilY] = 0;
                }
                evilX--;
                evilY--;
            }
        }

        private static void FillInMatrix(int matrixX, int matrixY, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < matrixX; i++)
            {
                for (int j = 0; j < matrixY; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
