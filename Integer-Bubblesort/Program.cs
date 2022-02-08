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

// main

int[] mySortArray = new int[10000];

randomizeArray(ref mySortArray, 0, 9999);       // Erstellt ein zufälliges Array
printArray(mySortArray, "Ausgangs");

Stopwatch sw = new Stopwatch();                 // Stopwatch misst die Zeit, die man braucht
sw.Start();

for (int shell = 0; shell < mySortArray.Length; shell++)            // Rahmen (shell) wird schrittweise von rechts verkleinert
{
    for (int ptr = 1; ptr < (mySortArray.Length - shell); ptr++)    // Jedes Element im Rahmen wird beobachtet
    {
        if (mySortArray[ptr] < mySortArray[ptr - 1])                // Der Größte Wert im aktuellen Rahmen wird ans Ende des Rahmens transprotiert
        {
            int save = mySortArray[ptr - 1];
            mySortArray[ptr - 1] = mySortArray[ptr];
            mySortArray[ptr] = save;
        }
    }
}

sw.Stop();

printArray(mySortArray, "Sortiert");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nReihe wurde sortiert in " + sw.ElapsedMilliseconds.ToString() + " ms\n");
Console.ForegroundColor = ConsoleColor.White;

Console.ReadKey();                              // Wartet, bis Taste gedrückt wird
Environment.Exit(0);