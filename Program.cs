//using System;


//namespace Assignmnet_03
//{
//	internal class Program
//	{
//		static void Main(string[] args)
//		{
//			Greet("Assalam","Ali");
//		}

//		//------------optional arguments----------------


//		// a method named Greet with two optional parameters:

//		static void Greet(string greeting="Hello",string name="World")
//		{
//			Console.WriteLine($"{greeting}, {name}!");
//		}


//		// a method called CalculateArea for calculating the area of a rectangle

//		static double CalculateArea(double length=1.0,double width=1.0)
//		{
//			return length * width;
//		}


//		// Create two overloaded methods: AddNumbers.
//		static int AddNumbers(int a=0,int b=0){
//			return a + b;

//		}

//		static int AddNumbers(int a = 0, int b=0,int c = 0)
//		{
//			return a + b + c;
//		}



//	}
//}







using System;

namespace Assignment_03
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Choose an option:");
				Console.WriteLine("1. Greet");
				Console.WriteLine("2. Calculate Area");
				Console.WriteLine("3. Add Numbers");
				Console.WriteLine("4. Display Book Details");
				Console.WriteLine("5. Exit");

				// Read the user's choice
				int choice;
				if (!int.TryParse(Console.ReadLine(), out choice))
				{
					Console.WriteLine("Invalid input. Please enter a valid option.");
					continue;
				}

				switch (choice)
				{
					case 1:
						Console.Write("Enter a greeting (or press Enter for default): ");
						string greeting = Console.ReadLine();
						Console.Write("Enter a name (or press Enter for default): ");
						string name = Console.ReadLine();
						Greet(greeting, name);
						break;

					case 2:
						Console.Write("Enter length (or press Enter for default): ");
						double length;
						if (!double.TryParse(Console.ReadLine(), out length))
							length = 1.0;
						Console.Write("Enter width (or press Enter for default): ");
						double width;
						if (!double.TryParse(Console.ReadLine(), out width))
							width = 1.0;
						double area = CalculateArea(length, width);
						Console.WriteLine($"Area: {area}");
						break;

					case 3:
						Console.Write("Enter first number: ");
						int num1;
						if (!int.TryParse(Console.ReadLine(), out num1))
							num1 = 0;
						Console.Write("Enter second number: ");
						int num2;
						if (!int.TryParse(Console.ReadLine(), out num2))
							num2 = 0;
						Console.Write("Enter third number (or press Enter for default): ");
						int num3;
						if (!int.TryParse(Console.ReadLine(), out num3))
							num3 = 0;
						int sum = AddNumbers(num1, num2, num3);
						Console.WriteLine($"Sum: {sum}");
						break;

					case 4:
						Console.Write("Enter book title: ");
						string bookTitle = Console.ReadLine();
						Console.Write("Enter book author (or press Enter for default): ");
						string bookAuthor = Console.ReadLine();
						Book book = new Book(bookTitle, bookAuthor);
						book.Display();
						break;

					case 5:
						return;

					default:
						Console.WriteLine("Invalid option. Please select a valid option.");
						break;
				}
			}
		}

		// Define the Greet, CalculateArea, and AddNumbers methods here

		static void Greet(string greeting = "Hello", string name = "World")
		{
			Console.WriteLine($"{greeting}, {name}!");
		}

		static double CalculateArea(double length = 1.0, double width = 1.0)
		{
			return length * width;
		}

		static int AddNumbers(int a = 0, int b = 0, int c = 0)
		{
			return a + b + c;
		}
	}
}
