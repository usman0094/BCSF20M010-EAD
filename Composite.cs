

using System;
using System.Collections.Generic;

namespace Assignment_07
{
	// Component
	public interface IMenuItem
	{
		void Display();
	}

	// Leaf
	public class MenuItem : IMenuItem
	{
		private string name;

		public MenuItem(string name)
		{
			this.name = name;
		}

		public void Display()
		{
			Console.WriteLine($"Menu Item: {name}");
		}
	}

	// Composite
	public class Menu : IMenuItem
	{
		private string name;
		private List<IMenuItem> items = new List<IMenuItem>();

		public Menu(string name)
		{
			this.name = name;
		}

		public void AddItem(IMenuItem item)
		{
			items.Add(item);
		}

		public void Display()
		{
			Console.WriteLine($"Menu: {name}");
			foreach (var item in items)
			{
				item.Display();
			}
		}
	}

	// Component
	public interface IDocumentElement
	{
		void Display();
	}

	// Leaf
	public class TextElement : IDocumentElement
	{
		private string text;

		public TextElement(string text)
		{
			this.text = text;
		}

		public void Display()
		{
			Console.WriteLine($"Text Element: {text}");
		}
	}

	// Composite
	public class DocumentSection : IDocumentElement
	{
		private string title;
		private List<IDocumentElement> elements = new List<IDocumentElement>();

		public DocumentSection(string title)
		{
			this.title = title;
		}

		public void AddElement(IDocumentElement element)
		{
			elements.Add(element);
		}

		public void Display()
		{
			Console.WriteLine($"Document Section: {title}");
			foreach (var element in elements)
			{
				element.Display();
			}
		}
	}
}
