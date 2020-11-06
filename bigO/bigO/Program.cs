using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigO
{
    class Program
    {
        static void Main(string[] args)
        {
            //example input
            int[] numbers = { 17, 8, 22, 4, 9, 59, 3 };

            O1.getFirstAndLast(numbers);
            On.addAll(numbers);
            On2.bubbleSort(numbers);

            Console.ReadLine();
        }
    }
}
