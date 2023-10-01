

//using System;
//using System.Collections.Generic;

//namespace EAD_Assignment01
//{
//	class Passenger
//	{
//		public string Name { get; set; }
//		public string PhoneNo { get; set; }

//		public Passenger(string name, string phoneNo)
//		{
//			Name = name;
//			PhoneNo = phoneNo;
//		}

//		public int GiveRating()
//		{
//			Console.Write("\nGive Rating to this Ride out of 5: ");
//			Console.ForegroundColor = ConsoleColor.Green;
//			string ratingInput = Console.ReadLine();
//			Console.ResetColor();

//			int rating;
//			while (!int.TryParse(ratingInput, out rating) || rating < 1 || rating > 5)
//			{
//				Console.ForegroundColor = ConsoleColor.Green;
//				Console.Write("Invalid input. Please Enter a number between 1 and 5: ");
//				ratingInput = Console.ReadLine();
//				Console.ResetColor();
//			}

//			return rating;
//		}
//	}
//}



using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Passenger
	{
		public string name { get; set; }
		public string phoneNo { get; set; }

		public Passenger(string name, string phoneNo)
		{
			this.name = name;
			this.phoneNo = phoneNo;
		}
		public int giveRating()
		{
			Console.Write("\nGive Rating to this Ride out of 5: ");
			Console.ForegroundColor = ConsoleColor.Green;
			string rating = Console.ReadLine();
			Console.ResetColor();
			while (rating == "" || int.Parse(rating) < 1 || int.Parse(rating) > 5)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("Invalid input. Please Enter a number between 1 and 5: ");
				rating = Console.ReadLine();
				Console.ResetColor();
			}
			return int.Parse(rating);
		}
	}
}
