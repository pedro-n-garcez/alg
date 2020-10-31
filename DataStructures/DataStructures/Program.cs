using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayMap.AddEntriesToCollections();
            //ArrayMap.PrintEntireArray();
            //ArrayMap.PrintEntireHash();
            ArrayMap.SearchForCapitalArray();
            ArrayMap.SearchForCapitalHash();

            //Queue
            StackQueue.StateEnqueueing();
            StackQueue.StatesDequeueing();

            //Stack
            StackQueue.StatesStackPush();
            StackQueue.StatesStackPop();

            Console.ReadKey();
        }
    }
}
