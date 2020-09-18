using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigO
{
    class Program
    {
        //O(1) runtime.
        //The method accesses the first and last indexes of the array only, 
        //so the size of the input does not matter,
        //therefore it is constant.
        static void arrayInfo(int[] arr)
        {
            Console.WriteLine($"The first number in your array is {arr[0]}.");
            Console.WriteLine($"The last number in your array is {arr[arr.Length-1]}.\n");
        }

        //O(n) runtime.
        //The method adds all the items in the array,
        //so time runs linearly with the size of the input,
        //therefore it is linear.
        static void addAll(int[] arr)
        {
            int total = 0;
            foreach (int i in arr)
            {
                total += i;
            }
            Console.WriteLine($"The total is {total}.\n");
        }

        //An implementation of bubble sort, which is O(n^2) runtime.
        //In each array access we are comparing two items,
        //therefore, this is a quadratic time complexity.
        //This method also includes a linear function to print out the array,
        //but since the lower terms get dropped, the method is still O(n^2).
        static void bubbleSort(int[] arr)
        {
            int temp;
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        notSorted = true;
                    }
                }
            }
            Console.WriteLine("The sorted array is:");
            foreach (int j in arr)
            {
                Console.Write($"{j} ");
            }
        }

        static void Main(string[] args)
        {
            //example input
            int[] numbers = { 17, 8, 22, 4, 9, 59, 3 };
            arrayInfo(numbers);
            addAll(numbers);
            bubbleSort(numbers);

            Console.ReadLine();
        }
    }
}
