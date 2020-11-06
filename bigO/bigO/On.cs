using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigO
{
    static class On
    {
        //O(n) runtime.
        //The method adds all the items in the array,
        //so time runs linearly with the size of the input,
        //therefore it is linear.
        public static void addAll(int[] arr)
        {
            int total = 0;
            foreach (int i in arr)
            {
                total += i;
            }
            Console.WriteLine($"The sum of all numbers in the array is {total}.\n");
        }
    }
}
