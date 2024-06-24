using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ListParser
    {
        static SinglyLinkedList list = new SinglyLinkedList();
        static string[] options =
        {
            "1. Print list." ,
            "2. Add a node.",
            "3. Remove a node.",
            "4. Clear list.",
            "5. Exit."
        };

        public static void Main()
        {
            Console.WriteLine("Hello World!");
            while(HandleInput(GatherInput()));
        }

        /// <summary>
        /// Prints the available program options and retrieves the user's selection.
        /// </summary>
        /// <returns>The user's selection.</returns>
        static int GatherInput()
        {
            Console.WriteLine("Please select an option:");
            Array.ForEach(options, Console.WriteLine);

            string line = Console.ReadLine() ?? string.Empty;
            try {
                int selection = int.Parse(line);
                if (selection < 1 || selection > options.Length) throw new ArgumentOutOfRangeException(nameof(selection));

                return selection;
            } catch
            {
                Console.WriteLine("Please input a valid number between 1 and " + options.Length + ".");
                return GatherInput();
            }
        }

        /// <summary>
        /// Performs an action based on a given selection.
        /// </summary>
        /// <param name="selection">User's action selection.</param>
        /// <returns>Whether to continue the program or not.</returns>
        static bool HandleInput(int selection)
        {
            switch (selection)
            {
                case 1:
                    PrintList();
                    break;
                case 2:
                    AddNode();
                    break;
                case 3:
                    RemoveNode();
                    break;
                case 4:
                    ClearList();
                    break;
                default:
                    return false;
            }

            Console.WriteLine("\n");
            return true;
        }

        #region Actions

        /// <summary>
        /// Calls the list to print itself.
        /// </summary>
        static void PrintList()
        {
            list.PrintList();
        }

        /// <summary>
        /// Gathers what node to add and calls the list to add it.
        /// </summary>
        static void AddNode()
        {
            Console.WriteLine("Please enter an integer to add.");
            try
            {
                int number = int.Parse(Console.ReadLine() ?? string.Empty);
                list.AddNode(number);
            }
            catch
            {
                Console.WriteLine("Invalid integer.");
            }
        }

        /// <summary>
        /// Gathers what node to remove and calls the list to remove it.
        /// </summary>
        static void RemoveNode()
        {
            Console.WriteLine("Please enter an integer to remove.");
            try
            {
                int number = int.Parse(Console.ReadLine() ?? string.Empty);
                list.RemoveNode(number);
            }
            catch
            {
                Console.WriteLine("Invalid integer.");
            }
        }

        /// <summary>
        /// Calls the list to clear itself.
        /// </summary>
        static void ClearList()
        {
            list.ClearList();
        }

        #endregion
    }
}
