using System;

namespace Assignment_07
{


	// Example 1: Virtual Proxy for Image Loading

	// Subject
	public interface IImage
	{
		void Display();
	}

	// RealSubject
	public class RealImage : IImage
	{
		private string filename;

		public RealImage(string filename)
		{
			this.filename = filename;
			LoadImage();
		}

		private void LoadImage()
		{
			Console.WriteLine($"Loading image: {filename}");
		}

		public void Display()
		{
			Console.WriteLine($"Displaying image: {filename}");
		}
	}

	// Proxy
	public class ImageProxy : IImage
	{
		private RealImage realImage;
		private string filename;

		public ImageProxy(string filename)
		{
			this.filename = filename;
		}

		public void Display()
		{
			if (realImage == null)
			{
				realImage = new RealImage(filename);
			}
			realImage.Display();
		}
	}

	// Example 2: Protection Proxy for Bank Account Operations

	// Subject
	public interface IBankAccount
	{
		void Deposit(decimal amount);
		void Withdraw(decimal amount);
		decimal GetBalance();
	}

	// RealSubject
	public class RealBankAccount : IBankAccount
	{
		private decimal balance;

		public void Deposit(decimal amount)
		{
			balance += amount;
			Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
		}

		public void Withdraw(decimal amount)
		{
			if (balance >= amount)
			{
				balance -= amount;
				Console.WriteLine($"Withdrawn: {amount}. New balance: {balance}");
			}
			else
			{
				Console.WriteLine("Insufficient funds");
			}
		}

		public decimal GetBalance()
		{
			return balance;
		}
	}

	// Proxy
	public class BankAccountProxy : IBankAccount
	{
		private RealBankAccount realAccount;
		private string username;
		private string password;

		public BankAccountProxy(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		private bool AuthenticateUser()
		{
			// Simulate authentication logic
			return username == "authorized" && password == "password";
		}

		private void CheckAccess()
		{
			if (!AuthenticateUser())
			{
				Console.WriteLine("Unauthorized access. Authentication failed.");
				throw new UnauthorizedAccessException("Unauthorized access.");
			}
		}

		public void Deposit(decimal amount)
		{
			CheckAccess();
			if (realAccount == null)
			{
				realAccount = new RealBankAccount();
			}
			realAccount.Deposit(amount);
		}

		public void Withdraw(decimal amount)
		{
			CheckAccess();
			if (realAccount == null)
			{
				realAccount = new RealBankAccount();
			}
			realAccount.Withdraw(amount);
		}

		public decimal GetBalance()
		{
			CheckAccess();
			if (realAccount == null)
			{
				realAccount = new RealBankAccount();
			}
			return realAccount.GetBalance();
		}
	}

}