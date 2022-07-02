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
        public int BookId { get; private set; }
        [JsonProperty("Name")]
        public string BookName { get; set; }
        [JsonProperty("Author")]
        public string BookAuthor { get; set; }
        [JsonProperty("Value")]
        public double BookCost { get; set; }
        [JsonProperty("Location")]
        public string BookLocation { get; set; }

        private string filePath = "bookdata.json";
        public List<string> records = new List<string>();

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
        public List<Book> Books = new List<Book>();

        public void Add()
        {
            var bookId = BookId;

            Console.Write("What is the title of the book? ");
            string bookName = Console.ReadLine();

            Console.Write("Who is the author? ");
            string authorName = Console.ReadLine();

            Console.Write("How much did the book cost? ");
            double bookCost = int.Parse(Console.ReadLine());

            Console.Write("Where is the book located? ");
            string bookLocation = Console.ReadLine();

            Books.Add(new Book(bookId, bookName, authorName, bookCost, bookLocation));

            var fileData = new Book();
            {
                fileData.BookId = bookId;
                fileData.BookName = bookName;
                fileData.BookAuthor = authorName;
                fileData.BookCost = bookCost;
                fileData.BookLocation = bookLocation;
            }
            Console.WriteLine($"{bookName} has been successfully added into the library!");

            BookId++;

            var bookJson = JsonConvert.SerializeObject(fileData);
            File.AppendAllText(filePath, bookJson);

            Console.WriteLine(bookJson);
            Console.ReadLine();
        }
        public void List()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            foreach (var book in bookJson)
            {
                Console.WriteLine($"ID: {book.BookId}\nTitle: {book.BookName}\nAuthor: {book.BookAuthor}\nValue: {book.BookCost}\nLocation: {book.BookLocation}\n");
            }

            Console.ReadLine();
        }

        public void CalculateValue()
        {
            Console.Clear();

            var bookJson = JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(filePath));

            var sumValue = bookJson.Sum(x => x.BookCost);
            Console.WriteLine($"The total value of your library is currently ${sumValue}");
        }
    }
}