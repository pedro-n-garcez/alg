using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static fisher_yates.FisherYatesShuffle;

//Fisher Yates Shuffle Implementation
//An algorithm to rearrange a collection of items
//in random order

namespace fisher_yates
{
    class Program
    {
        static void Main(string[] args)
        {
            //using System.IO function ReadAllLines
            //to make every line in the file into an entry in an array
            //the file contains the names of all 50 states
            string[] entries = File.ReadAllLines("states.txt").ToArray();

            //function from FisherYatesShuffle class shuffles the array of states
            shuffledArray(entries);

            //write every state, listed in the new order, followed by a comma
            foreach (string i in entries)
            {
                Console.Write($"{i}, ");
            }
            //a conclusion to the written list
            Console.Write("and that's all fifty states.");

            Console.ReadKey();
        }
    }
}
