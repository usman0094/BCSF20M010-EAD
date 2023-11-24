using System;


namespace Assignment_07
{

	// Example 1: Messaging System

	// Implementor interface
	public interface IMessageSender
	{
		void SendMessage(string message);
	}

	// Concrete Implementor 1
	public class EmailSender : IMessageSender
	{
		public void SendMessage(string message)
		{
			Console.WriteLine($"Sending email: {message}");
		}
	}

	// Concrete Implementor 2
	public class SMSSender : IMessageSender
	{
		public void SendMessage(string message)
		{
			Console.WriteLine($"Sending SMS: {message}");
		}
	}

	// Abstraction
	public abstract class Message
	{
		protected IMessageSender messageSender;

		protected Message(IMessageSender messageSender)
		{
			this.messageSender = messageSender;
		}

		public abstract void Send(string message);
	}

	// Refined Abstraction 1
	public class UrgentMessage : Message
	{
		public UrgentMessage(IMessageSender messageSender) : base(messageSender) { }

		public override void Send(string message)
		{
			Console.Write("Urgent Message: ");
			messageSender.SendMessage(message);
		}
	}

	// Refined Abstraction 2
	public class NormalMessage : Message
	{
		public NormalMessage(IMessageSender messageSender) : base(messageSender) { }

		public override void Send(string message)
		{
			Console.Write("Normal Message: ");
			messageSender.SendMessage(message);
		}
	}

	// Example 2: Document Formatter

	
	public interface IDocumentFormatter
	{
		void Format(string content);
	}

	// Concrete Implementor 1
	public class PlainTextFormatter : IDocumentFormatter
	{
		public void Format(string content)
		{
			Console.WriteLine($"Formatting as plain text: {content}");
		}
	}

	// Concrete Implementor 2
	public class HTMLFormatter : IDocumentFormatter
	{
		public void Format(string content)
		{
			Console.WriteLine($"Formatting as HTML: {content}");
		}
	}

	// Abstraction
	public abstract class Document
	{
		protected IDocumentFormatter documentFormatter;

		protected Document(IDocumentFormatter documentFormatter)
		{
			this.documentFormatter = documentFormatter;
		}

		public abstract void Display(string content);
	}

	// Refined Abstraction 1
	public class PlainTextDocument : Document
	{
		public PlainTextDocument(IDocumentFormatter documentFormatter) : base(documentFormatter) { }

		public override void Display(string content)
		{
			Console.Write("Plain Text Document: ");
			documentFormatter.Format(content);
		}
	}

	// Refined Abstraction 2
	public class HTMLDocument : Document
	{
		public HTMLDocument(IDocumentFormatter documentFormatter) : base(documentFormatter) { }

		public override void Display(string content)
		{
			Console.Write("HTML Document: ");
			documentFormatter.Format(content);
		}
	}
}
