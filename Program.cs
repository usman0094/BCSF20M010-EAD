using System;

namespace Assignment_08
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("1. Template Method Design Pattern:");
			TemplateMethodExample();

			Console.WriteLine("\n2. Mediator Design Pattern:");
			MediatorExample();

			Console.WriteLine("\n3. Chain of Responsibility Design Pattern:");
			ChainOfResponsibilityExample();

			Console.WriteLine("\n4. Observer Design Pattern:");
			ObserverExample();

			Console.WriteLine("\n5. Strategy Design Pattern:");
			StrategyExample();

			Console.WriteLine("\n6. Command Design Pattern:");
			CommandExample();

			Console.WriteLine("\n7. State Design Pattern:");
			StateExample();

			Console.WriteLine("\n8. Visitor Design Pattern:");
			VisitorExample();

			Console.WriteLine("\n9. Interpreter Design Pattern:");
			InterpreterExample();

			Console.WriteLine("\n10. Iterator Design Pattern:");
			IteratorExample();

			Console.WriteLine("\n11. Memento Design Pattern:");
			MementoExample();
		}

		#region Examples

		private static void TemplateMethodExample()
		{
			AbstractClass template1 = new ConcreteClass1();
			AbstractClass template2 = new ConcreteClass2();

			template1.TemplateMethod();
			template2.TemplateMethod();
		}

		private static void MediatorExample()
		{
			ConcreteMediator mediator = new ConcreteMediator();

			Colleague colleague1 = new ConcreteColleague1(mediator);
			Colleague colleague2 = new ConcreteColleague2(mediator);

			mediator.AddColleague(colleague1);
			mediator.AddColleague(colleague2);

			colleague1.SendMessage("Hello from Colleague1");
			colleague2.SendMessage("Hi from Colleague2");
		}

		private static void ChainOfResponsibilityExample()
		{
			IHandler handler1 = new ConcreteHandler1();
			IHandler handler2 = new ConcreteHandler2();

			handler1.Successor = handler2;

			handler1.HandleRequest(5);
			handler1.HandleRequest(15);
			handler1.HandleRequest(25);
		}


		private static void ObserverExample()
		{
			ConcreteSubject subject = new ConcreteSubject();
			IObserver observer1 = new ConcreteObserver1();
			IObserver observer2 = new ConcreteObserver2();

			subject.Attach(observer1);
			subject.Attach(observer2);

			subject.Notify();
		}

		private static void StrategyExample()
		{
			Contex context = new Contex(new ConcreteStrategy1());
			context.ExecuteStrategy();

			context.SetStrategy(new ConcreteStrategy2());
			context.ExecuteStrategy();
		}


		private static void CommandExample()
		{
			Receiver receiver = new Receiver();
			ICommand command = new ConcreteCommand(receiver);
			Invoker invoker = new Invoker();

			invoker.SetCommand(command);
			invoker.ExecuteCommand();
		}

		private static void StateExample()
		{
			Context context = new Context();
			context.Request();
			context.Request();
			context.Request();
		}

		private static void VisitorExample()
		{
			ObjectStructure objectStructure = new ObjectStructure();
			objectStructure.Attach(new ConcreteElement1());
			objectStructure.Attach(new ConcreteElement2());

			IVisitor visitor = new ConcreteVisitor();
			objectStructure.Accept(visitor);
		}

		private static void InterpreterExample()
		{
			Context1 context1 = new Context1("Hello World");

			IExpression expression1 = new TerminalExpression("Hello");
			IExpression expression2 = new TerminalExpression("World");

			IExpression nonterminalExpression = new NonterminalExpression(expression1, expression2);

			nonterminalExpression.Interpret(context1);
		}


		private static void IteratorExample()
		{
			ConcreteAggregate aggregate = new ConcreteAggregate();
			aggregate.Add("Item 1");
			aggregate.Add("Item 2");
			aggregate.Add("Item 3");

			IIterator iterator = aggregate.CreateIterator();

			while (iterator.HasNext())
			{
				Console.WriteLine(iterator.Next());
			}
		}

		private static void MementoExample()
		{
			Originator originator = new Originator();
			Caretaker caretaker = new Caretaker();

			originator.State = "State 1";
			caretaker.AddMemento(originator.CreateMemento());

			originator.State = "State 2";
			caretaker.AddMemento(originator.CreateMemento());

			originator.RestoreMemento(caretaker.GetMemento(0));
			Console.WriteLine($"Restored State: {originator.State}");
		}

		#endregion
	}
}
