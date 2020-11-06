using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigO
{
    static class O1
    {
        //O(1) runtime.
        //The method accesses the first and last indexes of the array only, 
        //so the size of the input does not matter,
        //therefore it is constant.
        public static void getFirstAndLast(int[] arr)
        {
            Console.WriteLine($"The first number in your array is {arr[0]}.");
            Console.WriteLine($"The last number in your array is {arr[arr.Length - 1]}.\n");
        }
    }
}
