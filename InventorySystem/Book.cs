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
        public List<Book> Books = new List<Book>();

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
            Book[] bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            foreach (var book in bookJson)
            {
                Books.Add(book);
            }

            BookId = bookJson.Max(x => x.BookId);
        }

        public void AddBook()
        {
            Book book = new Book();
            BookId++;

            Console.Write("What is the title of the book? ");
            string bookName = Console.ReadLine();

            Console.Write("Who is the author? ");
            string authorName = Console.ReadLine();

            Console.Write("How much did the book cost? ");
            double bookCost = int.Parse(Console.ReadLine());

            Console.Write("Where is the book located? ");
            string bookLocation = Console.ReadLine();

            Books.Add(new Book(BookId, bookName, authorName, bookCost, bookLocation));

            Console.WriteLine($"{bookName} has been successfully added into the library!");

            var bookJson = JsonConvert.SerializeObject(Books);

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

            Console.ReadLine();
        }

        public void Calculate()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var sumValue = bookJson.Sum(x => x.BookCost);
            Console.WriteLine($"The total value of your library is currently {sumValue.ToString("C")}");
        }

        public void FindByTitle()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            Console.Write("What book title are you looking for? ");

            var desiredBook = Console.ReadLine().ToLower();

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
            }
        }
        public void FindByAuthor()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            Console.Write("What author are you looking for? ");

            var desiredBook = Console.ReadLine().ToLower();

            List<Book> findBook = new List<Book>(from book in bookJson
                           where book.BookAuthor.ToLower().Contains(desiredBook)
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
            }
        }
        public void FindByLocation()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            Console.Write("What location are you wanting to look in? ");

            var desiredBook = Console.ReadLine().ToLower();

            List<Book> findBook = new List<Book>(from book in bookJson
                                                 where book.BookLocation.ToLower().Contains(desiredBook)
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
            }

        }
    }
}