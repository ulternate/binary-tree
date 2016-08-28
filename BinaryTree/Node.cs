// Created: Daniel Swain
// Date: 28/08/2016
// 
// Custom object representing a single Node in the BinaryTree.


namespace BinaryTree
{
    class Node
    {
        // Node properties
        public int value;
        public Node leftNode;
        public Node rightNode;

        // Constructor for constructing a node in our binary tree. Initially set the left and right nodes to null.
        public Node(int nodeValue)
        {
            value = nodeValue;
            leftNode = null;
            rightNode = null;
        }
    }
}
