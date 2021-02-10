/*
 * Name:    Tanner Dryden
 * Class:   CptS 321
 * Prof:    Venera Arnaoudova
 *          Homework 1
 *          Description:    This program utilizes a BinaryTree class that takes numbers from user input
 *                          and parses the data into a binary tree omitting duplicate data and outputs
 *                          the data in order. The program also gives statistics of the tree created like
 *                          theoretical number of levels in the tree, actual levels, and quantity of data
 *                          entered into the tree.
 */

using System;
using Tree;

namespace HW1
{
    class OrderNumbers
    {
        public static void Main()
        {
            // Prompt user
            Console.WriteLine("Enter numbers between [0-100] that are separated by spaces:");

            // Takes user input
            string userInput;
            userInput = Console.ReadLine();

            // Parsing userInput into substrings
            string[] listOfStrings = userInput.Split(' ');

            // Instantiate the tree
            BinaryTree numTree = new BinaryTree();

            // Load the substrings into the tree
            foreach (var substring in listOfStrings)
            {
                numTree.TreeInsert(Convert.ToInt32(substring));
            }

            // Output to console
            Console.WriteLine("Your assorted string is: ");

            // Traverse the tree and print substrings in order
            numTree.InorderTraversal();

            // Print quantity of numbers in the tree
            Console.WriteLine("\nThe number of nodes in the tree is: " + numTree.TreeQuantity());

            // Print theoretical min number of levels in the tree
            Console.WriteLine("The theoretical minimum number of levels in the tree is: " + numTree.TheoreticalMinLevels());

            // Print actual number of levels in the tree
            Console.WriteLine("The actual number of levels in the tree is: " + numTree.ActualLevels());
        }
    }
}
