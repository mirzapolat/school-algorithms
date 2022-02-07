using System;
using System.Diagnostics;

int[] mySortArray = new int[15];

randomizeArray(ref mySortArray, 0, 9999);
printArray(mySortArray, "Ausgangs");

Stopwatch sw = new Stopwatch();
sw.Start();
doBubblesort(ref mySortArray);
sw.Stop();

printArray(mySortArray, "Sortiert");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nReihe wurde sortiert in " + sw.ElapsedMilliseconds.ToString() + " ms\n");
Console.ForegroundColor = ConsoleColor.White;

Console.ReadKey();
Environment.Exit(0);

void printArray(int[] arr, string reason)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\n[" + reason + "] ");
    Console.Write(">> ");
    Console.ForegroundColor = ConsoleColor.White;

    foreach (int i in arr)
    {
        Console.Write(i.ToString());
        for (int e = 0; e < (4 - i.ToString().Length); e++) Console.Write(" ");
        Console.Write(" | ");
    }
}

void randomizeArray(ref int[] givenArray, int min, int max)
{
    Random rnd = new Random();

    for (int i = 0; i < givenArray.Length; i++)
    {
        givenArray[i] = rnd.Next(min, max);
    }
}

void doBubblesort(ref int[] givenArray)
{
    for (int shell = 0; shell < givenArray.Length; shell++)
    {
        for (int ptr = 1; ptr < (givenArray.Length - shell); ptr++)
        {
            if (givenArray[ptr] < givenArray[ptr - 1])
            {
                int save = givenArray[ptr - 1];
                givenArray[ptr - 1] = givenArray[ptr];
                givenArray[ptr] = save;
            }
        }
    }
}