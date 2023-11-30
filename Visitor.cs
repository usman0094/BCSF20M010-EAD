using System;
using System.Collections.Generic;

namespace Assignment_08
{
	// Visitor Interface
	public interface IVisitor
	{
		void Visit(IElement element);
	}

	// Element Interface
	public interface IElement
	{
		void Accept(IVisitor visitor);
	}

	// Concrete Element 1
	public class ConcreteElement1 : IElement
	{
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public void Operation()
		{
			Console.WriteLine("ConcreteElement1 operation");
		}
	}

	// Concrete Element 2
	public class ConcreteElement2 : IElement
	{
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public void Operation()
		{
			Console.WriteLine("ConcreteElement2 operation");
		}
	}

	// Concrete Visitor
	public class ConcreteVisitor : IVisitor
	{
		public void Visit(IElement element)
		{
			if (element is ConcreteElement1)
			{
				Console.WriteLine("ConcreteVisitor visits ConcreteElement1");
				((ConcreteElement1)element).Operation();
			}
			else if (element is ConcreteElement2)
			{
				Console.WriteLine("ConcreteVisitor visits ConcreteElement2");
				((ConcreteElement2)element).Operation();
			}
		}
	}

	// Object Structure
	public class ObjectStructure
	{
		private List<IElement> elements = new List<IElement>();

		public void Attach(IElement element)
		{
			elements.Add(element);
		}

		public void Detach(IElement element)
		{
			elements.Remove(element);
		}

		public void Accept(IVisitor visitor)
		{
			foreach (var element in elements)
			{
				element.Accept(visitor);
			}
		}
	}
}
