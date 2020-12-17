# Trees
A C# Console Application that stores data in a Binary Tree data structure, and also uses Heaps to sort an array (using HeapSort as demonstrated in the Sorting project). The implementation takes advantage of object-oriented design, with nodes represented as classes instead of structs. An inorder traversal function is included.

The traversal function processes the nodes by multiplying each by 2. Therefore, we see the difference between the sorted array and the printed traversed tree (with data drawn from the sorted array).

## BinaryNode
*A class is used to represent the tree's nodes. Here we have the data contained in the node, as well as the left and right children it points to. Pseudocode from Essential Algorithms*
```
Class BinaryNode
 	String: Name
	 BinaryNode: LeftChild
	 BinaryNode: RightChild
 	Constructor(String: name)
 		Name = name
 	End Constructor
End Class
```

## BinaryTree
*A class to create the tree structure.*
```
BinaryNode InsertNode(BinaryNode root, int data)
	if root is null
		root := new BinaryNode(data)
	else if data < root.data
		<recursive call to function for root.Left>
	else
		<recursive call to function for root.Right>
	return root
End InsertNode
```
### Inorder Traversal
*Traverse the left subtree, then access the data, and finally traverse the right subtree. O(n) time. Pseudocode from Essential Algorithms.*
```
TraverseInorder(BinaryNode: node)
 	If (node.LeftChild != null) Then TraverseInorder(node.LeftChild)
 	<Process node>
	 If (node.RightChild != null) Then TraverseInorder(node.RightChild)
End TraverseInorder
```

## Heaps
*Binary tree structure used for HeapSort (O(nlog(n) complexity). There are two types: max heaps and min heaps*
### Max heap
*Each child is lesser than or equal to its parent.*
### Min heap
*Each child is greater than or equal to its parent.*
### Heapify an array
*Here's how we reorder an array to satisfy the heap property. Pseudocode from Essential Algorithms.*
```
MakeHeap(Data: values[])
 	// Add each item to the heap one at a time.
 	For i = 0 To <length of values> - 1
		 // Start at the new item, and work up to the root.
		 Integer: index = i
		 While (index != 0)
			// Find the parent's index.
			 Integer: parent = (index - 1) / 2
			 // If child <= parent, we're done, so
			 // break out of the While loop.
			 If (values[index] <= values[parent]) Then Break
			 // Swap the parent and child.
			 Data: temp = values[index]
			 values[index] = values[parent]
			 values[parent] = temp
			 // Move to the parent.
			 index = parent
		 End While
	 Next i
End MakeHeap
```
