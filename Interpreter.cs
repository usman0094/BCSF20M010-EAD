using System;

namespace Assignment_08
{
	// Context
	public class Context1
	{
		public string Input { get; set; }

		public Context1(string input)
		{
			Input = input;
		}
	}

	// Abstract Expression
	public interface IExpression
	{
		void Interpret(Context1 context);
	}

	// Terminal Expression
	public class TerminalExpression : IExpression
	{
		private string data;

		public TerminalExpression(string data)
		{
			this.data = data;
		}

		public void Interpret(Context1 context)
		{
			if (context.Input.Contains(data))
			{
				Console.WriteLine($"TerminalExpression interprets {data}");
			}
		}
	}

	// Nonterminal Expression
	public class NonterminalExpression : IExpression
	{
		private IExpression expression1;
		private IExpression expression2;

		public NonterminalExpression(IExpression expression1, IExpression expression2)
		{
			this.expression1 = expression1;
			this.expression2 = expression2;
		}

		public void Interpret(Context1 context)
		{
			Console.WriteLine("NonterminalExpression interprets");
			expression1.Interpret(context);
			expression2.Interpret(context);
		}
	}
}
