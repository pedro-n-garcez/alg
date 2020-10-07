using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisher_yates
{
    public static class FisherYatesShuffle
    {
        //pseudo-random number generator
        private static Random rand = new Random();

        //this function takes in a string array and returns the same array but in random order
        public static string[] shuffledArray(string[] arr)
        {
            //going through all items of array from last to first
            //since array is zero-based, we start at length minus 1, and go down to one
            for (int i = arr.Length-1; i >= 1; i--)
            {
                //j will be a random index inside the array
                //we'll go down the array, swapping every item until 1 with another item of random j index
                int j = GetRandomNumberInInterval(i);
                swapTwoEntries(arr, i, j);
            }
            //return the rearranged array
            return arr;
        }

        //function that returns a random number from 0 to n
        //the upper bound for rand.Next is n+1 because the length in the shuffle is minus 1
        public static int GetRandomNumberInInterval(int n)
        {
            return rand.Next(n + 1);
        }

        //Void function to swap two entries in an array arr
        //temp is assigned the value of arr[a] so that arr[b] can receive it later
        //temp serves as the "intermediary" between arr[a] and arr[b]
        public static void swapTwoEntries(string[] arr, int a, int b)
        {
            string temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
