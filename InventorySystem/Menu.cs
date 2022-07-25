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
                    case "a":
                        Book.AddBook();
                        break;
                    case "find":
                    case "f":
                        FindMenu();
                        break;
                    case "calculate":
                    case "c":
                        Book.Calculate();
                        break;
                    case "list":
                    case "l":
                        Book.List();
                        break;
                    case "quit":
                    case "q":
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
                case "t":
                    Book.FindByTitle();
                    break;
                case "author":
                case "a":
                    Book.FindByAuthor();
                    break;
                case "location":
                case "l":
                    Book.FindByLocation();
                    break;
                case "return":
                case "r":
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
                case "e":
                    Book.EditBook(bookId, bookName, authorName, bookCost, bookLocation);
                    break;
                case "remove":
                case "r":
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
                case "t":
                    Console.Write("What is the title of the book? ");
                    bookName = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "author":
                case "a":
                    Console.Write("Who is the author? ");
                    authorName = Console.ReadLine();
                    Book.AddBook(bookId, bookName, authorName, bookCost, bookLocation);
                    Console.WriteLine($"{bookName} has been successfully edited!");
                    break;
                case "cost":
                case "c":
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
                case "l":
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