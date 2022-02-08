﻿using System;
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
/// Vertauscht zwei Werte innerhalb eines Arrays
/// </summary>
void swap(int[] array, int left, int right)
{
    int tmp = array[left];
    array[left] = array[right];
    array[right] = tmp;
}

/// <summary>
/// Sortiert Werte innerhalb des Arrays nach Größe nach dem Selectionsort-Verfahren
/// </summary>
void selectionsort(int[] givenArray)
{
    int maxindex = givenArray.Length - 1;
    for (int border = 0; border < givenArray.Length / 2; border++)              // Verkleinert den Rahmen der Beobachtung schrittweise von beiden Seiten
    {
        for (int i = 0; i < givenArray.Length - (border * 2); i++)              // Geht jedes Element im ausgewählten Rahmen durch
        {
            if (i != 0)
            {
                if (givenArray[border + i] < givenArray[border])            
                    swap(givenArray, border + i, border);                       // Prüft, ob das aktuelle Element das kleinste ist
                if (givenArray[border + i] > givenArray[maxindex - border]) 
                    swap(givenArray, border + i, maxindex - border);            // Prüft, ob das aktuelle Element das größte ist
            }
        }
    }
}

// Main

int[] mySortArray = new int[10000];

randomizeArray(ref mySortArray, 0, 9999);       // Erstellt ein zufälliges Array
printArray(mySortArray, "Ausgangs");

Stopwatch sw = new Stopwatch();                 // Stopwatch misst die Zeit, die man braucht
sw.Start();

selectionsort(mySortArray);                     // Sortiert Array nach dem Selectionsort Prinzip

sw.Stop();

printArray(mySortArray, "Sortiert");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\nReihe wurde sortiert in " + sw.ElapsedMilliseconds.ToString() + " ms\n");
Console.ForegroundColor = ConsoleColor.White;

Console.ReadKey();                              // Wartet, bis Taste gedrückt wird
Environment.Exit(0);