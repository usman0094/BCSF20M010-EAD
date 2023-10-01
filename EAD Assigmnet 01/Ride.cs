using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Ride
	{
		public Location startLocation;
		public Location endLocation;
		public int price;
		public Driver driver;
		public Passenger passenger;

		public Ride(Location stlocation, Location enlocation)
		{
			startLocation = stlocation;
			endLocation = enlocation;
		}

		public void assignPassenger(Passenger passenger)
		{
			Console.Write("\nEnter ‘yes’ if you want to Book the ride, enter ‘no’ if you want to cancel operation: ");
			string userDesire = ReadLineGreenPrompt();
			if (userDesire.ToLower() == "yes")
			{
				this.passenger = passenger;
				Console.WriteLine("\n------- Happy Travel....!! --------");
			}
			else if (userDesire.ToLower() == "no")
			{
				Console.WriteLine("\n------ See You Again....!! ----------");
			}
		}

		public Driver assignDriver(Admin admin)
		{
			List<Driver> availableDrivers = new List<Driver>();

			foreach (Driver driver in admin.Drivers)
			{
				if (driver.availability)
				{
					availableDrivers.Add(driver);
				}
			}

			Driver closestDriver = null;
			double closestDistance = double.MaxValue;
			foreach (Driver driver in availableDrivers)
			{
				double distance = driver.currLocation.CalculateDistance(startLocation);
				if (distance < closestDistance)
				{
					closestDriver = driver;
					closestDistance = distance;
				}
			}

			if (closestDriver != null)
			{
				closestDriver.availability = false;
				driver = closestDriver;
				return driver;
			}
			else
			{
				Console.WriteLine("\n----------- Sorry ! No available drivers found ---------------");
				return null;
			}
		}

		public void setLocations()
		{
			Console.Write("\nEnter the starting location (latitude longitude):");
			string input = ReadLineGreenPrompt();
			string[] parts = input.Split(' ');
			float lat, lon;
			while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
			{
				Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
				input = ReadLineGreenPrompt();
				parts = input.Split(' ');
			}
			startLocation = new Location(lat, lon);


			Console.Write("\nEnter the ending location (latitude longitude):");
			input = ReadLineGreenPrompt();
			parts = input.Split(' ');
			while (parts.Length != 2 || !float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon))
			{
				Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
				input = ReadLineGreenPrompt();
				parts = input.Split(' ');
			}
			endLocation = new Location(lat, lon);
		}

		public int calculatePrice(string vType)
		{
			double distance = startLocation.CalculateDistance(endLocation);
			double fuel_price = 250.43;
			double commission = 0.0;
			switch (vType)
			{
				case "bike":
					commission = 0.05;
					price = (int)((distance * fuel_price / 50) + (distance * fuel_price / 50) * commission);
					break;
				case "rickshaw":
					commission = 0.10;
					price = (int)((distance * fuel_price / 35) + (distance * fuel_price / 35) * commission);
					break;
				case "car":
					commission = 0.20;
					price = (int)((distance * fuel_price / 15) + (distance * fuel_price / 15) * commission);
					break;
			}
			return price;
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
