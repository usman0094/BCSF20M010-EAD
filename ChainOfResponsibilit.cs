using System;

namespace Assignment_08
{
	// Handler Interface
	public interface IHandler
	{
		IHandler Successor { get; set; }
		void HandleRequest(int request);
	}

	// Concrete Handler 1
	public class ConcreteHandler1 : IHandler
	{
		public IHandler Successor { get; set; }

		public void HandleRequest(int request)
		{
			if (request < 10)
				Console.WriteLine($"ConcreteHandler1 handles the request: {request}");
			else if (Successor != null)
				Successor.HandleRequest(request);
			else
				Console.WriteLine("End of chain. Request not handled.");
		}
	}

	// Concrete Handler 2
	public class ConcreteHandler2 : IHandler
	{
		public IHandler Successor { get; set; }

		public void HandleRequest(int request)
		{
			if (request >= 10 && request < 20)
				Console.WriteLine($"ConcreteHandler2 handles the request: {request}");
			else if (Successor != null)
				Successor.HandleRequest(request);
			else
				Console.WriteLine("End of chain. Request not handled.");
		}
	}
}
