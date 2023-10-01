using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Driver
	{
		public int id;
		public string name;
		public int age;
		public string gender;
		public string address;
		public string phoneNo;
		public Location currLocation;
		public Vehicle vehicle;
		public List<int> rating;
		public bool availability;

		public Driver(int id, string name, int age, string gender, string address, string phoneNo, Location currLocation, Vehicle vehicle)
		{
			this.id = id;
			this.name = name;
			this.age = age;
			this.gender = gender;
			this.address = address;
			this.phoneNo = phoneNo;
			this.currLocation = currLocation;
			this.vehicle = vehicle;
			this.rating = new List<int>();
			this.availability = true;
		}

		public void updateAvailability()
		{
			Console.Write("Are you available for a ride? (yes/no): ");
			string input = ReadLineGreenPrompt();
			if (input.ToLower() == "yes")
			{
				availability = true;
			}
			else if (input.ToLower() == "no")
			{
				availability = false;
			}
		}

		public double getRating()
		{
			if (rating.Count == 0)
			{
				return 0;
			}
			int sum = 0;
			foreach (int r in rating)
			{
				sum += r;
			}
			return (double)sum / rating.Count;
		}
		public void setRating(int r)
		{
			rating.Add(r);
		}
		public Vehicle getVehicle() { return vehicle; }

		public void updateLocation()
		{
			Console.Write("Enter your current location (latitude longitude): ");
			string input = ReadLineGreenPrompt();
			string[] parts = input.Split(' ');
			float lat, lon;
			while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
			{
				Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
				input = ReadLineGreenPrompt();
				parts = input.Split(',');
			}
			currLocation = new Location(lat, lon);
		}
		static string ReadLineGreenPrompt()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			string userInput = Console.ReadLine();
			Console.ResetColor();
			return userInput;
		}
	}
}




