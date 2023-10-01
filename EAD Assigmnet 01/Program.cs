using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EAD_Assignmnet01
{
	internal class MainProgram
	{
		static void Main(string[] args)
		{
			Admin admin = new Admin();
		start:
			StartApp();
			string choice = ReadLineGreenPrompt();
			int userChoice;
			while (!int.TryParse(choice, out userChoice))
			{
				Console.Write("Invalid input. Please Enter (1-4): ");
				choice = ReadLineGreenPrompt();
			}
			switch (userChoice)
			{
				//----------------------------------- CASE 1 : for book the ride -------------------------
				case 1:
					Console.Write("\nEnter Name: ");
					string name = ReadLineGreenPrompt();
					Console.Write("Enter Phone No: ");
					string phone = ReadLineGreenPrompt();
					Console.Write("Enter the starting location (latitude longitude):");
					string input = ReadLineGreenPrompt();
					string[] parts = input.Split(' ');
					float lat, lon;
					while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
					{
						Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
						input = ReadLineGreenPrompt();
						parts = input.Split(' ');
					}
					Location startLocation = new Location(lat, lon);

					Console.Write("Enter the ending location (latitude longitude):");
					input = ReadLineGreenPrompt();
					parts = input.Split(' ');
					while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
					{
						Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
						input = ReadLineGreenPrompt();
						parts = input.Split(' ');
					}
					Location endLocation = new Location(lat, lon);
					Console.Write("Enter Vehicle Type: ");
					string vType = ReadLineGreenPrompt();
					Console.WriteLine("\n--------------- THANK YOU --------------");

					Ride ride = new Ride(startLocation, endLocation);
					int price = ride.calculatePrice(vType.ToLower());
					Console.WriteLine($"\n(Price for this ride is : {price})");

					Driver d = ride.assignDriver(admin);
					if (d != null)
					{
						Passenger passenger = new Passenger(name, phone);
						ride.assignPassenger(passenger);
						d.setRating(passenger.giveRating());
					}
					else
					{
						Thread.Sleep(5000);
						goto start;
					}
					break;
				//---------------------------------- CASE: 2 for Driver Availabilty and Location Changing ---------------------
				case 2:
					Console.Write("\nEnter ID: ");
					string ID = ReadLineGreenPrompt();
					Console.Write("Enter Name: ");
					string DName = ReadLineGreenPrompt();
					Driver driver = admin.CheckDriver(ID);
					if (driver != null)
					{
						Console.WriteLine($"\n*** Hello {DName}!! ****");
						Console.Write("\nEnter Your Current location (latitude longitude):");
						input = ReadLineGreenPrompt();
						parts = input.Split(' ');
						while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
						{
							Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
							input = ReadLineGreenPrompt();
							parts = input.Split(' ');
						}
						Location DLocation = new Location(lat, lon);
						Console.Clear();
						Console.WriteLine("\n1. For Change the Availability");
						Console.WriteLine("2. For Change the Location");
						Console.WriteLine("3. Exit to Main Menu");
						Console.Write("\n-> Enter 1 to 3 to select an option: ");
						int DriverChoice = int.Parse(ReadLineGreenPrompt());
						if (DriverChoice == 1)
						{
							driver.updateAvailability();

						}
						else if (DriverChoice == 2)
						{
							driver.updateLocation();
						}
						goto start;
					}
					else
					{
						Console.WriteLine("\n----- Driver is not Registered ..!!!");
						Thread.Sleep(5000);
						goto start;
					}
					break;
				//--------------------------- CASE: 3 For Admin Functionalities ------------------------------
				case 3:
					Console.WriteLine("\n1. To Add Driver");
					Console.WriteLine("2. To Remove Driver");
					Console.WriteLine("3. To Update Driver");
					Console.WriteLine("4. To Search Driver");
					Console.WriteLine("5. Exit to Main Menu");
					Console.Write("\n-> Enter 1 to 5 to select an option: ");
					int AChoice = int.Parse(ReadLineGreenPrompt());
					if (AChoice == 1)
					{
						admin.AddDriver();
						goto case 3;
					}
					else if (AChoice == 2)
					{
						Console.Write("\nEnter Driver ID: ");
						ID = ReadLineGreenPrompt();
						admin.RemoveDriver(ID);
						goto case 3;
					}
					else if (AChoice == 3)
					{
						Console.Write("\nEnter Driver ID : ");
						ID = ReadLineGreenPrompt();
						Driver d2 = admin.CheckDriver(ID);
						if (d2 != null)
						{
							Console.WriteLine($"\n------ Driver with {ID} ID exists --------");
							admin.UpdateDriver(d2);
						}
						else
						{
							Console.WriteLine($"\n------ There is no any Driver with the {ID} ID exists --------");
						}
						goto case 3;
					}
					if (AChoice == 4)
					{
						Console.Write("\nEnter ID : ");
						ID = ReadLineGreenPrompt();
						admin.SearchDriver(ID);
						goto case 3;
					}
					else if (AChoice == 5)
					{
						goto start;
					}
					break;
				case 4:
				default:
					Environment.Exit(0);
					break;
			}
		}
		//-----------------------------------------------------------------------
		static void StartApp()
		{
			Console.Clear();
			Console.WriteLine("".PadLeft(105, '-'));
			Console.WriteLine("{0,60}", "WELCOME TO MYRIDE");
			Console.WriteLine("".PadLeft(105, '-'));
			Console.WriteLine("\n1. Book a Ride");
			Console.WriteLine("2. Enter as Driver");
			Console.WriteLine("3. Enter as Admin");
			Console.WriteLine("4. Exit");
			Console.Write("\n-> Enter 1 to 4 to select an option: ");
		}
		//------------------------------------------------------------------
		static string ReadLineGreenPrompt()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			string userInput = Console.ReadLine();
			Console.ResetColor();
			return userInput;
		}
	}
}
