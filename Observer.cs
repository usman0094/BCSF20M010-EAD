using System;
using System.Collections.Generic;

namespace Assignment_08
{
	// Subject (Observable) Interface
	public interface ISubject
	{
		void Attach(IObserver observer);
		void Detach(IObserver observer);
		void Notify();
	}

	// Observer Interface
	public interface IObserver
	{
		void Update();
	}

	// Concrete Subject (Observable)
	public class ConcreteSubject : ISubject
	{
		private List<IObserver> observers = new List<IObserver>();

		public void Attach(IObserver observer)
		{
			observers.Add(observer);
		}

		public void Detach(IObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var observer in observers)
			{
				observer.Update();
			}
		}
	}

	// Concrete Observer 1
	public class ConcreteObserver1 : IObserver
	{
		public void Update()
		{
			Console.WriteLine("ConcreteObserver1 has been notified.");
		}
	}

	// Concrete Observer 2
	public class ConcreteObserver2 : IObserver
	{
		public void Update()
		{
			Console.WriteLine("ConcreteObserver2 has been notified.");
		}
	}
}
