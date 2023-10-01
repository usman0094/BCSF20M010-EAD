//using System;
//using System.Collections.Generic;

//namespace EAD_Assignmnet01
//{
//	class Admin
//	{
//		public List<Driver> Drivers;

//		public Admin()
//		{
//			Drivers = new List<Driver>();
//		}

//		public void AddDriver()
//		{
//			Console.Write("\nEnter Name: ");
//			string name = ReadLineGreenPrompt();
//			Console.Write("Enter Age: ");
//			string age = ReadLineGreenPrompt();
//			while (age == "")
//			{
//				Console.Write("Invalid Input,Again Enter Age: ");
//				age = ReadLineGreenPrompt();
//			}
//			Console.Write("Enter Gender: ");
//			string gender = ReadLineGreenPrompt();
//			Console.Write("Enter Address: ");
//			string address = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Type: ");
//			string vType = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Model: ");
//			string vModel = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle LicensePlate: ");
//			string vPlate = ReadLineGreenPrompt();
//			Console.Write("Enter Phone No: ");
//			string phone = ReadLineGreenPrompt();
//			Console.Write("Enter the starting location (latitude longitude): ");
//			string input = ReadLineGreenPrompt();
//			string[] parts = input.Split(' ');
//			float lat, lon;
//			while (parts.Length != 2 || (!float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon)))
//			{
//				Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
//				input = ReadLineGreenPrompt();
//				parts = input.Split(' ');
//			}
//			int id = Drivers.Count + 101;
//			Location DLocation = new Location(lat, lon);
//			Vehicle vehicle = new Vehicle(vType, vModel, vPlate);
//			Driver driver = new Driver(id, name, int.Parse(age), gender, address, phone, DLocation, vehicle);
//			Drivers.Add(driver);
//			Console.WriteLine("\n");
//			Console.WriteLine("".PadLeft(65, '-'));
//			Console.WriteLine($"| Driver with ID '{id}' and name '{name}' is added successfully...! |");
//			Console.WriteLine("".PadLeft(65, '-'));
//		}
//		//------------------------------------------------------------------------------
//		public void UpdateDriver(Driver driver)
//		{
//			Console.Write("\nEnter Name: ");
//			string name = ReadLineGreenPrompt();
//			Console.Write("Enter Age: ");
//			string age = ReadLineGreenPrompt();
//			Console.Write("Enter Gender: ");
//			string gender = ReadLineGreenPrompt();
//			Console.Write("Enter Address: ");
//			string address = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Type: ");
//			string vType = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Model: ");
//			string vModel = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle LicensePlate: ");
//			string vPlate = ReadLineGreenPrompt();
//			Console.Write("Enter Phone No: ");
//			string phone = ReadLineGreenPrompt();
//			if (name != "")
//			{
//				driver.name = name;
//			}
//			if (age != "")
//			{
//				driver.age = int.Parse(age);
//			}
//			if (gender != "")
//			{
//				driver.gender = gender;
//			}
//			if (address != "")
//			{
//				driver.address = address;
//			}
//			if (phone != "")
//			{
//				driver.phoneNo = phone;
//			}
//			if (vType != "")
//			{
//				driver.vehicle.type = vType;
//			}
//			if (vModel != "")
//			{
//				driver.vehicle.model = vModel;
//			}
//			if (vPlate != "")
//			{
//				driver.vehicle.licensePlate = vPlate;
//			}
//			Console.WriteLine("\n---------- Driver updated successfully --------------");
//		}
//		//------------------------------------------------------------------------------------
//		public void RemoveDriver(string id)
//		{
//			Driver driver = Drivers.Find(d => d.id == int.Parse(id));
//			if (driver == null)
//			{
//				Console.WriteLine("\n--------- There is no any Driver with this ID ---------");
//			}
//			else
//			{
//				Drivers.Remove(driver);
//				Console.WriteLine("\n------- Driver removed successfully....!! -----------");
//			}
//		}
//		//---------------------------------------------------------------------------------
//		public Driver CheckDriver(string id)
//		{
//			if (id != "")
//			{
//				Driver driver = Drivers.Find(d => d.id == int.Parse(id));
//				if (driver != null)
//				{
//					return driver;
//				}
//				else
//				{
//					return null;
//				}
//			}
//			return null;
//		}
//		//--------------------------------------------------------------------------------------------
//		public void SearchDriver(string id)
//		{
//			Console.Write("Enter Name: ");
//			string name = ReadLineGreenPrompt();
//			Console.Write("Enter Age: ");
//			string age = ReadLineGreenPrompt();
//			Console.Write("Enter Gender: ");
//			string gender = ReadLineGreenPrompt();
//			Console.Write("Enter Address: ");
//			string address = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Type: ");
//			string vType = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle Model: ");
//			string vModel = ReadLineGreenPrompt();
//			Console.Write("Enter Vehicle LicensePlate: ");
//			string vPlate = ReadLineGreenPrompt();
//			Console.Write("Enter Phone No: ");
//			string phone = ReadLineGreenPrompt();
//			Vehicle vehicle = new Vehicle(vType, vModel, vPlate);
//			List<Driver> results = new List<Driver>();
//			bool flag = true;
//			if (id != null && flag)
//			{
//				results = Drivers.FindAll(d => d.id == int.Parse(id));
//				flag = false;
//			}
//			if (vPlate != null && flag)
//			{
//				results = Drivers.FindAll(d => d.vehicle.licensePlate == vPlate);
//				flag = false;
//			}
//			// AS ID and flag is unique so there is only 1 result if that given , if it is not given ,then it can be multiple results.
//			if (name != null && flag)
//			{
//				results = Drivers.FindAll(d => d.name.ToLower().Contains(name.ToLower()));
//			}
//			if (age != null && flag)
//			{
//				results = Drivers.FindAll(d => d.age == int.Parse(age));
//			}
//			if (gender != null && flag)
//			{
//				results = Drivers.FindAll(d => d.gender == gender);
//			}
//			if (phone != null && flag)
//			{
//				results = Drivers.FindAll(d => d.phoneNo == phone);
//			}
//			if (vehicle.GetType() != null && flag)
//			{
//				results = Drivers.FindAll(d => d.vehicle.type == vType);
//			}
//			if (vehicle.model != null && flag)
//			{
//				results = Drivers.FindAll(d => d.vehicle.model == vModel);
//			}
//			if (results.Count == 0)
//			{
//				Console.WriteLine("--------- No results found ---------------");
//				return;
//			}
//			Console.WriteLine($"\n\t\t--------------- Search results for Driver with ID {id} ---------------------\n");
//			Console.WriteLine("Name\t\tAge\t\tGender\t\tV.Type\t\tV.Model\t\tV.License");
//			Console.WriteLine("--------------------------------------------------------------------------------------------------------");
//			foreach (Driver driver in results)
//			{
//				Console.WriteLine($"{driver.name}\t\t{driver.age}\t\t{driver.gender}\t\t{driver.vehicle.type}\t\t{driver.vehicle.model}\t\t{driver.vehicle.licensePlate}");
//			}
//			Console.WriteLine("--------------------------------------------------------------------------------------------------------\n");
//		}
//		//------------------------------------------------------------------
//		static string ReadLineGreenPrompt()
//		{
//			Console.ForegroundColor = ConsoleColor.Green;
//			string userInput = Console.ReadLine();
//			Console.ResetColor();
//			return userInput;
//		}
//	}
//}





