using System;
using System.Collections.Generic;

namespace Assignment_08
{
	// Originator
	public class Originator
	{
		private string state;

		public string State
		{
			get => state;
			set
			{
				Console.WriteLine($"Setting state to: {value}");
				state = value;
			}
		}

		public Memento CreateMemento()
		{
			Console.WriteLine("Creating Memento");
			return new Memento(state);
		}

		public void RestoreMemento(Memento memento)
		{
			Console.WriteLine("Restoring Memento");
			state = memento.State;
		}
	}

	// Memento
	public class Memento
	{
		public string State { get; }

		public Memento(string state)
		{
			State = state;
		}
	}

	// Caretaker
	public class Caretaker
	{
		private List<Memento> mementos = new List<Memento>();

		public void AddMemento(Memento memento)
		{
			Console.WriteLine("Adding Memento to the list");
			mementos.Add(memento);
		}

		public Memento GetMemento(int index)
		{
			Console.WriteLine("Getting Memento from the list");
			return mementos[index];
		}
	}
}
