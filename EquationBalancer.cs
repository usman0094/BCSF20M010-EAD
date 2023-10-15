using System;
using System.Data;

namespace Assignment_04
{
	public class EquationSolver2
	{
		public string Solve4(string equation)
		{
			if (!IsValidEquation(equation))
				return "Invalid equation";

			equation = NormalizeEquation(equation);
			double result = PerformDMAS(equation);
			return result.ToString(); // Convert the result to a string
		}

		public double Solve3(string equation)
		{
			if (!IsValidEquation(equation))
				return double.NaN;

			double result = PerformDMAS(equation);
			return result;
		}

		public double PerformDMAS(string equation)
		{
			DataTable table = new DataTable();
			table.Columns.Add("expression", typeof(string), equation);
			DataRow row = table.NewRow();
			table.Rows.Add(row);
			double result = double.Parse((string)row["expression"]);
			return result;
		}

		private string NormalizeEquation(string equation)
		{
			// Remove spaces
			equation = equation.Replace(" ", "");

			// Add multiplication operator for cases like "2(3)"
			equation = AddMultiplicationOperator(equation);

			return equation;
		}

		private string AddMultiplicationOperator(string equation)
		{
			for (int i = 0; i < equation.Length - 1; i++)
			{
				if ((char.IsDigit(equation[i]) || equation[i] == ')') && (equation[i + 1] == '(' || char.IsDigit(equation[i + 1])))
				{
					equation = equation.Insert(i + 1, "*");
				}
			}
			return equation;
		}

		private bool IsValidEquation(string equation)
		{
			// Check for cases where operators are not defined between operands or brackets
			for (int i = 0; i < equation.Length - 1; i++)
			{
				char currentChar = equation[i];
				char nextChar = equation[i + 1];

				if ((char.IsDigit(currentChar) || currentChar == ')') &&
					(nextChar == '(' || char.IsDigit(nextChar)))
				{
					return false;
				}

				if (currentChar == '(' && nextChar == ')')
				{
					return false;
				}
			}

			// Check for missing brackets
			int openBracketCount = 0;
			int closeBracketCount = 0;
			foreach (char c in equation)
			{
				if (c == '(')
				{
					openBracketCount++;
				}
				else if (c == ')')
				{
					closeBracketCount++;
				}
				if (closeBracketCount > openBracketCount)
				{
					return false;
				}
			}

			if (openBracketCount != closeBracketCount)
			{
				return false;
			}

			// Check for missing operand after an operator
			if (equation.EndsWith("+") || equation.EndsWith("-") || equation.EndsWith("*") || equation.EndsWith("/"))
			{
				return false;
			}

			return true;
		}
	}
}
