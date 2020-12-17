using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    //Heaps are a type of binary tree structure
    //There can be max or min heaps
    //Practical application of trees: heaps are used for an O(n log n) sorting algorithm
    public static class Heaps
    {
        //Function to turn an array into a max heap
        //A node holds at most 2 children that are less than or equal to it
        public static void MaxHeapify(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int index = i;
                while(index != 0)
                {
                    int parent = (index - 1) / 2;
                    //check if heap property is satisfied
                    //if so, break; if not, swap child and parent
                    if (arr[parent] >= arr[index])
                    {
                        break;
                    }
                    else
                    {
                        int temp = arr[index];
                        arr[index] = arr[parent];
                        arr[parent] = temp;
                    }
                    index = parent;
                }
            }
        }

        //Function to turn an array into a min heap
        //A node holds at most 2 children that are greater than or equal to it
        public static void MinHeapify(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int index = i;
                while (index != 0)
                {
                    int parent = (index - 1) / 2;
                    //check if heap property is satisfied
                    //if so, break; if not, swap child and parent
                    if (arr[parent] <= arr[index])
                    {
                        break;
                    }
                    else
                    {
                        int temp = arr[index];
                        arr[index] = arr[parent];
                        arr[parent] = temp;
                    }
                    index = parent;
                }
            }
        }

        //Implementation of HeapSort similar to the one in the Sorting project
        public static void HeapSort(int[] arr)
        {
            int index;
            //turn array into heap
            MaxHeapify(arr);

            //send first node to the end
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                //restore the heap property
                index = 0;
                while (true)
                {
                    //formulas for finding a child
                    //2 times index plus (1 if left child, 2 if right child)
                    int child1 = 2 * index + 1;
                    int child2 = 2 * index + 2;

                    //check if child index is beyond bounds of heap
                    if (child1 >= i) { child1 = index; }
                    if (child2 >= i) { child2 = index; }

                    //we can break if heap property is satisfied (parent >= children)
                    if (arr[index] >= arr[child1] && arr[index] >= arr[child2]) { break; }

                    //the bigger of the two children will be the one to swap
                    //swap if greater than parent
                    int childIndexToSwap = (arr[child1] > arr[child2] ? child1 : child2);
                    if (arr[childIndexToSwap] > arr[index])
                    {
                        int tempChild = arr[childIndexToSwap];
                        arr[childIndexToSwap] = arr[index];
                        arr[index] = tempChild;
                    }
                    //go to the child, and so on
                    index = childIndexToSwap;
                }
            }
        }
    }
}
