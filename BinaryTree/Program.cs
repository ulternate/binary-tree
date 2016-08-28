using System;
using System.Threading;

namespace BinaryTree
{
    class Program
    {
        // Class variables.
        static string welcomeMessage = "Welcome to my Binary Tree implementation in C#. Please choose the operation you want to complete.\n";
        static string[] options = { "Add number to tree.", "Search for number in tree.", "Remove number from tree.", "View Tree", "Exit Program." };
        static bool repeat = true;

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
                    // User wishes to remove a node from the binary tree.
                    handleRemovingNode();
                    break;

                case "4":
                    // User wishes to display the binary tree.
                    printTree();
                    break;

                case "5":
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
            Console.WriteLine("Not ready to add node to binary tree. To Be Completed");
        }

        // The user wants to search for a node in the tree, this method handles all the actions and inputs associated with that.
        static void handleTreeSearch()
        {
            Console.WriteLine("Not ready to search for a node in the binary tree. To Be Completed");
        }

        // The user wants to remove a node from the tree, this method handles all the actions and inputs associated with that.
        static void handleRemovingNode()
        {
            Console.WriteLine("Not ready to remove a node from the binary tree. To Be Completed");
        }

        // The user wants to print/visualise the tree, this method will visualise the current tree for the user.
        static void printTree()
        {
            Console.WriteLine("Not ready to display the binary tree. To Be Completed");
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
