using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigO
{
    static class On2
    {
        //An implementation of bubble sort, which is O(n^2) runtime.
        //In each array access we are comparing two items,
        //therefore, this is a quadratic time complexity.
        //This method also includes a linear function to print out the array,
        //but since the lower terms get dropped, the method is still O(n^2).
        public static void bubbleSort(int[] arr)
        {
            int temp;
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < arr.Length - 1; i++)
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
    }
}
