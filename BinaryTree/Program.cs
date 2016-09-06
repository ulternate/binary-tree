using System;
using System.Threading;
using System.Collections;


// Created: Daniel Swain
// Date: 28/08/2016
//
// The Program to allow a user to create a Binary Tree and add/remove nodes from it as well as print the nodes.

namespace BinaryTree
{
    class Program
    {
        // Class variables.
        static string welcomeMessage = "Welcome to my Binary Tree implementation in C#. Please choose the operation you want to complete.\n";
        static string[] options = { "Add number to tree.", "Search for number in tree.", "Edit a node in the tree", "Remove number from tree.", "View Tree", "Exit Program." };
        static bool repeat = true;
        static BinaryTree tree = null;

        static void Main(string[] args)
        {
            // Greet the user and display the program options for them until the user specifically chooses to exit the program.
            Console.WriteLine(welcomeMessage);
            // Loop the options forever until the user chooses to exit.
            while (repeat)
            {
                // Print the options for the user.
                printOptions();
                // Get and handle the input from the user.
                getInput();
            }
        }

        // Print the options for the user to pick from.
        static void printOptions()
        {
            int count = 1;
            foreach (string option in options)
            {
                Console.WriteLine("{0}: {1}", count, option);
                count++;
            }            
        }

        // Get the user's input choice and handle the input.
        static void getInput()
        {
            // Print out helper text to prompt the user for the input.
            Console.Write("\nChoice: ");
            string inputString = Console.ReadLine();
            // Print out a blank line for formatting.
            Console.WriteLine();
            
            // Parse the inputString to an int and handle the input.
            switch (inputString)
            {
                case "1":
                    // User wishes to add a node to the tree.
                    handleAddingOfNode();
                    break;

                case "2":
                    // User wishes to search for a node in the tree.
                    handleTreeSearch();
                    break;

                case "3":
                    // User wishes to edit a node from the binary tree.
                    handleEditingNode();
                    break;

                case "4":
                    // User wishes to remove a node from the binary tree.
                    handleRemovingNode();
                    break;

                case "5":
                    // User wishes to display the binary tree.
                    printTree();
                    break;

                case "6":
                    // User wishes to exit the program, show the choice and then exit the program by setting repeat to false.
                    exitProgram();
                    break;

                default:
                    // Unable to identify the users choice.
                    Console.WriteLine("Please enter a number representing the option you wish to complete.");
                    break;
            }
        }

