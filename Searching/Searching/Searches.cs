using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public static class Searches
    {
        //O(n) worst case, O(1) best case
        public static void LinearSearch(int input, int[] arr)
        {
            //var for index where your input is
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == input)
                {
                    //return index
                    index = i;
                    Console.WriteLine($"Found it at index {index}.");
                    return;
                }
            }
            //iterated through array and did not find your input
            Console.WriteLine("Your item was not found.");
        }

        //O(log n) worst case, O(1) best case
        public static void BinarySearch(int input, int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            //process will run on the correct half until the item is found
            //as left and right are reassigned we get closer to the input item
            while(left <= right)
            {
                int middle = (left+right)/2;
                if (arr[middle] < input)
                {
                    left = middle + 1;
                } else if  (arr[middle] > input)
                {
                    right = middle - 1;
                }
                //if not < or > it's equal, therefore it's found
                else
                {
                    Console.WriteLine($"Found it at index {middle}.");
                    return;
                }
            }
            Console.WriteLine("Your item was not found.");
        }

        //O(n) worst case, O(log(log n)) average case, O(1) best case
        public static void InterpolationSearch(int input, int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;
            int pos;
            float delta;
            while (low<=high && input >= arr[low] && input <= arr[high])
            {
                delta = (input - arr[low]) / (arr[high] - arr[low]);

                //will put position index directly at or very close to actual target,
                //as opposed to in the middle
                pos = low + (int)((high-low)*delta);
                if (arr[pos] == input)
                {
                    Console.WriteLine($"Found it at index {pos}.");
                    return;
                }
                if (arr[pos] < input)
                {
                    low = pos + 1;
                }
                else
                {
                    high = pos - 1;
                }
            }
            Console.WriteLine("Your item was not found.");
        }
    }
}
