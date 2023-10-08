using System;
using System.Threading;
using System.Xml.Linq;

namespace Assigmnet_02
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("------------------------------functions---------------------------");

			DisplayMenu();
			while (true)
			{
				Console.WriteLine("Choose a function to run:");


				string userInput = Console.ReadLine();

				if (int.TryParse(userInput, out int choice))
				{
					switch (choice)
					{
						case 1:
							task1ConcatSName();
							break;
						case 2:
							substringFetch();
							break;
						case 3:
							stringInterpolation();
							break;
						case 4:
							arrayDeclarationAndInitialization();
							break;
						case 5:
							arrayIterationPartA();
							break;
						case 6:
							arrayIterationPartB();
							break;
						case 7:
							arraySum();
							break;
						case 8:
							maxValue();
							break;
						case 9:
							reverseArray();
							break;
						case 10:
							intBoxing();
							break;
						case 11:
							doubleBoxing();
							break;
						case 12:
							arrayUnboxing();
							break;
						case 13:
							MixedTypeListDemo();
							break;
						case 14:
							dynamicVariablesPartA();
							break;
						case 15:
							dynamicVariablesPartB();
							break;
						case 16:
							Console.WriteLine("Exiting. Goodbye!");
							return;
						default:
							Console.WriteLine("Invalid choice. Please enter a valid option.");
							break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a number.");
				}
			}
		}

		static void DisplayMenu()
		{
			Console.WriteLine("1. Task 1: Concatenate First and Last Names");
			Console.WriteLine("2. Task 2: Fetch Substring");
			Console.WriteLine("3. Task 3: String Interpolation");
			Console.WriteLine("4. Task 4: Array Declaration and Initialization");
			Console.WriteLine("5. Task 5a: Array Iteration Part A");
			Console.WriteLine("6. Task 5b: Array Iteration Part B");
			Console.WriteLine("7. Task 6: Sum of Array Elements");
			Console.WriteLine("8. Task 7: Finding the Maximum Value");
			Console.WriteLine("9. Task 8: Array Reversal");
			Console.WriteLine("10. Task 9a: Boxing - Integer");
			Console.WriteLine("11. Task 9b: Boxing - Double");
			Console.WriteLine("12. Task 10a: Unboxing with Array");
			Console.WriteLine("13. Task 10b: Unboxing with Generic List");
			Console.WriteLine("14. Task 11a: Dynamic Variables Part A");
			Console.WriteLine("15. Task 11b: Dynamic Variables Part B");
			Console.WriteLine("16. Exit");

			Console.WriteLine("---------------------------------------------------------");
		}


		//-----------------functions-----------------


		static void task1ConcatSName()   // task 01
		{
			string firstName;
			string lastName;

			Console.Write("first name:");
			firstName = Console.ReadLine();

			Console.Write("Last name:");
			lastName = Console.ReadLine();

			string fullName = string.Concat(firstName, " ", lastName);

			Console.WriteLine("Full Name :" + fullName);
		}

		//-----------------task 02------------------

		static void substringFetch()
		{
			string sentence;
			int length;

			while (true)
			{
				Console.WriteLine("Enter a sentence:");
				sentence = Console.ReadLine();

				try
				{
					length = sentence.Length;

					if (length < 5)
					{
						throw new ArgumentException("Sentence is too short. Please enter a sentence with at least 5 characters.");
					}

					break;
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			//int start = length - 5;

			//for (int i = start; i < length; i++)
			//{
			//	Console.Write(sentence[i]);
			//}
			string lastFiveCharacters = sentence.Substring(length - 5);
			Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
		}


		//-----------------task 03-------------------

		static void stringInterpolation()
		{
			double temperature;
			string city = null;

			Console.WriteLine("Enter the temperature in your City:");
			string temperatureInput = Console.ReadLine();

			if (double.TryParse(temperatureInput, out temperature))
			{
				Console.WriteLine("Enter your city:");
				city = Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Invalid input for temperature. Please enter a valid number.");
			}

			Console.WriteLine($"The temperature in {city}  is {temperature} degree Celsius.");
		}



		//-----------------------task 04--------------------

		static void arrayDeclarationAndInitialization()
		{
			int[] number = { 1, 2, 3, 4, 5 };
			for (int i = 0; i < number.Length; i++)
			{
				Console.WriteLine(number[i]);
			}
		}




		//------------task 05------------------


		// A part


		static void arrayIterationPartA()
		{
			string[] fruits = { "banana", "Mango", "Grapes", "Berries", "Blueberries", "Raspberries", "Strawberries" };

			for (int i = 0; i < fruits.Length; i++)
			{
				Console.WriteLine(fruits[i]);
			}
		}


		//B part

		static void arrayIterationPartB()
		{
			string[] colors = { "red", "blue", "green", "white", "black", "yellow" };

			foreach (string color in colors)
			{
				Console.WriteLine(color);
			}

		}


		//---------task 6-----------


		static void arraySum()
		{
			int[] scores = { 23, 34, 34, 243, 234, 334, 233, 234, 22, 24 };
			int sum = 0;
			int index = 0;
			do
			{

				sum += scores[index];
				index++;

			}
			while (index < scores.Length);

			Console.WriteLine("The sum of scores is: " + sum);
		}

		//--------------task 7--------------

		static void maxValue()
		{
			int[] values = { 23, 34, 34, 243, 242, 334, 233, 234, 543 };
			int maxValue = values[0];

			int i = 0;

			while (i < values.Length)
			{
				if (values[i] > maxValue)

				{
					maxValue = values[i];

				}
				i++;
			}
			Console.WriteLine("Max Number is :" + maxValue);
		}


		//-----task 8------------------



		static void reverseArray()
		{
			int[] numbers = { 23, 34, 34, 243, 234, 334 };

			int start = 0;
			int end = numbers.Length - 1;

			Console.WriteLine("Original Array:");
			foreach (int number in numbers)
			{
				Console.Write(number + " ");
			}
			Console.WriteLine();

			while (start < end)
			{

				int temp = numbers[start];
				numbers[start] = numbers[end];
				numbers[end] = temp;


				start++;
				end--;
			}

			Console.WriteLine("Reversed Array:");
			foreach (int number in numbers)
			{
				Console.Write(number + " ");
			}
			Console.WriteLine();
		}


		//------task9-----


		// int boxing
		static void intBoxing()
		{
			int x = 42;

			object value = x; //boxing

			int y = (int)value;// unboxing

			Console.WriteLine("The value of 'y' is: " + y);
		}


		//double boxing
		static void doubleBoxing()
		{
			double doubleValue = 3.14159;

			object boxedValue = doubleValue; //boxing

			double unboxedValue = (double)boxedValue; //unboxing

			Console.WriteLine("The value of 'unboxedValue' is: " + unboxedValue);
		}



		//--------task10--------

		static void arrayUnboxing()
		{
			int[] numbers = { 11, 2, 3, 4 };

			for (int i = 0; i < numbers.Length; i++)
			{
				object boxedValue = numbers[i];//boxing

				int unboxedValue = (int)boxedValue; //unboxing
				int squre = unboxedValue * unboxedValue;
				Console.WriteLine("Orginal interger is :" + numbers[i] + " its squre value is:" + squre);

			}
		}

		static void MixedTypeListDemo()
		{

			List<object> mixedList = new List<object>();


			mixedList.Add((object)42);          // Boxing an int
			mixedList.Add((object)3.14159);     // Boxing a double
			mixedList.Add((object)'A');         // Boxing a char
			mixedList.Add((object)"Hello");     // Boxing a string


			foreach (object item in mixedList)
			{
				Type itemType = item.GetType();


				if (itemType == typeof(int))
				{
					int intValue = (int)item;
					Console.WriteLine($"Value: {intValue}, Type: {itemType}");
				}
				else if (itemType == typeof(double))
				{
					double doubleValue = (double)item;
					Console.WriteLine($"Value: {doubleValue}, Type: {itemType}");
				}
				else if (itemType == typeof(char))
				{
					char charValue = (char)item;
					Console.WriteLine($"Value: {charValue}, Type: {itemType}");
				}
				else if (itemType == typeof(string))
				{
					string stringValue = (string)item;
					Console.WriteLine($"Value: {stringValue}, Type: {itemType}");
				}
			}

		}

		//----task 11--------



		// part A
		static void dynamicVariablesPartA()
		{
			dynamic myVariable = 42;

			Console.WriteLine("Value of dynamicVarible is :" + myVariable);

			myVariable = "Hello, Dynamic!";

			Console.WriteLine("Now the Value of dynamicVarible is :" + myVariable);
		}


		//part B
		static void dynamicVariablesPartB()
		{
			dynamic myVariable2;


			myVariable2 = 42;
			Console.WriteLine("Type of myVariable2 after assigning an integer: " + myVariable2.GetType());


			myVariable2 = 3.14159;
			Console.WriteLine("Type of myVariable2 after assigning a double: " + myVariable2.GetType());


			myVariable2 = DateTime.Now;
			Console.WriteLine("Type of myVariable2 after assigning a DateTime: " + myVariable2.GetType());


			myVariable2 = "Hello, Dynamic!";
			Console.WriteLine("Type of myVariable2 after assigning a string: " + myVariable2.GetType());
		}

	}

}
