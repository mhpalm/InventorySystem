using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Value { get; set; }
        public string Location { get; set; }

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
            Console.Write("What is the title of the book? ");
            string bookName = Console.ReadLine();
            Console.Write("Who is the author? ");
            string authorName = Console.ReadLine();
            Console.Write("How much did the book cost? ");
            double bookCost = int.Parse(Console.ReadLine());
            Console.Write("Where is the book located? ");
            string bookLocation = Console.ReadLine();

            Books.Add(new Book (Id, bookName, authorName, bookCost, bookLocation));

            Console.WriteLine($"ID: {Id}\nTitle: {bookName}\nAuthor: {authorName}\nValue: {bookCost}\nLocation: {bookLocation}\n");
            Id++;
        }
        public void List()
        {
            Console.Clear();
            foreach (Book book in Books)
            {
                Console.WriteLine($"ID: {Id}\nTitle: {book.Name}\nAuthor: {book.Author}\nValue: {book.Value}\nLocation: {book.Location}\n");
            }
            Console.ReadLine();
        }
    }
}
