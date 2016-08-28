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
            int inputNumber = 0;
            string inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out inputNumber))
            {
                // The input was a valid string integer representation and could be parsed.
                // Initialise our tree if it doesn't exist yet.
                if (tree == null)
                {
                    tree = new BinaryTree();
                }
                // Try and add the user's input to the tree as a new node. The addNode method returns true for a successful add and galse for a duplicate.
                if (tree.addNode(new Node(inputNumber)))
                {
                    // Successfully added the number to the tree.
                    Console.WriteLine("\nSuccessfully added {0} to the tree.\n", inputNumber);
                }
                else
                {
                    // Unsuccessfully added the number to the tree (i.e. it already exists).
                    Console.WriteLine("\nCouldn't add {0} to the tree as it already exists.\n", inputNumber);
                }
            }
            else
            {
                // The input couldn't be parsed into an int. Send a warning.
                Console.WriteLine("\nCouldn't get a number from the string ({0}) that you entered.\n", inputString);
            }
        }

        // The user wants to search for a node in the tree, this method handles all the actions and inputs associated with that.
        static void handleTreeSearch()
        {
            Console.WriteLine("Please enter a number you would like to find in the binary tree.");

            // Get the user's desired node.
            Console.Write("\nNumber to find: ");

            // Parse the user's input into an integer, otherwise return a warning.
            int searchNumber = 0;
            string inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out searchNumber))
            {
                // The input was a valid string integer representation and could be parsed.
                // If the tree is not null then try and search for the number
                if (tree != null)
                {
                    // Search for the node in the tree
                    Node searchNode = tree.findNode(searchNumber);

                    // If the node is not null then it was found. Notify the user.
                    if (searchNode != null)
                    {
                        Console.WriteLine("\n{0} was found in the binary tree.\n", searchNumber);
                    }
                    else
                    // the node didn't exist.
                    {
                        Console.WriteLine("\n{0} wasn't found in the binary tree, please try another number or print the tree to see what's in there.\n", searchNumber);
                    }
                }
            }
            else
            {
                // Couldn't parse the users choice into a valid number.
                Console.WriteLine("\nCouldn't get a number from the string ({0}) that you entered.\n", inputString);
            }
        }

        // The user wants to edit a node in the binary tree, this method handles all the action and inputs associated with that.
        static void handleEditingNode()
        {
            Console.WriteLine("Not ready to edit a node in the binary tree. To be completed.");
        }

        // The user wants to remove a node from the tree, this method handles all the actions and inputs associated with that.
        static void handleRemovingNode()
        {
            Console.WriteLine("Not ready to remove a node from the binary tree. To Be Completed");
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
    }
}
