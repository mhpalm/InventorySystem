using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace InventorySystem
{
    [Serializable]
    public class Book
    {
        [JsonProperty("Id")]
        private int BookId { get; set; }
        [JsonProperty("Name")]
        public string BookName { get; set; }
        [JsonProperty("Author")]
        public string BookAuthor { get; set; }
        [JsonProperty("Value")]
        public double BookCost { get; set; }
        [JsonProperty("Location")]
        public string BookLocation { get; set; }
        private string filePath = "bookdata.json";
        private List<Book> BookList = new List<Book>();

        public Book()
        {

        }

        public Book(int id, string name, string author, double value, string location)
        {
            BookId = id;
            BookName = name;
            BookAuthor = author;
            BookCost = value;
            BookLocation = location;
        }

        public void Initialize()
        {
            if (File.Exists(filePath))
            {
                Book[] bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

                foreach (var book in bookJson)
                {
                    BookList.Add(book);
                }

                BookId = bookJson.Max(x => x.BookId);
            }

            else
            {

                //Populate the bookdata.json file with example data
                BookList.Add(new Book(1, "War and Peace", "Leo Tolstoy", 34.25, "Hallway"));
                BookList.Add(new Book(2, "Waiting for Godot", "Samuel Beckett", 5.5, "Living Room"));
                BookList.Add(new Book(3, "Ulysses", "James Joyce", 12.0, "Study"));
                BookList.Add(new Book(4, "The Wealth of Nations", "Adam Smith", 43.5, "Bedroom"));
                BookList.Add(new Book(5, "The Tale of Genji", "Murasaki Shikibu", 48.75, "Study"));
                BookList.Add(new Book(6, "The Stories of Anton Chekhov", "Anton Chekhov", 36.25, "Study"));
                BookList.Add(new Book(7, "The Social Contract", "Jean-Jacques Rousseau", 48.0, "Living Room"));
                BookList.Add(new Book(8, "The Republic", "Plato", 10.0, "Study"));
                BookList.Add(new Book(9, "The Quran", "Various Authors", 33.25, "Hallway"));
                BookList.Add(new Book(10, "The Prince", "Niccolo Machiavelli", 19.75, "Bedroom"));
                BookList.Add(new Book(11, "The Portrait of a Lady", "Henry James", 49.5, "Living Room"));
                BookList.Add(new Book(12, "The Odyssey", "Homer", 41.25, "Bedroom"));
                BookList.Add(new Book(13, "The Interpretation of Dreams", "Sigmund Freud", 41.0, "Hallway"));
                BookList.Add(new Book(14, "The Iliad", "Homer", 28.5, "Office"));
                BookList.Add(new Book(15, "The Histories of Herodotus", "Herodotus", 16.75, "Bedroom"));
                BookList.Add(new Book(16, "The Great Gatsby", "F. Scott Fitzgerald", 23.5, "Living Room"));
                BookList.Add(new Book(17, "The Divine Comedy", "Dante Alighieri", 6.0, "Study"));
                BookList.Add(new Book(18, "The Complete Stories of Franz Kafka", "Franz Kafka", 34.75, "Study"));
                BookList.Add(new Book(19, "The Brothers Karamazov", "Fyodor Dostoyevsky", 9.0, "Bedroom"));
                BookList.Add(new Book(20, "The Bible", "Christian Church", 14.25, "Study"));
                BookList.Add(new Book(21, "The Adventures of Huckleberry Finn", "Mark Twain", 20.5, "Study"));
                BookList.Add(new Book(22, "Silent Spring", "Rachel Carson", 9.0, "Office"));
                BookList.Add(new Book(23, "Principia Mathematica", "Issac Newton", 8.5, "Office"));
                BookList.Add(new Book(24, "Pride and Prejudice", "Jane Austen", 17.25, "Hallway"));
                BookList.Add(new Book(25, "Our Mutual Friend", "Charles Dickens", 24.5, "Hallway"));
                BookList.Add(new Book(26, "One Hundred Years of Solitude", "Gabriel Garcia Marquez", 41.75, "Bedroom"));
                BookList.Add(new Book(27, "The Lord of the Rings", "J. R. R. Tolkien", 50.0, "Study"));
                BookList.Add(new Book(28, "Oedipus the King", "Sophocles", 24.25, "Living Room"));
                BookList.Add(new Book(29, "Oedipus at Colonus", "Sophocles", 39.25, "Office"));
                BookList.Add(new Book(30, "Moby Dick", "Herman Melville", 38.5, "Living Room"));
                BookList.Add(new Book(31, "Middlemarch", "George Eliot", 9.75, "Bedroom"));
                BookList.Add(new Book(32, "Mahabharata", "Vyasa", 29.75, "Study"));
                BookList.Add(new Book(33, "Madame Bovary", "Gustave Flaubert", 48.0, "Bedroom"));
                BookList.Add(new Book(34, "Lolita", "Vladimir Nabokov", 49.25, "Bedroom"));
                BookList.Add(new Book(35, "King Lear", "William Shakespeare", 7.5, "Living Room"));
                BookList.Add(new Book(36, "In Search of Lost Time", "Marcel Proust", 9.0, "Study"));
                BookList.Add(new Book(37, "Gulliver's Travels", "Jonathan Swift", 36.0, "Study"));
                BookList.Add(new Book(38, "Faust", "Johann Wolfgang von Goethe", 50.0, "Hallway"));
                BookList.Add(new Book(39, "Essays", "Michel de Montaigne", 35.5, "Living Room"));
                BookList.Add(new Book(40, "Encyclopédie", "Denis Diderot", 36.0, "Study"));
                BookList.Add(new Book(41, "Don Quixote", "Miguel de Cervantes", 11.0, "Office"));
                BookList.Add(new Book(42, "Dialogue Concerning the Two Chief World Systems", "Galileo", 44.0, "Office"));
                BookList.Add(new Book(43, "Decameron", "Giovanni Boccaccio", 28.0, "Living Room"));
                BookList.Add(new Book(44, "Das Kapital", "Karl Marx", 50.5, "Bedroom"));
                BookList.Add(new Book(45, "The Lion, the Witch, and the Wardrobe", "C. S. Lewis", 27.25, "Living Room"));
                BookList.Add(new Book(46, "Confessions", "Augustine", 45.75, "Office"));
                BookList.Add(new Book(47, "Collected Poems of W. B. Yeats", "W. B. Yeats", 33.0, "Bedroom"));
                BookList.Add(new Book(48, "Collected Poems of T.S. Eliot", "T. S. Eliot", 23.0, "Office"));
                BookList.Add(new Book(49, "Antigone", "Sophocles", 31.75, "Bedroom"));
                BookList.Add(new Book(50, "Alice's Adventures in Wonderland", "Lewis Carroll", 25.0, "Study"));
                BookId = BookList.Count();

                var bookJson = JsonConvert.SerializeObject(BookList);

                File.WriteAllText(filePath, bookJson);
            }
        }

        public void AddBook()
        {
            Book book = new Book();

            BookId++;

            Console.Write("What is the title of the book? ");
            string bookName = Console.ReadLine();

            Console.Write("Who is the author? ");
            string authorName = Console.ReadLine();

            Console.Write("How much did the book cost? $");

            double bookCost = 0.0;

            double.TryParse(Console.ReadLine(), out bookCost);

            while (bookCost == 0.0)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("How much did the book cost? $");
                double.TryParse(Console.ReadLine(), out bookCost);
            }
            
            Console.Write("Where is the book located? ");
            string bookLocation = Console.ReadLine();

            BookList.Add(new Book(BookId, bookName, authorName, bookCost, bookLocation));

            Console.WriteLine($"{bookName} has been successfully added into the library!");

            var bookJson = JsonConvert.SerializeObject(BookList);

            File.WriteAllText(filePath, bookJson);
        }

        public void AddBook(int bookId, string bookName, string authorName, double bookCost, string bookLocation)
        {
            Book book = new Book();

            BookList.Add(new Book(bookId, bookName, authorName, bookCost, bookLocation));

            var bookJson = JsonConvert.SerializeObject(BookList);

            File.WriteAllText(filePath, bookJson);
        }

        public void List()
        {
            Console.Clear();
            
            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));
            
            foreach (var book in bookJson)
            {
                Console.WriteLine($"ID: {book.BookId}\nTitle: {book.BookName}\nAuthor: {book.BookAuthor}\nValue: {book.BookCost.ToString("C")}\nLocation: {book.BookLocation}\n");
            }
        }

        public void Calculate()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var sumValue = bookJson.Sum(x => x.BookCost);

            Console.WriteLine($"There are {bookJson.Length} books in the library.\nThe total value is currently {sumValue.ToString("C")}\n\n");
        }

        public void FindByTitle()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            Console.Write("What book title are you looking for? ");

            var desiredBook = Console.ReadLine().ToLower();
            int bookId = 0;
            string bookName = "";
            string authorName = "";
            double bookCost = 0.0;
            string bookLocation = "";

            List<Book> findBook = new List<Book>(from book in bookJson
                                                 where book.BookName.ToLower().Contains(desiredBook)
                                                 orderby book.BookId ascending
                                                 select book);

            foreach (var b in findBook)
            {
                Console.WriteLine(
                    $"ID: {b.BookId}\n" +
                    $"Title: {b.BookName}\n" +
                    $"Author: {b.BookAuthor}\n" +
                    $"Cost: {b.BookCost.ToString("C")}\n" +
                    $"Location: {b.BookLocation}\n");
                bookId = b.BookId;
                bookName = b.BookName;
                authorName = b.BookAuthor;
                bookCost = b.BookCost;
                bookLocation = b.BookLocation;
            }

            Menu.ResultMenu(bookId, bookName, authorName, bookCost, bookLocation);
        }
        public void FindByAuthor()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var bookCount = 0;
            int bookId = 0;
            string bookName = "";
            string authorName = "";
            double bookCost = 0.0;
            string bookLocation = "";

            while (bookCount == 0)
            {
                Console.Write("What author are you looking for? ");

                var desiredBook = Console.ReadLine().ToLower();

                List<Book> findBook = new List<Book>(from book in bookJson
                                                     where book.BookAuthor.ToLower().Contains(desiredBook)
                                                     orderby book.BookId ascending
                                                     select book);
                if (findBook.Count == 0)
                {
                    Console.WriteLine("There are currently no books in the library by that author.\nIf you have a book by that author, please return to the main menu and add it in.\n");
                }
                else
                {
                    bookCount = findBook.Count;

                    foreach (var b in findBook)
                    {
                        Console.WriteLine(
                            $"ID: {b.BookId}\n" +
                            $"Title: {b.BookName}\n" +
                            $"Author: {b.BookAuthor}\n" +
                            $"Cost: {b.BookCost.ToString("C")}\n" +
                            $"Location: {b.BookLocation}\n");
                        bookId = b.BookId;
                        bookName = b.BookName;
                        authorName = b.BookAuthor;
                        bookCost = b.BookCost;
                        bookLocation = b.BookLocation;
                    }
                }
            };

            Menu.ResultMenu(bookId, bookName, authorName, bookCost, bookLocation);
        }
        public void FindByLocation()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var bookCount = 0;
            int bookId = 0;
            string bookName = "";
            string authorName = "";
            double bookCost = 0.0;
            string bookLocation = "";

            while (bookCount == 0)
            {
                Console.Write("What location are you wanting to look in? ");

                var desiredBook = Console.ReadLine().ToLower();

                List<Book> findBook = new List<Book>(from book in bookJson
                                                     where book.BookLocation.ToLower().Contains(desiredBook)
                                                     orderby book.BookId ascending
                                                     select book);
                if (findBook.Count == 0)
                {
                    Console.WriteLine("There are currently no books in that location.\nIf you have a book in that location, please return to the main menu and add it in.\n");
                }
                else
                {
                    bookCount = findBook.Count;

                    foreach (var b in findBook)
                    {
                        Console.WriteLine(
                            $"ID: {b.BookId}\n" +
                            $"Title: {b.BookName}\n" +
                            $"Author: {b.BookAuthor}\n" +
                            $"Cost: {b.BookCost.ToString("C")}\n" +
                            $"Location: {b.BookLocation}\n");

                        bookId = b.BookId;
                        bookName = b.BookName;
                        authorName = b.BookAuthor;
                        bookCost = b.BookCost;
                        bookLocation = b.BookLocation;
                    }
                }
            };

            Menu.ResultMenu(bookId, bookName, authorName, bookCost, bookLocation);
        }

        public void RemoveBook(int bookId, string bookName)
        {
            Menu.RemoveChoiceMenu();

            var removeBook = BookList.SingleOrDefault(x => x.BookId == bookId);
            if (removeBook != null)
                BookList.Remove(removeBook);
            
            var bookJsonNew = JsonConvert.SerializeObject(BookList);

            Console.WriteLine($"{bookName} has been successfully removed from the library!");

            File.WriteAllText(filePath, bookJsonNew);
        }
        
        public void EditBook(int bookId, string bookName, string authorName, double bookCost, string bookLocation)
        {
            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var editBook = BookList.SingleOrDefault(x => x.BookId == bookId);
            if (editBook != null)
                BookList.Remove(editBook);

            if (BookList.Count > 1)
            {
                Console.WriteLine("There is more than one option available. Which book would you like?");
                foreach (var book in BookList)
                {
                    Console.WriteLine(book.BookName);
                }
            }

            Menu.EditChoiceMenu(bookId, bookName, authorName, bookCost, bookLocation);

            var bookJsonEdited = JsonConvert.SerializeObject(BookList);

            File.WriteAllText(filePath, bookJsonEdited);
        }
    }
}