# Searching
A C# Console Application that displays three searching algorithms. The implementation for Interpolation Search is based on that written for JavaScript by Karuna Sehgal. The application allows the user to input target values for the Linear, Binary and Interpolation Search algorithms to find it in the list. The time (in milliseconds) they take to complete the task is displayed. Information on the algorithms is printed to the console, and a summary at the end as well.
## Linear search
*Iterates through the list, from start to end, looking for the desired input item. Works on unsorted and sorted lists and small-sized lists.*
```
Begin
1) Set i = 0
2) If Li = T, go to line 4
3) Increase i by 1 and go to line 2
4) If i < n then return i
End
```
## Binary search
*Finds the middle item of the array, compares that with the input item and chooses the half on which the item falls. Performs better than Interpolation search if the input is small. Needs a sorted array.*
```
function binary_search(A, n, T) is
    L := 0
    R := n − 1
    while L ≤ R do
        m := floor((L + R) / 2)
        if A[m] < T then
            L := m + 1
        else if A[m] > T then
            R := m − 1
        else:
            return m
    return unsuccessful
```
## Interpolation search
*Estimates a location where the input item is, and will be closer to it. Works best on very large lists. Needs a sorted array.*