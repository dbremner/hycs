using System;

class DeclareArraysSample
{
    public static void Main()
    {
        // Single-dimensional array
        int[] numbers = new int[5];

        // Multidimensional array
        string[,] names = new string[5,4];

        // Array-of-arrays (jagged array)
        byte[][] scores = new byte[5][];

        // Create the jagged array
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = new byte[i+3];
        }

        // Print length of each row
        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine("Length of row {0} is {1}", i, scores[i].Length);
        }
        
        int[,] score = new int[3, 5];
        score = new int[,] { { 97, 87, 92, 78, 83 }, { 92, 81, 90, 86, 74 }, { 70, 65, 80, 91, 76 } };

        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
}
