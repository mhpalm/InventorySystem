using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Centralized Book System!\n");

            MainMenu();
        }

        public static void MainMenu()
        {
            Book Book = new Book();

            while (true)
            {
                Console.WriteLine("(Add) a new book\n" +
                    "(Find) a book\n" +
                    "(Calculate) total value of books\n" +
                    "(List) all books in library\n" +
                    "(Quit) Application\n");
                Console.Write("Select an option: ");

                string menuSelection = Console.ReadLine();

                switch (menuSelection.ToLower())
                {
                    case "add":
                        Book.Add();
                        break;
                    case "find":
                        //Book.find();
                        break;
                    case "calculate":
                        Book.CalculateValue();
                        break;
                    case "list":
                        Book.List();
                        break;
                    case "quit":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
