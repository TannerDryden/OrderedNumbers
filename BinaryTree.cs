using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class BinaryTree
    {
        // Accessor functions
        public void TreeInsert(int key)
        {
            this.root = this.InsertRecursive(this.root, key);
        }

        public void InorderTraversal()
        {
            this.InOrderTraversalRecursive(this.root);
        }

        public int TreeQuantity()
        {
            return this.GetCount();
        }

        public int TheoreticalMinLevels()
        {
            return this.TheoreticalMinLevelsCalc();
        }

        public int ActualLevels()
        {
            return this.ActualLevelsCalc(this.root);
        }

        // A recursive function that inserts a new tree
        Node InsertRecursive(Node root, int key)
        {
            // Return a new node if tree is empty
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            // Case for duplicates
            if (key != root.GetKey())
            {
                // Recur down the tree
                if (key < root.GetKey())
                {
                    root.SetLeft(this.InsertRecursive(root.GetLeft(), key));
                }
                else if (key > root.GetKey())
                {
                    root.SetRight(this.InsertRecursive(root.GetRight(), key));
                }
            }

            // Return the node
            return root;
        }

        // Node/Level counter
        private int count = 0;
        private int theoreticalLevels = 0;

        private int AddCount() => this.count += 1;

        private int GetCount() => this.count;

        // Level calculators
        private int TheoreticalMinLevelsCalc()
        {
           this.theoreticalLevels += (int)Math.Ceiling(Math.Log2(this.count + 1));
           return this.theoreticalLevels;
        }

        private int ActualLevelsCalc(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(this.ActualLevelsCalc(node.GetLeft()), this.ActualLevelsCalc(node.GetRight())) + 1;

        }

        // Root of the tree
        private Node root;

        private class Node
        {
            // initializers
            private int key;
            private Node left;
            private Node right;

            // Constructor
            public Node(int newKey)
            {
                this.SetKey(newKey);
                this.SetLeft(null);
                this.SetRight(null);
            }

            // Get functions
            public int GetKey() => this.key;

            public Node GetLeft() => this.left;

            public Node GetRight() => this.right;

            // Set functions
            public int SetKey(int newKey) => this.key = newKey;

            public Node SetLeft(Node newLeft) => this.left = newLeft;

            public Node SetRight(Node newRight) => this.right = newRight;
        }

        // inorder traversal function
        private void InOrderTraversalRecursive(Node node)
        {
            if (node != null)
            {
                this.InOrderTraversalRecursive(node.GetLeft());
                Console.Write(node.GetKey() + " ");
                this.AddCount();
                this.InOrderTraversalRecursive(node.GetRight());
            }
        }
    }
}
