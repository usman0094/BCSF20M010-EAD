using System;

namespace Assignment_06
{

	// ----------------------------------------- ( EXAMPLE 01 ) -------------------------

	// Product Interface
	public interface IAnimal
	{
		void Speak();
	}

	// Concrete Products
	public class Dog : IAnimal
	{
		public void Speak()
		{
			Console.WriteLine("Dog says: Woof!");
		}
	}

	public class Cat : IAnimal
	{
		public void Speak()
		{
			Console.WriteLine("Cat says: Meow!");
		}
	}

	// Creator/Factory Interface
	public interface IAnimalFactory
	{
		IAnimal CreateAnimal();
	}

	// Concrete Creators
	public class DogFactory : IAnimalFactory
	{
		public IAnimal CreateAnimal()
		{
			return new Dog();
		}
	}

	public class CatFactory : IAnimalFactory
	{
		public IAnimal CreateAnimal()
		{
			return new Cat();
		}

	}

	// ----------------------------------------- ( EXAMPLE 02 ) -------------------------

	// Product Interface
	public interface ILogger
	{
		void Log(string message);
	}

	// Concrete Products
	public class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine($"Console Log: {message}");
		}
	}

	public class FileLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine($"File Log: {message}");
		}
	}

	// Creator/Factory Interface
	public interface ILoggerFactory
	{
		ILogger CreateLogger();
	}

	// Concrete Creators
	public class ConsoleLoggerFactory : ILoggerFactory
	{
		public ILogger CreateLogger()
		{
			return new ConsoleLogger();
		}
	}

	public class FileLoggerFactory : ILoggerFactory
	{
		public ILogger CreateLogger()
		{
			return new FileLogger();
		}
	}

	
}