        // The user wants to add a node to the tree, this method handles all the actions and inputs associated with that.
        static void handleAddingOfNode()
        {
            Console.WriteLine("Please enter a number you would like to add to the binary tree.");

            // Get the user's desired node data.
            Console.Write("\nNumber to add: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int usersKeyInput = parseUsersInputToInt(Console.ReadLine());
            // Get the user's data for the node as well
            Console.Write("\nData for the node: ");
            string usersNodeData = Console.ReadLine();

            if (usersKeyInput != -1)
            {
                // The input was a valid string integer representation and could be parsed.
                // Initialise our tree if it doesn't exist yet.
                if (tree == null)
                {
                    tree = new BinaryTree();
                }
                // Try and add the user's input to the tree as a new node. The addNode method returns true for a successful add and galse for a duplicate.
                if (tree.addNode(new Node(usersKeyInput, usersNodeData)))
                {
                    // Successfully added the number to the tree.
                    Console.WriteLine("\nSuccessfully added [{0}, \"{1}\"] to the tree.\n", usersKeyInput, usersNodeData);
                }
                else
                {
                    // Unsuccessfully added the number to the tree (i.e. it already exists).
                    Console.WriteLine("\nCouldn't add [{0}, \"{1}\"] to the tree as it already exists.\n", usersKeyInput, usersNodeData);
                }
            }
            else
            {
                // Couldn't parse the number into an int.
                Console.WriteLine("\nCouldn't get a valid number from what you entered.\n");
            }
        }

        // The user wants to search for a node in the tree, this method handles all the actions and inputs associated with that.
        static void handleTreeSearch()
        {
            Console.WriteLine("Please enter a number you would like to find in the binary tree.");

            // Get the user's desired node.
            Console.Write("\nNumber to find: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int usersInput = parseUsersInputToInt(Console.ReadLine());
            if (usersInput != -1)
            {
                if (tree != null)
                {
                    // Tree exists, so search for the node using the user's key and return a node (or null) if found or not.
                    Node searchNode = searchForNode(usersInput);
                    if (searchNode != null)
                    {
                        // Node was found so let the user know.
                        Console.WriteLine("\n[{0}, \"{1}\"] was found in the binary tree.\n", searchNode.value, searchNode.data);
                    }
                    else
                    {
                        // Unable to find the node or the binary tree doesn't exist, let the user node.
                        Console.WriteLine("\n{0} wasn't found in the binary tree, please try another number or print the tree to see what's in there.\n", usersInput);
                    }
                }
                else
                {
                    // No tree existed.
                    Console.WriteLine("\nNo tree exists yet, try adding a number first before searching for a number.");
                }
            }
            else
            {
                // Couldn't parse the number into an int.
                Console.WriteLine("\nCouldn't get a valid number from what you entered.\n");
            }
        }

        // The user wants to edit a node in the binary tree, this method handles all the action and inputs associated with that.
        static void handleEditingNode()
        {
            Console.WriteLine("Please enter the key of the node you wish to edit.");

            // Get the user's desired node.
            Console.Write("\nNumber to edit: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int usersInput = parseUsersInputToInt(Console.ReadLine());
            if (usersInput != -1)
            {
                if (tree != null)
                {
                    // Tree exists, so search for the node using the user's key and return a node (or null) if found or not.
                    Node searchNode = searchForNode(usersInput);
                    if (searchNode != null)
                    {
                        // Node was found, so let the user edit the data for the node.
                        Console.WriteLine("\nEditing [{0}, \"{1}\"].\n", searchNode.value, searchNode.data);

                        // Get the input for the new data.
                        Console.Write("\nEnter your new data for the node: ");
                        string newData = Console.ReadLine();

                        // Save the changes to the node
                        searchNode.data = newData;
                    }
                    else
                    {
                        // Unable to find the node or the binary tree doesn't exist, let the user node.
                        Console.WriteLine("\n{0} wasn't found in the binary tree, please try another number or print the tree to see what's in there.\n", usersInput);
                    }
                }
                else
                {
                    // No tree existed.
                    Console.WriteLine("\nNo tree exists yet, try adding a number first before searching for a number.");
                }
            }
            else
            {
                // Couldn't parse the number into an int.
                Console.WriteLine("\nCouldn't get a valid number from what you entered.\n");
            }
        }

        // The user wants to remove a node from the tree, this method handles all the actions and inputs associated with that.
        static void handleRemovingNode()
        {
            Console.WriteLine("Please enter the key of the node you wish to delete.");

            // Get the user's desired node.
            Console.Write("\nNumber to delete: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int usersInput = parseUsersInputToInt(Console.ReadLine());
            if (usersInput != -1)
            {
                if (tree != null)
                {
                    // Tree exists, so search for the node using the user's key and return a node (or null) if found or not.
                    Node deletedNode = searchForNode(usersInput);

                    if (deletedNode != null)
                    {
                        // Node was found so let's delete it.
                        bool status = tree.deleteNode(deletedNode);
                        if (status)
                        {
                            // Delete was successful.
                            Console.WriteLine("\nSuccessfully deleted [{0}, \"{1}\"] from the tree.\n", deletedNode.value, deletedNode.data);
                        }
                        else
                        {
                            // Delete failed.
                            Console.WriteLine("\nWas unsuccessful in deleting the node from the tree.");
                        }
                    }
                    else
                    {
                        // Unable to find the node or the binary tree doesn't exist, let the user node.
                        Console.WriteLine("\n{0} wasn't found in the binary tree, please try another number or print the tree to see what's in there.\n", usersInput);
                    }
                }
                else
                {
                    // No tree existed.
                    Console.WriteLine("\nNo tree exists yet, try adding a number first before searching for a number.");
                }
            }
            else
            {
                // Couldn't parse the number into an int.
                Console.WriteLine("\nCouldn't get a valid number from what you entered.\n");
            }
        }

        // The user wants to print/visualise the tree, this method will visualise the current tree for the user.
        static void printTree()
        {
            if (tree != null)
            {
                // Get the user's desired traversal method.
                Console.WriteLine("Please choose the desired tree traversal method.");
                Console.WriteLine("1. InOrder");
                Console.WriteLine("2. PreOrder.");
                Console.WriteLine("3. PostOrder.");
                Console.Write("\nMethod: ");
                int choice = -1;
                // Get the input from the user with their traversal choice.
                string traversalChoice = Console.ReadLine();
                // Parse it into a choice
                if ( Int32.TryParse(traversalChoice, out choice))
                {
                    // Use the BinaryTree traversal method to traverse and print the tree using the users choice.
                    tree.traverseAndPrintTree(choice);
                    // Print a blank line to the console to properly format the output before asking the user what to do again.
                    Console.WriteLine("\n");
                }
                else
                {
                    // The input couldn't be parsed into an int from the user's input.
                    Console.WriteLine("\nCouldn't get a number from the string ({0}) that you entered.\n", traversalChoice);
                }
            }
            else
            {
                Console.WriteLine("\nYou haven't initialised a binary tree, please add a number and try and view it again.\n");
            }
        }

        // The user has chosen to exit the program, handle this action in this method.
        static void exitProgram()
        {
            Console.WriteLine("Exiting...");
            // Use a delay to allow the application to notify the user.
            Thread.Sleep(1000);
            // Set the repeat variable to false so the while loop running the program will exit.
            repeat = false;
        }

        static Node searchForNode(int nodeKey)
        {
            // Search for a node in the tree.
            if (tree != null)
            {
                // Search for the node in the tree
                Node searchNode = tree.findNodeByKey(nodeKey);

                // If the node is not null then it was found. Notify the user.
                if (searchNode != null)
                {
                    return searchNode;
                }
                else
                // the node didn't exist.
                {
                    return null;
                }
            }
            else
            {
                // No tree existed.
                return null;
            }
        }

        // Helper class to parse the user's input and return an int if possible.
        static int parseUsersInputToInt(string inputString)
        {
            int inputNumber = 0;
            if (Int32.TryParse(inputString, out inputNumber))
            {
                // input string could be parsed to a number, return it to the calling method.
                return inputNumber;
            }
            else
            {
                // Input string couldn't be parsed to a number, return -1 to the calling method.
                return -1;
            }
        }
    }
}
