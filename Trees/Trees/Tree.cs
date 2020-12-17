using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    //We can create a node as a class
    //Otherwise we could use a struct for example
    public class BinaryNode
    {
        //the node contains references to its left and right children
        //in addition to the data it holds
        public int Data;
        public BinaryNode Left;
        public BinaryNode Right;

        //constructor to pass in the data along with the node instantiation
        public BinaryNode(int Data)
        {
            this.Data = Data;
        }
    }

    //A class for the tree itself
    public class BinaryTree
    {
        //Function to insert a new node at the root
        public BinaryNode Insert(BinaryNode root, int data)
        {
            //if root is empty, insert a new node
            if (root == null)
            {
                root = new BinaryNode(data);
            }
            //integers less than the root's stay on the left
            //recursive call to insert to the left
            else if (data < root.Data)
            {
                root.Left = Insert(root.Left, data);
            }
            //integers greater than or equal to the root's stay on the right
            //recursive call to insert to the right
            else
            {
                root.Right = Insert(root.Right, data);
            }
            return root;
        }

        //Inorder traversal
        /*
         * First, we traverse the left subtree by recursive call
         * Then, we access the data
         * Finally, we traverse the right subtree by recursive call
         */
         //As example of what we can do with traversal, an operation is performed on each node data
        public void Traverse(BinaryNode root)
        {
            if (root == null)
            {
                return;
            }

            Traverse(root.Left);
            Console.Write($"{root.Data * 2} ");
            Traverse(root.Right);
        }
    }
}
