using System;
using System.Collections.Generic;
namespace Assignment_06
{

	// ----------------------------------------- ( EXAMPLE 01 ) -------------------------

	// Prototype interface
	public interface IGraphicObject : ICloneable
	{
		void Draw();
	}

	// ConcretePrototype class
	public class Circle : IGraphicObject
	{
		public int Radius { get; set; }

		public Circle(int radius)
		{
			Radius = radius;
		}

		public void Draw()
		{
			Console.WriteLine($"Drawing a Circle with Radius {Radius}");
		}

		public object Clone()
		{
			// Shallow copy is sufficient for this example
			return this.MemberwiseClone();
		}
	}

	// ConcretePrototype class
	public class Rectangle : IGraphicObject
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public void Draw()
		{
			Console.WriteLine($"Drawing a Rectangle with Width {Width} and Height {Height}");
		}

		public object Clone()
		{
			// Shallow copy is sufficient for this example
			return this.MemberwiseClone();
		}
	}

	// ----------------------------------------- ( EXAMPLE 02 ) -------------------------

	// Prototype interface
	public interface IDocument : ICloneable
	{
		void AddElement(string element);
		void Print();
	}

	// ConcretePrototype class
	public class Resume : IDocument
	{
		private List<string> elements = new List<string>();

		public void AddElement(string element)
		{
			elements.Add(element);
		}

		public void Print()
		{
			Console.WriteLine("Printing Resume:");
			foreach (var element in elements)
			{
				Console.WriteLine(element);
			}
			Console.WriteLine();
		}

		public object Clone()
		{
			// Deep copy is necessary for this example
			Resume clonedResume = (Resume)this.MemberwiseClone();
			clonedResume.elements = new List<string>(this.elements);
			return clonedResume;
		}
	}
}