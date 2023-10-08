using System;

namespace Assignment_03
{
	internal class Book
	{
		// pascal case  names for properties
		public string Title { get; set; }
		public string Author { get; set; }

		// Constructor (make it public)
		public Book(string title, string author = "Unknown")
		{
			Title = title;
			Author = author;
		}

		// Display function (instance method)
		public void Display()
		{
			Console.WriteLine("Title: " + Title + ", Author: " + Author);
		}
	}
}
