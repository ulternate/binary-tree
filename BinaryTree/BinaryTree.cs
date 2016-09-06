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

        // Choice options for the traversal method in the visualiser.
        public const int INORDER_TRAVERSAL = 1;
        public const int PREORDER_TRAVERSAL = 2;
        public const int POSTORDER_TRAVERSAL = 3;

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
                            // Set the parent node of the node to insert to the tempnode
                            nodeToInsert.setParent(tempNode);
                            // Add the node to the tree.
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
                            // Set the parent node of the node to insert to the tempnode
                            nodeToInsert.setParent(tempNode);
                            // Add the node to the tree.
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

        // Find a node in the binary tree by using the node's key.
        public Node findNodeByKey(int searchKey)
        {
            // If the tree has a root node then we can start searching, otherwise it hasn't been inititalised and won't contain any nodes.
            if (root != null)
            {
                // Search for the value in the nodes by comparing the value with the root and then traversing down the subtrees based upon the value.
                Node currentNodeBeingChecked = root;
                // Continue checking nodes until we find the value or the loop is exited because it doesn't exist down the branch it should exist in.
                while (currentNodeBeingChecked.value != searchKey)
                {
                    // If the value is smaller thant the current node's value then look down the left node by setting the currentNode to the leftNode.
                    if (searchKey < currentNodeBeingChecked.value)
                    {
                        // Set the currentNodeBeingChecked to the left node so it will be the node checked against in the next loop.
                        currentNodeBeingChecked = currentNodeBeingChecked.leftNode;
                    }
                    else
                    // The value is greater than the value we're looking for (if it was equal then the while loop would have exited already).
                    {
                        // Set the currentNodeBeingChecked to the rightNode so it will be the node checked against in the next loop.
                        currentNodeBeingChecked = currentNodeBeingChecked.rightNode;
                    }
                    // If the currentNodeBeingChecked is null then that means the previous node was a leaf node and has no children.
                    // That implies that if the number still hasn't been found then it isn't in the tree as it is either a smaller or larger child (left or right).
                    if (currentNodeBeingChecked == null)
                    {
                        // Returning null as the node wasn't found in the tree.
                        return null;
                    }
                }
                // The while loop has exited as the currentNodeBeingChecked.value == valueToFind. Return this node.
                return currentNodeBeingChecked;
            }
            else
            // There's no root node in the tree so return null.
            {
                return null;
            }
        }

        // Delete the desired node.
        public bool deleteNodeByKey(int searchKey)
        {
            // TODO implement delete for nodes with zero children, 1 child and 2 children.
            return false;
        }

        // Print out the contents of the tree using the desired traversal method.
        public void traverseAndPrintTree(int traversalMethod)
        {
            switch (traversalMethod)
            {
                case INORDER_TRAVERSAL:
                    Console.WriteLine("Traversing the tree using the InOrder traversal method (i.e. left subtree, then root, then right subtree).\n");
                    inOrderTraversal(root);
                    break;

                case PREORDER_TRAVERSAL:
                    Console.WriteLine("Traversing the tree using the PreOrder traversal method (i.e. root, then left subtree, then right subtree).\n");
                    preOrderTraversal(root);
                    break;

                case POSTORDER_TRAVERSAL:
                    Console.WriteLine("Traversing the tree using the PostOrder traversal method (i.e. left subtree, then right subtree, then root).\n");
                    postOrderTraversal(root);
                    break;

                default:
                    Console.WriteLine("\nThe traversal method used, {0}, didn't refer to a valid traversal method. The options are {1}, {2} and {3}\n",
                        traversalMethod, 
                        INORDER_TRAVERSAL, 
                        PREORDER_TRAVERSAL, 
                        POSTORDER_TRAVERSAL);
                    break;
            }
        }

        // Traverse the BinaryTree inOrder.
        // This means the left subtree is traversed recursively first using inOrder (i.e. left, root, right),
        // Then the root node is visited,
        // Then the right subtree is traversed recursively last using the inOrder method (i.e. left, root, right).
        private void inOrderTraversal(Node root)
        {
            // if the node we're traversing is not null then traverse it's children.
            if (root != null)
            {
                // recursively traverse the left children first.
                inOrderTraversal(root.leftNode);
                // then print the root node when there are no more left children.
                Console.Write("[{0}, \"{1}\"] ", root.value, root.data);
                // Finally, traverse the right nodes recursively.
                inOrderTraversal(root.rightNode);
            }
        }

        // Traverse the BinaryTree preOrder
        // This means the root node is visited first, 
        // Then the left subtrees are traversed recursively using the preorder method (i.e. root, then left, then right),
        // Then the right subtrees are traversed recursively using the preorder method (i.e. root, then left, then right).
        private void preOrderTraversal(Node root)
        {
            // if the node we're traversing is not null then traverse it's children.
            if (root != null)
            {
                // Print the root node first.
                Console.Write("[{0}, \"{1}\"] ", root.value, root.data);
                // recursively traverse the left nodes.
                preOrderTraversal(root.leftNode);
                // recursively traverse the right nodes.
                preOrderTraversal(root.rightNode);
            }
        }

        // Traverse the BinaryTree using the postOrder method
        // This means the root node is visited last.
        // So the left subtrees are traversed recursively using the postorder method first (i.e. left, right, root),
        // Then the right subtree's are traversed recursively using the postorder method (i.e. left, right, root),
        // Then the root node is visited last (i.e. left, right, root).
        private void postOrderTraversal(Node root)
        {
            // If the node we're traversing is not null then traverse it's children.
            if (root != null)
            {
                // Recursively traverse the left node's first.
                postOrderTraversal(root.leftNode);
                // Recursively traverse the right node's next.
                postOrderTraversal(root.rightNode);
                // Print the root node last.
                Console.Write("[{0}, \"{1}\"] ", root.value, root.data);
            }
        }
    }
}
