# Algorithms
*C# implementation of algorithms for the PROG 366 class. The algorithms are divided into separate VS project folders. The projects included in this repository so far are:*

* **bigO**: Some brief methods that exemplify common types of big O notation: constant, linear and quadratic. O(1) runtime accesses the first and last elements of the array, therefore size of input does not matter. O(n) runtime goes through every number in an array and adds them into a sum. O(n^2) runtime is an implementation of bubble sort.

* **fisher_yates**: An implementation of the Fisher-Yates shuffling algorithm, also known as the Knuth shuffle, that places every item in the collection into a new, random position. This implementation reads a plain text file and outputs the lines in the file in a randomized order.

* **DataStructures**: A demonstration of data structures in the .NET Systems.Collections library. Comparisons between stacks (a last-in first-out structure) and queues (a first-in first-out structure), and between a two-dimensional array and a Hashtable for storage of data pairs. The data in these structures is read from external text files. The application allows the user to input a U.S. state and get the corresponding state capital, as well as queue and stack U.S. states.

* **Sorting**: Implementations of the most common sorting algorithms: the quadratic sorts BubbleSort, InsertionSort, and SelectionSort; and the linearithmic sorts HeapSort, QuickSort and MergeSort. Some implementations based on pseudocode from *Essential Algorithms* by Rod Stephens. The console application reads and stores scores of numbers from a text file, with many repeated entries. The sorting functions then sort these number into ascending order. Brief explanations of the algorithms, as well as a summary comparison table, are outputted to the console.
