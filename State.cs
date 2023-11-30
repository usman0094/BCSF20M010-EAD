using System;

namespace Assignment_08
{
	// Context
	public class Context
	{
		private IState currentState;

		public Context()
		{
			currentState = new ConcreteState1();
		}

		public void SetState(IState state)
		{
			currentState = state;
		}

		public void Request()
		{
			currentState.Handle(this);
		}
	}

	// State Interface
	public interface IState
	{
		void Handle(Context context);
	}

	// Concrete States
	public class ConcreteState1 : IState
	{
		public void Handle(Context context)
		{
			Console.WriteLine("Handling request in ConcreteState1");
			context.SetState(new ConcreteState2());
		}
	}

	public class ConcreteState2 : IState
	{
		public void Handle(Context context)
		{
			Console.WriteLine("Handling request in ConcreteState2");
			context.SetState(new ConcreteState1());
		}
	}
}
