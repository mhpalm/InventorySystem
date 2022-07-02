using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace InventorySystem
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Value { get; set; }
        public string Location { get; set; }

        private string filePath = "bookdata.json";
        public List<string> records = new List<string>();

        public Book()
        {

        }

        public Book(int id, string name, string author, double value, string location)
        {
            Id = id;
            Name = name;
            Author = author;
            Value = value;
            Location = location;
        }
        public List<Book> Books = new List<Book>();
        
        public void Add()
        {
            var bookId = Id;

            Console.Write("What is the title of the book? ");
            string bookName = Console.ReadLine();

            Console.Write("Who is the author? ");
            string authorName = Console.ReadLine();
            
            Console.Write("How much did the book cost? ");
            double bookCost = int.Parse(Console.ReadLine());
            
            Console.Write("Where is the book located? ");
            string bookLocation = Console.ReadLine();

            Books.Add(new Book (bookId, bookName, authorName, bookCost, bookLocation));

            var fileData = new Book();
            {
                fileData.Id = bookId;
                fileData.Name = bookName;
                fileData.Author = authorName;
                fileData.Value = bookCost;
                fileData.Location = bookLocation;
            }
            /*
            object fileData = $"ID: {bookId}\r" +
                $"Title: {bookName}\r" +
                $"Author: {authorName}\r" +
                $"Value: {bookCost}\r" +
                $"Location: {bookLocation}\r";
            */
            Console.WriteLine(fileData);
            Id++;

            var bookJson = JsonConvert.SerializeObject(fileData);
            File.AppendAllText(filePath, bookJson);
            
            Console.WriteLine(bookJson);
            Console.ReadLine();
        }
        public void List()
        {

            Console.Clear();
            //List<Book> book = JsonConvert.DeserializeObject<Book>(filePath);
            
            records = File.ReadAllLines(filePath).ToList();

            foreach (String record in records)
            {
                Console.WriteLine(record);
            }

            /*
            foreach (Book book in Books)
            {
                Console.WriteLine($"ID: {book.Id}\nTitle: {book.Name}\nAuthor: {book.Author}\nValue: {book.Value}\nLocation: {book.Location}\n");
            }
            */
            Console.ReadLine();
        }
    }
}
