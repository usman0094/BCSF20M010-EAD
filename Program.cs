using Assignmnet_03;
using System;

namespace Assignment_03
{
	class Program
	{
		static void Main(string[] args)
		{
			MyList<int> intList = new MyList<int>();
			MyList<string> stringList = new MyList<string>();
			StudentDatabase studentDatabase = new StudentDatabase();

			DisplayMenu();
			while (true)
			{
				Console.WriteLine("---Enter the number of funtion---");
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
						Console.WriteLine("Integer List:");
						Console.WriteLine("---Adding elements--");
						intList.Add(1);
						intList.Add(14);
						intList.Add(7);
						intList.Add(36);
						intList.Add(33);
						intList.Display();
						Console.WriteLine("Removing 36,14,7");
						intList.Remove(7);
						intList.Remove(36);
						intList.Remove(14);
						intList.Display();
						break;
						

					case 6:
						// Swap integers
						int x = 5, y = 10;
						Console.WriteLine($"Before Swap: x = {x}, y = {y}");
						Swap(ref x, ref y);
						Console.WriteLine($"After Swap: x = {x}, y = {y}");

						// Swap strings
						string str1 = "Hello", str2 = "World";
						Console.WriteLine($"Before Swap: str1 = {str1}, str2 = {str2}");
						Swap(ref str1, ref str2);
						Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");

						// Swap doubles
						double number1 = 3.14, number2 = 2.71;
						Console.WriteLine($"Before Swap: num1 = {number1}, num2 = {number2}");
						Swap(ref number1, ref number2);
						Console.WriteLine($"After Swap: num1 = {number1}, num2 = {number2}");
						break;

					case 7:
						int[] intArray = { 1, 2, 3, 4, 5 };
						double[] doubleArray = { 1.5, 2.5, 3.5, 4.5, 5.5 };
						long[] longArray = { 100, 200, 300, 400, 500 };
						string[] stringArray = { "one", "two", "three" };

						int sumInt = Sum(intArray);
						double sumDouble = Sum(doubleArray);
						long sumLong = Sum(longArray);

						Console.WriteLine($"Sum of integers: {sumInt}");
						Console.WriteLine($"Sum of doubles: {sumDouble}");
						Console.WriteLine($"Sum of longs: {sumLong}");

						Console.ReadKey();
						break;

					case 8:
						Console.Write("Enter student ID to search: ");
						if (int.TryParse(Console.ReadLine(), out int searchID))
						{
							string studentName = studentDatabase.GetStudentName(searchID);
							Console.WriteLine($"Student Name: {studentName}");
						}
						else
						{
							Console.WriteLine("Invalid input. Please enter a valid student ID.");
						}
						break;

					case 9:
						Console.Write("Enter student ID to update: ");
						if (int.TryParse(Console.ReadLine(), out int updateID))
						{
							Console.Write("Enter new name: ");
							string newName = Console.ReadLine();
							studentDatabase.UpdateStudentName(updateID, newName);
						}
						else
						{
							Console.WriteLine("Invalid input. Please enter a valid student ID.");
						}
						break;

					case 10:
						return;

					default:
						Console.WriteLine("Invalid option. Please select a valid option.");
						break;
				}
			}
		}

		static void DisplayMenu()
		{
			Console.WriteLine("-------------------------------------------------------");
			Console.WriteLine("Choose an option:");
			Console.WriteLine("1. Greet");
			Console.WriteLine("2. Calculate Area");
			Console.WriteLine("3. Add Numbers");
			Console.WriteLine("4. Display Book Details");
			Console.WriteLine("5. A list of elements.");
			Console.WriteLine("6. Swapping two values of type T.");
			Console.WriteLine("7. Sum of elements in an array");
			Console.WriteLine("8. View Student Database");
			Console.WriteLine("9. Search for Student by ID");
			Console.WriteLine("10. Update Student Name");
			Console.WriteLine("11. Exit");
			Console.WriteLine("----------------------------------------------------------");
		}



		// Define the Greet, CalculateArea, and AddNumbers methods here

		static void Greet(string greeting = "Hello", string name = "World")
		{
			if (string.IsNullOrWhiteSpace(greeting))
			{
				greeting = "Hello";
			}
			if (string.IsNullOrWhiteSpace(name))
			{
				name = "World";
			}
			Console.WriteLine($"{greeting}, {name}!");
		}


		static double CalculateArea(double length = 1.0, double width = 1.0)
		{
			return length * width;
		}

		static int AddNumbers(int a, int b)
		{
			return a + b;
		}

		static int AddNumbers(int a, int b, int c = 0)
		{
			return a + b + c;
		}


		//----Generics ----

		//-- a generic method called Swap<T> 

		static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		//--sum of array 

		static T Sum<T>(T[] array)
		{
			if (array.Length == 0)
			{
				return default(T);
			}

			dynamic sum = array[0]; // Use dynamic for the sum to handle different numeric types

			for (int i = 1; i < array.Length; i++)
			{
				sum += array[i];
			}

			return sum;
		}



	}


}

