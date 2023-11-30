using System;

namespace Assignment_08
{
	// Strategy Interface
	public interface IStrategy
	{
		void Execute();
	}

	// Concrete Strategies
	public class ConcreteStrategy1 : IStrategy
	{
		public void Execute()
		{
			Console.WriteLine("Executing ConcreteStrategy1");
		}
	}

	public class ConcreteStrategy2 : IStrategy
	{
		public void Execute()
		{
			Console.WriteLine("Executing ConcreteStrategy2");
		}
	}

	// Context
	public class Contex
	{
		private IStrategy strategy;

		public Contex(IStrategy strategy)
		{
			this.strategy = strategy;
		}

		public void SetStrategy(IStrategy strategy)
		{
			this.strategy = strategy;
		}

		public void ExecuteStrategy()
		{
			strategy.Execute();
		}
	}
}
