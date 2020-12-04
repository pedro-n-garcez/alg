using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Searching
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
            float startTime, endTime;

            int[] scores = WriteScoresArray();
            int[] scratch = new int[scores.Length];
            MergeSort(scores,scratch,0,scores.Length-1);

            Console.WriteLine("------INPUT LIST:------");
            foreach (int i in scores){Console.Write($"{i} ");}
            Console.WriteLine("\n");

            sw.Start();

            Console.WriteLine("---LINEAR SEARCH---");
            Console.WriteLine("O(n) worst case, O(1) best case");
            Console.WriteLine("Iterates through array one by one, therefore linear.");
            Console.WriteLine("Finds first occurence of input item if it occurs repeatedly.");
            Console.Write("Check for availability of the following item: ");
            int input = Int32.Parse(Console.ReadLine());
            startTime = sw.ElapsedMilliseconds;
            Searches.LinearSearch(input, scores);
            endTime = sw.ElapsedMilliseconds;
            Console.WriteLine("Linear took " + string.Format("{0:0.##}", endTime - startTime) + "ms\n");

            Console.WriteLine("---BINARY SEARCH---");
            Console.WriteLine("O(log n) worst case, O(1) best case");
            Console.WriteLine("Binary only works on sorted lists");
            Console.WriteLine("It finds middle item of array, compares to know which half to look into.");
            Console.WriteLine("May or may not return the first occurence of a repeated element.");
            Console.Write("Check for availability of the following item: ");
            input = Int32.Parse(Console.ReadLine());
            startTime = sw.ElapsedMilliseconds;
            Searches.BinarySearch(input, scores);
            endTime = sw.ElapsedMilliseconds;
            Console.WriteLine("Binary took " + string.Format("{0:0.##}", endTime - startTime) + "ms\n");

            Console.WriteLine("---INTERPOLATION SEARCH---");
            Console.WriteLine("O(n) worst case, O(log(log n)) average case, O(1) best case");
            Console.WriteLine("Interpolation is sort of an 'improved' binary search");
            Console.WriteLine("Only instead of choosing a half, it offers a better estimate of where item might be.");
            Console.WriteLine("We'll estimate a position index that is at or much closer to the input.");
            Console.Write("Check for availability of the following item: ");
            input = Int32.Parse(Console.ReadLine());
            startTime = sw.ElapsedMilliseconds;
            Searches.InterpolationSearch(input, scores);
            endTime = sw.ElapsedMilliseconds;
            Console.WriteLine("Interpolation took " + string.Format("{0:0.##}", endTime - startTime) + "ms\n");

            Console.WriteLine("Linear search is the only search that works on an unordered list.");
            Console.WriteLine("However, it may be slower than the other two if the input list is very large.");
            Console.WriteLine("The size of this list is small enough that linear performs pretty well.\n");

            Console.WriteLine("Binary and interpolation searches are restricted to sorted lists.");
            Console.WriteLine("Interpolation works best on very large data input because of extra computation needed.");
            Console.WriteLine("If elements are not distributed uniformly, interpolation has an O(n) complexity.");
            Console.WriteLine("For our list, binary performs better than interpolation.\n");
            Console.WriteLine("Worth noting that Linear search will always return the first occurence of a repeated element because it searches from start to end, as opposed to binary and interpolation which will estimate the location of the item.");

            Console.ReadKey();
        }

        //MergeSort implementation to sort input array for Binary and Interpolation searches
        static void MergeSort(int[] arr, int[] scratch, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int midpoint = (start + end) / 2;

            MergeSort(arr, scratch, start, midpoint);
            MergeSort(arr, scratch, midpoint + 1, end);

            int leftIndex = start;
            int rightIndex = midpoint + 1;
            int scratchIndex = leftIndex;
            while (leftIndex <= midpoint && rightIndex <= end)
            {
                if (arr[leftIndex] <= arr[rightIndex])
                {
                    scratch[scratchIndex] = arr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    scratch[scratchIndex] = arr[rightIndex];
                    rightIndex++;
                }
                scratchIndex++;
            }

            for (int i = leftIndex; i <= midpoint; i++)
            {
                scratch[scratchIndex] = arr[i];
                scratchIndex++;
            }

            for (int i = rightIndex; i <= end; i++)
            {
                scratch[scratchIndex] = arr[i];
                scratchIndex++;
            }

            for (int i = start; i <= end; i++)
            {
                arr[i] = scratch[i];
            }
        }
    }
}
