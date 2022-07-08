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
                        Console.WriteLine("\nInvalid option. Please try again.\n");
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
                    Console.WriteLine("Invalid option. Please try again.\n");
                    FindMenu();
                    break;
            }
         
        }

        public static void ResultMenu(int bookId, string bookName, string authorName, double bookCost, string bookLocation)
        {
            Console.Write("What would you like to do (Edit, Remove, Return to Main Menu): ");

            string menuSelection = Console.ReadLine();

            switch (menuSelection.ToLower())
            {
                case "edit":
                    Book.EditBook(bookId, bookName, authorName, bookCost, bookLocation);
                    break;
                case "remove":
                    Book.RemoveBook(bookId, bookName);
                    break;
                case "return":
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    ResultMenu(bookId, bookName, authorName, bookCost, bookLocation);
                    break;
            }
        }
        public static void RemoveChoiceMenu()
        {
            Console.Write("Are you sure you want to remove this book? (Y/N): ");

            string menuSelection = Console.ReadLine();

            switch (menuSelection.ToLower())
            {
                case "y":
                    break;
                case "n":
                    Primary();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    RemoveChoiceMenu();
                    break;
            }
        }

        public static void EditChoiceMenu(int bookId, string bookName, string authorName, double bookCost, string bookLocation)
        {
            Console.Write("What would you like to edit? (Title/Author/Cost/Location/All): ");

            string menuSelection = Console.ReadLine();

            switch (menuSelection.ToLower())
            {
                case "title":
                    Console.Write("What is the title of the book? ");
                    bookName = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "author":
                    Console.Write("Who is the author? ");
                    authorName = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "cost":
                    Console.Write("How much did the book cost? $");

                    bookCost = 0.0;

                    double.TryParse(Console.ReadLine(), out bookCost);

                    while (bookCost == 0.0)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.Write("How much did the book cost? $");
                        double.TryParse(Console.ReadLine(), out bookCost);
                    }
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "location":
                    Console.Write("Where is the book located? ");
                    bookLocation = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "all":
                    Console.Write("What is the title of the book? ");
                    bookName = Console.ReadLine();

                    Console.Write("Who is the author? ");
                    authorName = Console.ReadLine();

                    Console.Write("How much did the book cost? $");

                    bookCost = 0.0;

                    double.TryParse(Console.ReadLine(), out bookCost);

                    while (bookCost == 0.0)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        Console.Write("How much did the book cost? $");
                        double.TryParse(Console.ReadLine(), out bookCost);
                    }

                    Console.Write("Where is the book located? ");
                    bookLocation = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    EditChoiceMenu(bookId, bookName, authorName, bookCost, bookLocation);
                    break;
            }
        }
    }
}