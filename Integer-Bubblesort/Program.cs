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
/// Sortiert ein Array nach dem Bubblesort-Verfahren
/// </summary>
void bubblesort(int[] givenArray)
{
    for (int shell = 0; shell < givenArray.Length; shell++)            // Rahmen (shell) wird schrittweise von rechts verkleinert
    {
        for (int ptr = 1; ptr < (givenArray.Length - shell); ptr++)    // Jedes Element im Rahmen wird beobachtet
        {
            if (givenArray[ptr] < givenArray[ptr - 1])                // Der Größte Wert im aktuellen Rahmen wird ans Ende des Rahmens transprotiert
            {
                int save = givenArray[ptr - 1];
                givenArray[ptr - 1] = givenArray[ptr];
                givenArray[ptr] = save;
            }
        }
    }
}

// Main

int l = 100;                                    // Länge des Arrays

int[] mySortArray = new int[l];
randomizeArray(ref mySortArray, 0, 9999);       // Erstellt ein zufälliges Array

int[] beforeArray = new int[l];
for (int i = 0; i < mySortArray.Length; i++)
    beforeArray[i] = mySortArray[i];

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("## Bubblesort");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("Sortieren gestartet. Es werden ");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write(l.ToString());
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" Elemente sortiert...\n");

Stopwatch sw = new Stopwatch();                 // Stopwatch misst die Zeit, die man braucht
sw.Start();
bubblesort(mySortArray);
sw.Stop();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Reihe wurde sortiert in " + sw.ElapsedMilliseconds.ToString() + " ms");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Werte anzeigen? (y/n) >> ");
Console.ForegroundColor = ConsoleColor.White;

if (Console.ReadLine() == "y")
{
    printArray(beforeArray, "Ausgang");
    printArray(mySortArray, "Sortiert");
}



Console.ReadKey();                              // Wartet, bis Taste gedrückt wird
Environment.Exit(0);