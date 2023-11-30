using System;

namespace Assignment_08
{
	// Command Interface
	public interface ICommand
	{
		void Execute();
	}

	// Receiver
	public class Receiver
	{
		public void Action()
		{
			Console.WriteLine("Receiver performs the action");
		}
	}

	// Concrete Command
	public class ConcreteCommand : ICommand
	{
		private Receiver receiver;

		public ConcreteCommand(Receiver receiver)
		{
			this.receiver = receiver;
		}

		public void Execute()
		{
			receiver.Action();
		}
	}

	// Invoker
	public class Invoker
	{
		private ICommand command;

		public void SetCommand(ICommand command)
		{
			this.command = command;
		}

		public void ExecuteCommand()
		{
			command.Execute();
		}
	}
}
