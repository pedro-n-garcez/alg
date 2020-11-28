using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Sorting
{
    class Program
    {
        //read text file of scores into an int array
        static int[] WriteScoresArray()
        {
            string[] textInput = File.ReadAllLines("scores.txt");
            int[] scores = new int[textInput.Length];
            for (int i = 0; i < textInput.Length; i++)
            {
                scores[i] = Int32.Parse(textInput[i]);
            }
            return scores;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            float startTime, endTime, deltaTime;

            //BUBBLESORT
            int[] scores = WriteScoresArray();
            Console.WriteLine("----Bubble Sort----");
            Console.WriteLine("----Best case: O(n), worst case: O(n^2)----");
            Console.WriteLine("Compares a number with the next one to see if the adjacents are out of order. If current is greater than the next, swapif that is no longer the case, it is sorted.");
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.BubbleSort(scores);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.WriteLine("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nBubble took " + string.Format("{0:0.##}",deltaTime) + "ms" + "\n");
            float msBubble = deltaTime;

            //INSERTIONSORT
            scores = WriteScoresArray();
            Console.WriteLine("----Insertion Sort----");
            Console.WriteLine("----Best case: O(n), worst case: O(n^2)----");
            Console.WriteLine("Compares every number with all before it. If the previous is greater than the current one, we swap. This way we'll bring every number to their correct, sorted location.");
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.InsertionSort(scores);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.WriteLine("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nInsertion took " + string.Format("{0:0.##}", deltaTime) + "ms" + "\n");
            float msInsertion = deltaTime;

            //SELECTIONSORT
            scores = WriteScoresArray();
            Console.WriteLine("----Selection Sort----");
            Console.WriteLine("----Best case: O(n^2), worst case: O(n^2)----");
            Console.WriteLine("Iterates through the array, looking for the smallest number. Every time it finds a number smaller than the current, that number becomes the smallest. At the end we swap the smallest with the current");
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.SelectionSort(scores);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.WriteLine("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nSelection took " + string.Format("{0:0.##}", deltaTime) + "ms" + "\n");
            float msSelection = deltaTime;

            //HEAPSORT
            scores = WriteScoresArray();
            Console.WriteLine("----Heap Sort----");
            Console.WriteLine("----Best case: O(n log n), worst case: O(n log n)----");
            Console.WriteLine("Turns input into a heap data structure, then removes the top item and reorders heap to satisfy its property (parent's two children must be less than or equal to parent) Thus working in a reverse way, the array will be in sorted order.");
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.HeapSort(scores);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.WriteLine("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nHeap took " + string.Format("{0:0.##}", deltaTime) + "ms" + "\n");
            float msHeap = deltaTime;

            //QUICKSORT
            scores = WriteScoresArray();
            Console.WriteLine("----Quick Sort----");
            Console.WriteLine("----Best case: O(n), worst case: O(n log n)----");
            Console.WriteLine("Picks a pivot item that divides array into left and right. Items smaller than the pivot go left, items greater go right. Recursive calls subdivide the array further, sorting the smaller divisions until it's all sorted. This is a three-way partition implementation that accounts for repeated elements, so only the less-than and greater-than partitions need to be recursively sorted.");
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.QuickSort(scores, 0, scores.Length - 1);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.WriteLine("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nQuick took " + string.Format("{0:0.##}", deltaTime) + "ms" + "\n");
            float msQuick = deltaTime;

            //MERGESORT
            scores = WriteScoresArray();
            Console.WriteLine("----Merge Sort----");
            Console.WriteLine("----Best case: O(n log n), worst case: O(n log n)----");
            Console.WriteLine("Splits array in two, then calls itself to do so again until it can't be divided further. These subdivisions are then merged into sorted groups of two, then four, and so on. The division is always at the middle.");
            int[] scratch = new int[scores.Length];
            Console.Write("\nUNSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            startTime = sw.ElapsedMilliseconds;
            Sorts.MergeSort(scores, scratch, 0, scores.Length - 1);
            endTime = sw.ElapsedMilliseconds;
            deltaTime = endTime - startTime;
            Console.Write("\nSORTED: ");
            foreach (int i in scores) { Console.Write($"{i} "); }
            Console.WriteLine("\nMerge took " + string.Format("{0:0.##}", deltaTime) + "ms" + "\n");
            float msMerge = deltaTime;

            Console.WriteLine("ALGORITHM\tSTRATEGY\tAV. TIME COMPLEXITY\t\tMILLISECONDS TAKEN\tHOW GOOD IS IT");
            Console.WriteLine($"BubbleSort\tComparison\tO(n^2)\t\t\t\t{msBubble}\t\t\tGood for smaller lists, too slow for large lists");
            Console.WriteLine($"InsertionSort\tInsertion\tO(n^2)\t\t\t\t{msInsertion}\t\t\tGood for smaller lists, generally best-performant of O(n^2) sorts");
            Console.WriteLine($"SelectionSort\tComparison\tO(n^2)\t\t\t\t{msSelection}\t\t\tGood for smaller lists, slow for larger lists");
            Console.WriteLine($"HeapSort\tComparison\tO(n log n)\t\t\t{msHeap}\t\t\tSimilar to Selection but faster on large lists");
            Console.WriteLine($"QuickSort\tDivide&conquer\tO(n log n)\t\t\t{msQuick}\t\t\tUsually the fastest of n log n sorts");
            Console.WriteLine($"MergeSort\tDivide&conquer\tO(n log n)\t\t\t{msMerge}\t\t\tGood for large lists");

            Console.ReadKey();
        }
    }
}
