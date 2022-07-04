using System;

namespace InventorySystem
{
    public class Menu
    {
        private static Book Book = new Book();
        public static void Primary()
        {
            Book.Initialize();

            while (true)
            {
                Console.WriteLine(
                    "(Add) a new book\n" +
                    "(Find) a book\n" +
                    "(Calculate) total value of books\n" +
                    "(List) all books in library\n" +
                    "(Quit) Application\n");
                Console.Write("Select an option: ");

                string menuSelection = Console.ReadLine();

                switch (menuSelection.ToLower())
                {
                    case "add":
                        Book.AddBook();
                        break;
                    case "find":
                        FindMenu();
                        break;
                    case "calculate":
                        Book.Calculate();
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

        public static void FindMenu()
        {
            Console.WriteLine(
                "Search by (Title)\n" +
                "Search by (Author)\n" +
                "Search by (Location)\n" +
                "(Return) to Main Menu\n");
            Console.Write("Select an option: ");

            string menuSelection = Console.ReadLine();

            switch (menuSelection.ToLower())
            {
                case "title":
                    Book.FindByTitle();
                    break;
                case "author":
                    Book.FindByAuthor();
                    break;
                case "location":
                    Book.FindByLocation();
                    break;
                case "return":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again.\n");
                    FindMenu();
                    break;
            }
         
        }
    }
}