using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace DataStructures
{
    public static class ArrayMap
    {
        //A two-dimensional array to store US states and their corresponding capitals
        static string[,] statesCapitalsArray = new string[50, 2];

        //Hashtables store key and value pairs of DictionaryEntry type
        //Hashtable hashes the key to map it to its corresponding value
        //Hashtables are weakly-typed
        //There is also Dictionary in .NET which is strongly-typed variant
        static Hashtable statesCapitalsHash = new Hashtable();

        public static void AddEntriesToCollections()
        {
            //reading lines from files and assigning them to separate state and capital arrays
            string[] states = File.ReadAllLines("states.txt");
            string[] capitals = File.ReadAllLines("capitals.txt");

            //first column is assigned the states, second column is assigned the capitals
            //a state and a capital are matched by being in the same row
            for (int i = 0; i < 50; i++){
                statesCapitalsArray[i, 0] = states[i];
                statesCapitalsArray[i, 1] = capitals[i];
            }

            //adding states as keys and capitals are values to the hashtable
            for(int i = 0; i<50; i++){statesCapitalsHash.Add(states[i],capitals[i]);}
        }

        //this function will print keys in alphabetical order along with their values
        //because they were stored in this order
        public static void PrintEntireArray()
        {
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine($"The capital of {statesCapitalsArray[i, 0]} is {statesCapitalsArray[i, 1]}.");
            }
            Console.WriteLine("\n");
        }

        //this function will not print pairs in alphabetical order, as keys are not stored in a particular order
        public static void PrintEntireHash()
        {
            foreach (DictionaryEntry d in statesCapitalsHash)
            {
                Console.WriteLine($"The capital of {d.Key} is {d.Value}.");
            }
            Console.WriteLine("\n");
        }

        //function for user to input a state and get its capital from Array
        public static void SearchForCapitalArray()
        {
            bool flag = false;

            Console.Write("Find the capital of the following state: ");
            string input = Console.ReadLine();

            //Iterating through array takes longer than key access from Hashtable
            for (int i = 0; i < 50; i++)
            {
                if (statesCapitalsArray[i,0] == input)
                {
                    Console.WriteLine($"The capital of {input} is {statesCapitalsArray[i,1]}.");
                    flag = true;
                }
            } if (flag == false) //flag remains false because the input is not recognized
            {
                Console.WriteLine("State not found.");
            }
            Console.WriteLine("\n");
        }

        //function for user to input a state and get its capital from Hashtable
        public static void SearchForCapitalHash()
        {
            Console.Write("Find the capital of the following state: ");
            string input = Console.ReadLine();

            //Direct access to the key is faster than iterating through array
            //Simpler function because flag is not needed thanks to ContainsKey check
            if(statesCapitalsHash.ContainsKey(input))
            {
                Console.WriteLine($"The capital of {input} is {statesCapitalsHash[input]}.");
            }
            else
            {
                Console.WriteLine("State not found.");
            }
            Console.WriteLine("\n");
        }
    }
}

/*
 * Hashtable is better than array for pairs of data
 * Hashtable benefit:   O(1) lookup and search, no need to iterate through collection to get value
 * Hashtable drawbacks: Keys are not stored in a particular order, can be a problem if sorted collection is needed
 *                      Must know the key to find its value
 *                      Weakly-typing can cause errors if you forget to cast or convert different data types when needed
 * Array benefit:       Data can be stored in order or sorted if necessary
 * Array drawbacks:     O(n) lookup, must iterate through collection to get value
 */
