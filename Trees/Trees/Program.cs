using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trees
{
    class Program
    {
        //read text file of scores into an int array
        static int[] WriteScoresArray()
        {
            string[] textInput = File.ReadAllLines("scores.txt");
            int[] scores = new int[textInput.Length];
            for (int i = 0; i < textInput.Length; i++)
            {
                scores[i] = Int32.Parse(textInput[i]);
            }
            return scores;
        }

        static void Main(string[] args)
        {
            //write array
            int[] scores = WriteScoresArray();
            //since this is a project about trees, might as well use HeapSort
            Heaps.HeapSort(scores);

            Console.WriteLine("------SORTED ARRAY:------");
            foreach (int i in scores)
            {
                Console.Write($"{i} ");
            } Console.WriteLine("\n");

            BinaryTree tree = new BinaryTree();
            BinaryNode root = null;

            foreach (int i in scores)
            {
                root = tree.Insert(root, i);
            }

            Console.WriteLine("------INORDER TRAVERSAL & PRINT EACH NODE MULTIPLIED BY TWO:------");
            tree.Traverse(root);

            Console.ReadKey();
        }
    }
}
