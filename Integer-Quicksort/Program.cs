using System;
using System.Diagnostics;

/// <summary>
/// Gibt den Inhalt des Arrays in der Konsole aus
/// </summary>
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

/// <summary>
/// Erstellt ein Zufälliges Array, sodass es später sortiert werden kann
/// </summary>
void randomizeArray(ref int[] givenArray, int min, int max)
{
    Random rnd = new Random();

    for (int i = 0; i < givenArray.Length; i++)
    {
        givenArray[i] = rnd.Next(min, max);
    }
}

/// <summary>
/// The Main Quicksort Program
/// </summary>
void quicksort(int[] givenArray, int start, int end)
{
    if (start > end || start < 0 || end < 0) return;

    int keyvalue = partsort(givenArray, start, end);

    if (keyvalue == -1) return;

    quicksort(givenArray, start, keyvalue - 1);
    quicksort(givenArray, keyvalue + 1, end);
}

/// <summary>
/// Sorts a part of the array and returns the key index
/// </summary>
int partsort(int[] givenArray, int left, int right) 
{
    if (left > right) return -1;

    int end = left;
    int anchor = givenArray[right];

    for (int i = left; i < right; i++)
    {
        if (givenArray[i] < anchor)
        {
            swap(givenArray, i, end);
            end++;
        }
    }

    swap(givenArray, end, right);

    return end;
}

/// <summary>
/// Vertauscht zwei Werte innerhalb eines Arrays
/// </summary>
void swap(int[] array, int left, int right)
{
    int tmp = array[left];
    array[left] = array[right];
    array[right] = tmp;
}

// Main

int[] mySortArray = new int[314];

randomizeArray(ref mySortArray, 0, 9999);       // Erstellt ein zufälliges Array
printArray(mySortArray, "Ausgangs");

Stopwatch sw = new Stopwatch();                 // Stopwatch misst die Zeit, die man braucht
sw.Start();

quicksort(mySortArray, 0, mySortArray.Length - 1);

sw.Stop();

printArray(mySortArray, "Sortiert");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nReihe wurde sortiert in " + sw.ElapsedMilliseconds.ToString() + " ms\n");
Console.ForegroundColor = ConsoleColor.White;

Console.ReadKey();                              // Wartet, bis Taste gedrückt wird
Environment.Exit(0);