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
        public string data;
        public Node leftNode;
        public Node rightNode;
        public Node parentNode;

        // Constructor for constructing a node in our binary tree. Initially set the left, right and parent nodes to null.
        public Node(int nodeValue, string nodeData)
        {
            value = nodeValue;
            data = nodeData;
            leftNode = null;
            rightNode = null;
            parentNode = null;
        }

        // Get the parent node
        public Node getParent()
        {
            return parentNode;
        }

        // Set the parent node
        public void setParent(Node parent)
        {
            parentNode = parent;
        }
    }
}
