using System;
using System.Collections;

// Created: Daniel Swain
// Date: 28/08/2016
// 
// Custom object representing the BinaryTree.

namespace BinaryTree
{
    class BinaryTree
    {
        // The root node.
        private static Node root;

        // Constructor to initialise the BinaryTree object, initially with a null root node.
        public BinaryTree()
        {
            root = null;
        }

        // Add a node to the binary tree.
        public bool addNode(Node nodeToInsert)
        {
            // If the root node is null then no root node exists so add the new node as the root node.
            if (root == null)
            {
                root = nodeToInsert;
                // Return true as it was added to the tree.
                return true;
            }
            // Else, the root node exists so we need to traverse the tree and add the node where it belongs.
            else
            {
                // Start from the root node.
                Node currentNode = root;
                // A temporary node used to hold reference to the currentNode (i.e. the parentNode) when traversing down tree branches.
                Node tempNode;

                // Check the node to insert with the node and traverse the chain continually until it's spot is found.
                while (true)
                {
                    // Set the temporary node equal to the current node as we may need to store the new node as it's left or rightNode.
                    tempNode = currentNode;
                    // Check if the node we're inserting has a value smaller than the current node.
                    if (nodeToInsert.value < currentNode.value)
                    {
                        // Set the current node to the leftNode of itself as we are now comparing that node to the newNode.
                        currentNode = currentNode.leftNode;

                        // If the current node has no leftNode then we can add the new node and exit this loop.
                        // We use the tempNode here to ensure the newNode is added to the correct parentNode.
                        if (currentNode == null)
                        {
                            tempNode.leftNode = nodeToInsert;
                            // Exit the while loop by returning true as it was added to the tree.
                            return true;
                        }
                    }
                    // Check if the node we're inserting is greater than the current node.
                    else if (nodeToInsert.value > currentNode.value)
                    {
                        // Set the current node to the rightNode of itself as we are now comparing that node to the newNode.
                        currentNode = currentNode.rightNode;

                        // If the current node has no rightNode then we can add the new node and exit this loop.
                        // We use the tempNode here to ensure the newNode is added to the correct parentNode.
                        if (currentNode == null)
                        {
                            tempNode.rightNode = nodeToInsert;
                            // Exit the while loop by returning true as it was added to the tree.
                            return true;
                        }
                    }
                    // Check if the node we're inserting is identical to the current node.
                    else if (nodeToInsert.value == currentNode.value)
                    {
                        // Not handling duplicates at the moment, returning false as it wasn't added.
                        return false;
                    }
                }
            }
        }

        // Visualise the tree.
        public void visualiseTree()
        {
            // The tree will be printed by queing up nodes and printing them to the console, this will end when the queue is empty (i.e. all nodes printed).
            Queue q = new Queue();
            // Enqueue the root node
            q.Enqueue(root);
            // While the queue isn't empty, lets print out each node in the correct position.
            while (q.Count > 0)
            {
                // Get the current node from the queue. And it's value as a string.
                Node currentNode = (Node) q.Dequeue();
                string textToEnter = currentNode.value.ToString();

                // Write the current node when it's be deQueued, placing it in the middle of the console window.
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));

                // Check if the current node has a left or right child node and if so, add them to the queue to be printed.
                if (currentNode.leftNode != null)
                {
                    q.Enqueue(currentNode.leftNode);
                }
                if (currentNode.rightNode != null)
                {
                    q.Enqueue(currentNode.rightNode);
                }
            }
        }
    }
}
