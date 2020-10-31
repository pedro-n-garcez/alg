using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;

namespace DataStructures
{
    public static class StackQueue
    {
        //Adding all US states from file
        static string[] states = File.ReadAllLines("states.txt");

        //Queues are First In First Out (FIFO)
        //elements are inserted at the tail, and removed at the head
        static Queue<string> statesQueue = new Queue<string>();

        //Stacks are Last In First Out (LIFO)
        //elements are inserted at the head, and removed at the head
        static Stack<string> statesStack = new Stack<string>();

        //insert new states at tail of queue
        public static void StateEnqueueing()
        {
            int i = 0;
            for (i = 0; i < 50; i++)
            {
                statesQueue.Enqueue(states[i]);
            }
            Console.WriteLine($"{i} items queued.\n");
        }

        //insert new states at head of stack
        public static void StatesStackPush()
        {
            int i;
            for (i = 0; i < 50; i++)
            {
                statesStack.Push(states[i]);
            }
            Console.WriteLine($"{i} states pushed.\n");
        }

        //Removing and returning the element found at head
        //Items will be dequeued in the alphabetical order in which they were queued
        //First in, first out
        public static void StatesDequeueing()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("DEQUEUED: " + statesQueue.Dequeue());
            }
            Console.WriteLine("\n");
        }

        //Removing and returning the element found at head
        //Items will be popped in reverse alphabetical order, because we get the last elements added first
        //Last in, first out
        public static void StatesStackPop()
        {
            for (int i = 0; i < 50; i++) 
            {
                Console.WriteLine("POPPED OUT: " + statesStack.Pop());
            }
            Console.WriteLine("\n");
        }
    }
}

/*
 * Stacks and queues have O(1) time operations
 * Queues are useful for a first-come, first-served solution
 * Stacks are useful if you need to work with the latest data submitted first
 * None are particularly useful if you need to access an element at a certain position
 * To do that you must remove every item from the head until you reach the one you need
 */
