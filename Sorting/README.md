# Sorting
A C# Console Application that displays the most common sorting algorithms. Most implementations are based on those detailed in Rod Stephens's book *Essential Algorithms*. The application shows the sorted lists from each algorithm and the time (in milliseconds) they take to complete the task. Information on the algorithms is printed to the console, and a comparison table summarizing the algorithms is displayed at the end.
## Quadratic time sorts
*These have an average time-complexity of O(n^2). They are simpler to implement and work best on smaller-sized lists.*
### BubbleSort
*Iterates through the list, comparing an element with the next one to see if they are out of order. If the current number is greater than the next, we swap.*
```
Bubblesort(Data: values[])
    Boolean: not_sorted = True
    While (not_sorted)
        not_sorted = False
        For i = 0 To <length of values> - 1
            If (values[i] < values[i - 1]) Then
                Data: temp = values[i]
                values[i] = values[i - 1]
                values[i - 1] = temp
                // The array isn't sorted after all.
                not_sorted = True
            End If
        Next i
    End While
End Bubblesort
```
### InsertionSort
*Iterates through the list, and compares every element with every element before it. If the previous is greater than the current one, we swap.*
```
Insertionsort(Data: values[])
   For i = 0 To <length of values> - 1
       // Move item i into position
       //in the sorted part of the array
       < Find  the first index j where
         j < i and values[j] > values[i].>
       <Move the item into position j.>
   Next i
End Insertionsort
```
### SelectionSort
*Iterates through the list, looking for the smallest number. Every time it finds a number smaller than the current, that number becomes the smallest. At the end we swap the smallest with the current.*
```
Selectionsort(Data: values[])
    For i = 0 To <length of values> - 1
        // Find the item that belongs in position i.
        <Find the smallest item with index j >= i.>
        <Swap values[i] and values[j].>
    Next i
End Selectionsort  
```
## Linearithmic time sorts
*These have an average time-complexity of O(nlog(n)), and are much faster than quadratic sorts on larger-sized lists.*
### HeapSort
*Turns the list into a heap data structure: nodes are parents that contain at most two children that are less than or equal to the parent. Then the algorithm removes the top item and reorders the heap to satisfy its property. Thus, iterating in a reverse order, the array will be in sorted ascending order.*
```
Heapsort(Data: values)
    <Turn the array into a heap.>
 
    For i = <length of values> - 1 To 0 Step -1
        // Swap the root item and the last item.
        Data: temp = values[0]
        values[0] = values[i]
        values[i] = temp
 
        <Consider the item in position i to be removed from the heap,
         so the heap now holds i - 1 items. Push the new root value
         down into the heap to restore the heap property.>
    Next i
End Heapsort  
```
### QuickSort
*Picks a pivot item that divides the list into left and right. Through comparisons, we determine items smaller than the pivot go to its left; items greater, to its right. Recursive calls subdivide the array further, sorting the smaller divisions and then tackling the other parts of the list little by little until it is all sorted. This is a three-way partition implementation that accounts for repeated elements, so only the less-than and greater-than partitions need to be recursively sorted.*
```
algorithm quicksort(A, lo, hi) is
    if lo < hi then
        p := pivot(A, lo, hi)
        left, right := partition(A, p, lo, hi)  // note: multiple return values
        quicksort(A, lo, left - 1)
        quicksort(A, right + 1, hi)
```
### MergeSort
*Splits array in two, then calls itself to do so again until it can't be divided further. These subdivisions are then merged into sorted groups of two, then four, and so on. The division is always at the middle.*
```
Mergesort(Data: values[], Data: scratch[], Integer: start, Integer: end)
    // If the array contains only one item, it is already sorted.

If (start == end) Then Return
 
    // Break the array into left and right halves.
    Integer: midpoint = (start + end) / 2
 
    // Call Mergesort to sort the two halves.
    Mergesort(values, scratch, start, midpoint)
    Mergesort(values, scratch, midpoint + 1, end)
 
    // Merge the two sorted halves.
    Integer: left_index = start
    Integer: right_index = midpoint + 1
    Integer: scratch_index = left_index
    While ((left_index <= midpoint) And (right_index <= end))
        If (values[left_index] <= values[right_index]) Then
            scratch[scratch_index] = values[left_index]
            left_index = left_index + 1
        Else
            scratch[scratch_index] = values[right_index]
            right_index = right_index + 1
        End If
        scratch_index = scratch_index + 1    End While
 
    // Finish copying whichever half is not empty.
    For i = left_index To midpoint
        scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    For i = right_index To end

scratch[scratch_index] = values[i]
        scratch_index = scratch_index + 1
    Next i
    // Copy the values back into the original values array.
    For i = start To end
        values[i] = scratch[i]
    Next i
End Mergesort
```
