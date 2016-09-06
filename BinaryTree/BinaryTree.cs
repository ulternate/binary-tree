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
        public bool deleteNode(Node node)
        {

            //////////////////////////////// TODO
            // Need to handle the case where the node being deleted is the root....




            // Node is a leaf node.
            if ( node.leftNode == null && node.rightNode == null)
            {
                // The node has no children so we can safely delete it.
                // Need to set the right or left node of the parent to be null send.
                if (node.getParent().rightNode == node)
                {
                    // The node being deleted is the right node of the parent node.
                    node.getParent().rightNode = null;
                    return true;
                }
                else
                {
                    // The node being deleted is the left node of the parent node.
                    node.getParent().leftNode = null;
                    return true;
                }
            }
            // Only left node on the node.
            else if(node.leftNode != null && node.rightNode == null)
            {
                if (node.getParent().rightNode == node)
                {
                    // Set the right node of the parent to the left node of the node being deleted.
                    node.getParent().rightNode = node.leftNode;
                    return true;
                }
                else
                {
                    // Set the left node of the parent to the left node of the node being deleted.
                    node.getParent().leftNode = node.leftNode;
                    return true;
                }
            }
            // Only right node is there.
            else if (node.leftNode == null && node.rightNode != null)
            {
                if (node.getParent().rightNode == node)
                {
                    // Set the right node of the parent to the right node of the node being deleted.
                    node.getParent().rightNode = node.rightNode;
                    return true;
                }
                else
                {
                    // Set the left node of the parent to the right node of the node being deleted.
                    node.getParent().leftNode = node.rightNode;
                    return true;
                }
            }
            // Both left and right children exist
            else
            {
                // Get the predecessor (note, could also use the successor for this delete method).
                Node predecessor = getPredecessor(node);
                // Delete the predecessor (this should be a leaf node).
                deleteNode(predecessor);
                // Set the properties of the predecessor to be that of the node being deleted.
                predecessor.setParent(node.getParent());
                predecessor.leftNode = node.leftNode;
                predecessor.rightNode = node.rightNode;
                // if the node's parent's right node is equal to the node (i.e. it's a right node of the parent).
                // Then set the right node of the parent to be the new predecessor.
                if (node.getParent().rightNode == node)
                {
                    node.getParent().rightNode = predecessor;
                    return true;
                }
                // Otherwise set the left node of the parent to be the new predecessor.
                else
                {
                    node.getParent().leftNode = predecessor;
                    return true;
                }
            }
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

        // Get the successor of the node if it has right children (the smallest node of the tree that is 
        // greater than the node passed to this function). 
        // Used in deletion to find the new node that will replace the node being deleted.
        private Node getSuccessor(Node node)
        {
            // A temporary node representing the successor.
            Node successor = null;

            if (node.rightNode != null)
            {
                // Traverse the right subtree to find the successor
                Node newNode = node.rightNode;
                while (newNode != null)
                {
                    // Set the successor to the new node (which isn't null)
                    successor = newNode;
                    // Get the left node of the new node (which may be null)
                    // This will step us through the right subtree until we're at the
                    // smallest left node (i.e. the successor)
                    newNode = newNode.leftNode;
                }
            }
            else
            {
                // No right subtree so find the right parent of the node which will be
                // the successor.
                successor = findRightParent(node);
            }
            return successor;
        }

        // Find the predecessor of the node (the largest node of the left subtree)
        private Node getPredecessor(Node node)
        {
            Node predecessor = null;

            if (node.leftNode != null)
            {
                // Traverse the left subtree and find the predecessor
                Node newNode = node.leftNode;
                while (newNode != null)
                {
                    predecessor = newNode;
                    // Get the right node of the new node (which may be null)
                    // This will step us through the left subtree until we're at the
                    // largest right node (i.e. the predecessor)
                    newNode = newNode.rightNode;
                }
            }
            else
            {
                // No left subtree so find the left parent of the node which will be the successor.
                predecessor = findLeftParent(node);
            }

            return predecessor;

        }

        // Get the right parent of the node. Used in deletion if the node has no children.
        private Node findRightParent(Node node)
        {
            // A temporary node representing the successor.
            Node successor = null;

            if (node.getParent() != null)
            {
                if (node.getParent().leftNode == node)
                {
                    // The successor's parent's left node is the same as the node
                    // So set the successor to the parent of the node we want to delete
                    successor = node.getParent();
                }
                else
                {
                    // Still haven't found the parent of the node we want to delete that 
                    // would be considered the successor so recursively call this function.
                    successor = findRightParent(node.getParent());
                }
            }

            return successor;
        }

        // Get the left parent of the node. Used in deletion if the node has no childen.
        private Node findLeftParent(Node node)
        {
            // A temporary node representing the predecessor.
            Node predecessor = null;

            if (node.getParent() != null)
            {
                if (node.getParent().rightNode == node)
                {
                    // The successor's parent's right node is the same as the node
                    // So set the predecessor to the parent of the node we want to delete
                    predecessor = node.getParent();
                }
                else
                {
                    // Still haven't found the parent of the ndoe we want to delete that
                    // would be considered the predecessor so recursively call this function.
                    predecessor = findLeftParent(node.getParent());
                }
            }

            return predecessor;
        }
    }
}
