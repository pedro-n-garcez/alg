using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class Sorts
    {
        public static void BubbleSort(int[] arr)
        {
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    //compare element with its immediate successor
                    if (arr[i] > arr[i + 1])
                    {
                        //swap if not in correct order
                        Swap(arr, i, i + 1);
                        notSorted = true;
                    }
                }
                //if notSorted remains false, no more swaps are needed
            }
        }

        public static void InsertionSort(int[] arr)
        {
            //we start with 1 to compare arr[1] w arr[0], arr[2] w arr[1] & so on
            for (int i = 1; i<arr.Length; i++)
            {
                //index of current number we're working with
                int j = i;
                //checking if j>0 to end while when we reach the end
                //if the previous num is bigger than current, swap
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j - 1, j);
                    j--;
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int min;
            //i is the current number, which we'll swap with the smallest at the end
            for (int i = 0; i < arr.Length-1; i++)
            {
                //i assumed to be the smallest until we find a smaller one, and so on
                min = i;
                //nested for loop to compared subsequent elements with min
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //if true, then we've found a smaller number, pass than as the new minimum 
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                //we only get to swap until after the nested for is done iterating
                //which means we've found the smallest number out of all the elements
                Swap(arr, i, min);
            }
        }

        //Makes use of MakeHeap and Remove helper functions
        public static void HeapSort(int[] arr)
        {
            //heapify the array
            MakeHeap(arr);

            //iterate thru heap, from the bottom up to the top node
            for (int i = arr.Length-1; i >= 0; i--)
            {
                //swap top and bottom nodes
                Swap(arr,0,i);

                //restore the heap property
                //pass i in the function because arr[i] is considered removed from heap
                //so the size of the heap changes according to i in for
                RemoveTopItemFromHeap(arr, i);
            }
        }

        //Uses partition helper function, a tuple that returns leftmost and rightmost items of partition
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                //assign tuple value from partition to p variable
                Tuple<int, int> p = Partition(arr, low, high);

                //assign left and right indices of partition
                int left = p.Item1;
                int right = p.Item2;

                //recursive calls to subdivide further and sort the smaller parts
                QuickSort(arr, low, left - 1);
                QuickSort(arr, right, high);
            }
        }

        //Uses empty scratch of same length as arr, where sorting occurs. Values are copied back to arr
        public static void MergeSort(int[] arr, int[] scratch, int start, int end)
        {
            //end function if only one element in arr, it's already sorted then
            if (start == end)
            {
                return;
            }

            //find the middle index of the array
            int midpoint = (start + end) / 2;

            //recursive call to divide array in half, and that half in half, and so on
            MergeSort(arr, scratch, start, midpoint);
            MergeSort(arr, scratch, midpoint+1, end);

            //find where the left, right and scratch iterations begin
            int leftIndex = start;
            int rightIndex = midpoint + 1;
            int scratchIndex = leftIndex;
            while(leftIndex <= midpoint && rightIndex <= end)
            {
                if (arr[leftIndex] <= arr[rightIndex])
                {
                    scratch[scratchIndex] = arr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    scratch[scratchIndex] = arr[rightIndex];
                    rightIndex++;
                }
                scratchIndex++;
            }

            //Copy into scratch the remaining elements
            for (int i = leftIndex; i <= midpoint; i++)
            {
                scratch[scratchIndex] = arr[i];
                scratchIndex++;
            }

            //Copy into scratch the remaining elements
            for (int i = rightIndex; i <= end; i++)
            {
                scratch[scratchIndex] = arr[i];
                scratchIndex++;
            }

            //this copies the contents of scratch back into arr
            for (int i = start; i <= end; i++)
            {
                arr[i] = scratch[i];
            }
        }

        //Swap helper function used in multiple sorting algorithms
        //arguments: array & index positions of elements we wanna swap
        private static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        //Partition helper function for QuickSort
        private static Tuple<int, int> Partition(int[] arr, int low, int high)
        {
            //iterate from the first item
            int i = low;
            //pivot at the last item
            int pivot = arr[high];
            while (i <= high)
            {
                //everything less than pivot goes left
                if (arr[i] < pivot)
                {
                    Swap(arr, low, i);
                    low++;
                    i++;
                }
                else if (arr[i] > pivot) //everything greater than pivot goes right
                {
                    Swap(arr, high, i);
                    high--;
                } //items equal to pivot don't need sorting, continue iterating
                else { i++; }
            } //return leftmost and rightmost item of partition
            return Tuple.Create(low, i);
        }

        //MakeHeap helper function for HeapSort
        /*turns array into a heap structure
         * parent followed by its two children, followed by their children, and so on
         * every child is less than or equal to its parent
         * if there aren't enough nodes, some children will be childless
         */
        private static void MakeHeap(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //we start with index as the child, finding its parents until we reach the root
                int index = i;
                while (index != 0)
                {
                    //finds the index of the parent
                    int parent = (index - 1) / 2;
                    //if heap property is satisfied, break
                    if (arr[index] <= arr[parent])
                    {
                        break;
                    } //swap if child is greater than parent
                    else {
                        Swap(arr, index, parent);
                    } //we then go to the parent's index and keep working our way up
                    index = parent;
                }
            }
        }

        //Helper function to remove and swap the top item in a heap for HeapSort
        private static void RemoveTopItemFromHeap(int[] arr, int i)
        {
            int index = 0;
            while (true)
            {
                //finds the indices of the two children
                int child1 = 2 * index + 1;
                int child2 = 2 * index + 2;

                //check if child index is out the bounds of the heap
                if (child1 >= i) { child1 = index; }
                if (child2 >= i) { child2 = index; }

                //break if heap property is satisfied (both children less than or equal to parent
                if (arr[index] >= arr[child1] && arr[index] >= arr[child2]) { break; }

                //whichever child is greater will be swapped with the parent
                int swapChild = (arr[child1] > arr[child2] ? child1 : child2);

                //swap parent and child if child greater than parent
                if (arr[swapChild] > arr[index])
                {
                    Swap(arr, index, swapChild);
                }
                //pick up from the child; child becomes the next parent
                index = swapChild;
            }
        }
    }
}
