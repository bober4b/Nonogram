using System;

class Program
{
    static void Main()
    {
        // Przykładowa dwuwymiarowa tablica znaków
        char[,] originalArray = {
            {'A', 'B', 'C'},
            {'D', 'E', 'F'},
            {'G', 'H', 'I'}
        };

        // Wyświetlanie oryginalnej tablicy
        Console.WriteLine("Oryginalna tablica:");
        PrintArray(originalArray);

        // Transponowanie tablicy
        char[,] transposedArray = TransposeArray(originalArray);

        // Wyświetlanie ztransponowanej tablicy
        Console.WriteLine("\nZtransponowana tablica:");
        PrintArray(transposedArray);
    }

    static char[,] TransposeArray(char[,] originalArray)
    {
        int rows = originalArray.GetLength(0);
        int columns = originalArray.GetLength(1);

        char[,] transposedArray = new char[columns, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                transposedArray[j, i] = originalArray[i, j];
            }
        }

        return transposedArray;
    }

    static void PrintArray(char[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