using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Admin
	{
		public List<Driver> Drivers;

		public Admin()
		{
			Drivers = new List<Driver>();
		}

		public void AddDriver()
		{
			Console.Write("\nEnter Name: ");
			string name = ReadLineGreenPrompt();
			int age = ReadIntInput("Enter Age: ");
			Console.Write("Enter Gender: ");
			string gender = ReadLineGreenPrompt();
			Console.Write("Enter Address: ");
			string address = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Type: ");
			string vType = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Model: ");
			string vModel = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle LicensePlate: ");
			string vPlate = ReadLineGreenPrompt();
			Console.Write("Enter Phone No: ");
			string phone = ReadLineGreenPrompt();
			(float lat, float lon) = ReadLocation("Enter the starting location (latitude longitude): ");

			int id = Drivers.Count + 101;
			Location DLocation = new Location(lat, lon);
			Vehicle vehicle = new Vehicle(vType, vModel, vPlate);
			Driver driver = new Driver(id, name, age, gender, address, phone, DLocation, vehicle);
			Drivers.Add(driver);

			Console.WriteLine("\n".PadLeft(65, '-'));
			Console.WriteLine($"| Driver with ID '{id}' and name '{name}' is added successfully...! |");
			Console.WriteLine("".PadLeft(65, '-'));
		}

		public void UpdateDriver(Driver driver)
		{
			Console.Write("\nEnter Name: ");
			string name = ReadLineGreenPrompt();
			int age = ReadIntInput("Enter Age: ");
			Console.Write("Enter Gender: ");
			string gender = ReadLineGreenPrompt();
			Console.Write("Enter Address: ");
			string address = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Type: ");
			string vType = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Model: ");
			string vModel = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle LicensePlate: ");
			string vPlate = ReadLineGreenPrompt();
			Console.Write("Enter Phone No: ");
			string phone = ReadLineGreenPrompt();

			if (!string.IsNullOrEmpty(name))
				driver.name = name;
			if (age > 0)
				driver.age = age;
			if (!string.IsNullOrEmpty(gender))
				driver.gender = gender;
			if (!string.IsNullOrEmpty(address))
				driver.address = address;
			if (!string.IsNullOrEmpty(phone))
				driver.phoneNo = phone;
			if (!string.IsNullOrEmpty(vType))
				driver.vehicle.type = vType;
			if (!string.IsNullOrEmpty(vModel))
				driver.vehicle.model = vModel;
			if (!string.IsNullOrEmpty(vPlate))
				driver.vehicle.licensePlate = vPlate;

			Console.WriteLine("\n---------- Driver updated successfully --------------");
		}

		public void RemoveDriver(string id)
		{
			int driverId;
			if (int.TryParse(id, out driverId))
			{
				Driver driver = Drivers.Find(d => d.id == driverId);
				if (driver == null)
				{
					Console.WriteLine("\n--------- There is no any Driver with this ID ---------");
				}
				else
				{
					Drivers.Remove(driver);
					Console.WriteLine("\n------- Driver removed successfully....!! -----------");
				}
			}
			else
			{
				Console.WriteLine("\n--------- Invalid ID format ---------");
			}
		}

		public Driver CheckDriver(string id)
		{
			if (int.TryParse(id, out int driverId))
			{
				Driver driver = Drivers.Find(d => d.id == driverId);
				return driver;
			}
			return null;
		}

		public void SearchDriver(string id)
		{
			Console.Write("Enter Name: ");
			string name = ReadLineGreenPrompt();
			int age = ReadIntInput("Enter Age: ");
			Console.Write("Enter Gender: ");
			string gender = ReadLineGreenPrompt();
			Console.Write("Enter Address: ");
			string address = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Type: ");
			string vType = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle Model: ");
			string vModel = ReadLineGreenPrompt();
			Console.Write("Enter Vehicle LicensePlate: ");
			string vPlate = ReadLineGreenPrompt();
			Console.Write("Enter Phone No: ");
			string phone = ReadLineGreenPrompt();

			Vehicle vehicle = new Vehicle(vType, vModel, vPlate);

			List<Driver> results = Drivers.FindAll(driver =>
				(string.IsNullOrEmpty(id) || driver.id == int.Parse(id)) &&
				(string.IsNullOrEmpty(name) || driver.name.ToLower().Contains(name.ToLower())) &&
				(age == 0 || driver.age == age) &&
				(string.IsNullOrEmpty(gender) || driver.gender == gender) &&
				(string.IsNullOrEmpty(address) || driver.address == address) &&
				(string.IsNullOrEmpty(phone) || driver.phoneNo == phone) &&
				(string.IsNullOrEmpty(vType) || driver.vehicle.type == vType) &&
				(string.IsNullOrEmpty(vModel) || driver.vehicle.model == vModel) &&
				(string.IsNullOrEmpty(vPlate) || driver.vehicle.licensePlate == vPlate)
			);

			if (results.Count == 0)
			{
				Console.WriteLine("--------- No results found ---------------");
				return;
			}

			Console.WriteLine($"\n\t\t--------------- Search results for Driver with ID {id} ---------------------\n");
			Console.WriteLine("Name\t\tAge\t\tGender\t\tV.Type\t\tV.Model\t\tV.License");
			Console.WriteLine("--------------------------------------------------------------------------------------------------------");

			foreach (Driver driver in results)
			{
				Console.WriteLine($"{driver.name}\t\t{driver.age}\t\t{driver.gender}\t\t{driver.vehicle.type}\t\t{driver.vehicle.model}\t\t{driver.vehicle.licensePlate}");
			}

			Console.WriteLine("--------------------------------------------------------------------------------------------------------\n");
		}

		private static string ReadLineGreenPrompt()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			string userInput = Console.ReadLine();
			Console.ResetColor();
			return userInput;
		}

		private static int ReadIntInput(string prompt)
		{
			int value;
			do
			{
				Console.Write(prompt);
			} while (!int.TryParse(Console.ReadLine(), out value));
			return value;
		}

		private static (float, float) ReadLocation(string prompt)
		{
			Console.Write(prompt);
			string input = ReadLineGreenPrompt();
			string[] parts = input.Split(' ');
			float lat, lon;
			while (parts.Length != 2 || (!float.TryParse(parts[0], out lat) || !float.TryParse(parts[1], out lon)))
			{
				Console.Write("Invalid input. Please Enter Valid latitude and longitude - separated by a space: ");
				input = ReadLineGreenPrompt();
				parts = input.Split(' ');
			}
			return (lat, lon);
		}
	}
}
