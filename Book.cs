using System;
namespace Assignment_03
{

	internal class Book
	{
		// Pascal case names for properties
		public string Title { get; set; }
		public string Author { get; set; }

		// Constructor with optional author parameter
		public Book(string title, string author = "Unknown")
		{
			Title = title;
			Author = author;
		}

		// Display function (instance method)
		public void Display()
		{
			
		  Console.WriteLine("Title: " + Title + ", Author: " + (string.IsNullOrWhiteSpace(Author) ? "Unknown" : Author));
			

		}
	}

}