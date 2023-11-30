using System;
using System.Collections.Generic;

namespace Assignment_08
{
	// Mediator Interface
	public interface IMediator
	{
		void SendMessage(string message, Colleague colleague);
	}

	// Colleague Abstract Class
	public abstract class Colleague
	{
		protected IMediator mediator;

		public Colleague(IMediator mediator)
		{
			this.mediator = mediator;
		}

		public abstract void ReceiveMessage(string message);
		public abstract void SendMessage(string message);
	}

	// Concrete Mediator
	public class ConcreteMediator : IMediator
	{
		private List<Colleague> colleagues = new List<Colleague>();

		public void AddColleague(Colleague colleague)
		{
			colleagues.Add(colleague);
		}

		public void SendMessage(string message, Colleague sender)
		{
			foreach (var colleague in colleagues)
			{
				if (colleague != sender)
					colleague.ReceiveMessage(message);
			}
		}
	}

	// Concrete Colleague 1
	public class ConcreteColleague1 : Colleague
	{
		public ConcreteColleague1(IMediator mediator) : base(mediator) { }

		public override void ReceiveMessage(string message)
		{
			Console.WriteLine($"ConcreteColleague1 received message: {message}");
		}

		public override void SendMessage(string message)
		{
			Console.WriteLine($"ConcreteColleague1 sends message: {message}");
			mediator.SendMessage(message, this);
		}
	}

	// Concrete Colleague 2
	public class ConcreteColleague2 : Colleague
	{
		public ConcreteColleague2(IMediator mediator) : base(mediator) { }

		public override void ReceiveMessage(string message)
		{
			Console.WriteLine($"ConcreteColleague2 received message: {message}");
		}

		public override void SendMessage(string message)
		{
			Console.WriteLine($"ConcreteColleague2 sends message: {message}");
			mediator.SendMessage(message, this);
		}
	}
}
