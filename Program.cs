using System;
using System.Collections.Generic;
using System.Data;
using Assignment_04;

namespace Assignment_04
{
	public class EquationSolver
	{
		public string Solve(string equation)
		{
			equation = PerformAddition(equation);
			equation = PerformSubtraction(equation);
			equation = PerformMultiplication(equation);
			equation = PerformDivision(equation);
			string result = equation;
			return result;
		}
		public double Solve2(string equation)
		{
			double result = PerformDMAS(equation);
			return result;
		}

		public double PerformDMAS(string equation)     //DMAS 
		{
			DataTable table = new DataTable();
			table.Columns.Add("expression", typeof(string), equation);
			DataRow row = table.NewRow();
			table.Rows.Add(row);
			double result = double.Parse((string)row["expression"]);
			return result;
		}



		public string PerformAddition(string equation) // Addition 
		{
			string[] parts = equation.Split('+');
			double result = 0;

			foreach (string part in parts)
			{
				double operand;
				if (double.TryParse(part, out operand))
				{
					result += operand;
				}
				else
				{
					return "Invalid equation";
				}
			}

			return result.ToString();
		}

		public string PerformSubtraction(string equation) // Subtraction
		{
			string[] parts = equation.Split('-');
			double result = 0;

			if (!double.TryParse(parts[0], out result))
			{
				return "Invalid equation";
			}

			for (int i = 1; i < parts.Length; i++)
			{
				double operand;
				if (double.TryParse(parts[i], out operand))
				{
					result -= operand;
				}
				else
				{
					return "Invalid equation";
				}
			}

			return result.ToString();
		}

		public string PerformMultiplication(string equation) // Multiplication
		{
			string[] parts = equation.Split('*');
			double result = 1;

			foreach (string part in parts)
			{
				double operand;
				if (double.TryParse(part, out operand))
				{
					result *= operand;
				}
				else
				{
					return "Invalid equation";
				}
			}

			return result.ToString();
		}


		public string PerformDivision(string equation) // Division
		{
			string[] parts = equation.Split('/');
			double result;

			if (double.TryParse(parts[0], out result))
			{
				for (int i = 1; i < parts.Length; i++)
				{
					double operand;
					if (double.TryParse(parts[i], out operand))
					{
						if (operand != 0)
						{
							result /= operand;
						}
						else
						{
							Console.WriteLine("Division by zero not allowed.");
							return "Invalid equation";
						}
					}
					else
					{
						return "Invalid equation";
					}
				}

				return result.ToString();
			}

			return "Invalid equation";
		}
	}

	//-----------------------------Mian function-------------------------


	class Program
	{
		static void Main(string[] args)
		{
			EquationSolver solver = new EquationSolver();

			// Example for addition
			Console.WriteLine("----------------Addition function------------------");
			string additionEquation = "3 + 4 + 5";
			string additionResult = solver.PerformAddition(additionEquation);
			Console.WriteLine("Addition Result: " + additionResult);

			Console.WriteLine("\n----------------Subtraction function------------------");
			// Example for subtraction
			string subtractionEquation = "10 - 3 - 2";
			string subtractionResult = solver.PerformSubtraction(subtractionEquation);
			Console.WriteLine("Subtraction Result: " + subtractionResult);


			Console.WriteLine("\n----------------Multiplication function------------------");
			// Example for multiplication
			string multiplicationEquation = "2 * 3 * 4";
			string multiplicationResult = solver.PerformMultiplication(multiplicationEquation);
			Console.WriteLine("Multiplication Result: " + multiplicationResult);


			Console.WriteLine("\n----------------Division function------------------");
			// Example for division
			string divisionEquation = "20 /25";
			string divisionResult = solver.PerformDivision(divisionEquation);
			Console.WriteLine("Division Result: " + divisionResult);


			Console.WriteLine("\n----------------DMAS Rule------------------");

			// DMAS RULE

			EquationSolver solver2 = new EquationSolver();

			string equation1 = "22 / 2 * 34 - 4";
			double result1 = solver2.Solve2(equation1);
			Console.WriteLine("Result 1: " + result1);

			string equation2 = "3*4/9+4";
			double result2 = solver2.Solve2(equation2);
			Console.WriteLine("Result 2: " + result2);

			Console.WriteLine("\n----------------Equation Balancer check ------------------");

			//equation balancer
			EquationSolver2 solver3 = new EquationSolver2();

			string equation6 = "(1 + 1) - 3 * (44 * 5) / 20";
			string result6 = solver3.Solve4(equation6);
			Console.WriteLine("Result 1: " + result6);

			string equation7 = "(1 + 1) 3 + 4 * 5";
			string result7 = solver3.Solve4(equation7);
			Console.WriteLine("Result 2: " + result7);

			string equation8 = "(((1 + 1) x 3) + 4 * 5";
			string result8 = solver3.Solve4(equation8);
			Console.WriteLine("Result 3: " + result8);

		}
	}
}




////using System;
////using System.Collections.Generic;
////using System.Data;
///using Assignment_04;

////namespace Assignment_04
////{
////	public class EquationSolver
////	{
////		public string Solve(string equation)
////		{
////			if (!IsValidEquation(equation))
////				return "Invalid equation";

////			equation = NormalizeEquation(equation);
////			double result = PerformDMAS(equation);
////			return result.ToString(); // Convert the result to a string
////		}


////		public double Solve2(string equation)
////		{
////			if (!IsValidEquation(equation))
////				return double.NaN;

////			double result = PerformDMAS(equation);
////			return result;
////		}

////		public double PerformDMAS(string equation)
////		{
////			DataTable table = new DataTable();
////			table.Columns.Add("expression", typeof(string), equation);
////			DataRow row = table.NewRow();
////			table.Rows.Add(row);
////			double result = double.Parse((string)row["expression"]);
////			return result;
////		}

////		private string NormalizeEquation(string equation)
////		{
////			// Remove spaces
////			equation = equation.Replace(" ", "");

////			// Add multiplication operator for cases like "2(3)"
////			equation = AddMultiplicationOperator(equation);

////			return equation;
////		}

////		private string AddMultiplicationOperator(string equation)
////		{
////			for (int i = 0; i < equation.Length - 1; i++)
////			{
////				if ((char.IsDigit(equation[i]) || equation[i] == ')') && (equation[i + 1] == '(' || char.IsDigit(equation[i + 1])))
////				{
////					equation = equation.Insert(i + 1, "*");
////				}
////			}
////			return equation;
////		}

////		private bool IsValidEquation(string equation)
////		{
////			// Check for cases where operators are not defined between operands or brackets
////			for (int i = 0; i < equation.Length - 1; i++)
////			{
////				char currentChar = equation[i];
////				char nextChar = equation[i + 1];

////				if ((char.IsDigit(currentChar) || currentChar == ')') &&
////					(nextChar == '(' || char.IsDigit(nextChar)))
////				{
////					return false;
////				}

////				if (currentChar == '(' && nextChar == ')')
////				{
////					return false;
////				}
////			}

////			// Check for missing brackets
////			int openBracketCount = 0;
////			int closeBracketCount = 0;
////			foreach (char c in equation)
////			{
////				if (c == '(')
////				{
////					openBracketCount++;
////				}
////				else if (c == ')')
////				{
////					closeBracketCount++;
////				}
////				if (closeBracketCount > openBracketCount)
////				{
////					return false;
////				}
////			}

////			if (openBracketCount != closeBracketCount)
////			{
////				return false;
////			}

////			// Check for missing operand after an operator
////			if (equation.EndsWith("+") || equation.EndsWith("-") || equation.EndsWith("*") || equation.EndsWith("/"))
////			{
////				return false;
////			}

////			return true;
////		}
////	}

////	class Program
////	{
////		static void Main(string[] args)
////		{
////			EquationSolver solver = new EquationSolver();

////			string equation1 = "(1 + 1) - 3 * (44 * 5) / 20";
////			string result1 = solver.Solve(equation1);
////			Console.WriteLine("Result 1: " + result1);

////			string equation2 = "(1 + 1) 3 + 4 * 5";
////			string result2 = solver.Solve(equation2);
////			Console.WriteLine("Result 2: " + result2);

////			string equation3 = "(((1 + 1) x 3) + 4 * 5";
////			string result3 = solver.Solve(equation3);
////			Console.WriteLine("Result 3: " + result3);

////			string equation4 = "1 + 2 + 3 - - 4";
////			string result4 = solver.Solve(equation4);
////			Console.WriteLine("Result 4: " + result4);

////			string equation5 = "1 + 2 + 3 -";
////			string result5 = solver.Solve(equation5);
////			Console.WriteLine("Result 5: " + result5);
////		}
////	}
////}



//using System;
//using System.Data;

//namespace Assignment_04
//{
//	public class EquationSolver
//	{
//		public string Solve(string equation)
//		{
//			if (!IsValidEquation(equation))
//				return "Invalid equation";

//			equation = NormalizeEquation(equation);
//			double result = PerformDMAS(equation);
//			return result.ToString(); // Convert the result to a string
//		}

//		public double Solve2(string equation)
//		{
//			if (!IsValidEquation(equation))
//				return double.NaN;

//			double result = PerformDMAS(equation);
//			return result;
//		}

//		public double PerformDMAS(string equation)
//		{
//			DataTable table = new DataTable();
//			table.Columns.Add("expression", typeof(string), equation);
//			DataRow row = table.NewRow();
//			table.Rows.Add(row);
//			double result = double.Parse((string)row["expression"]);
//			return result;
//		}

//		private string NormalizeEquation(string equation)
//		{
//			// Remove spaces
//			equation = equation.Replace(" ", "");

//			// Add multiplication operator for cases like "2(3)"
//			equation = AddMultiplicationOperator(equation);

//			return equation;
//		}

//		private string AddMultiplicationOperator(string equation)
//		{
//			for (int i = 0; i < equation.Length - 1; i++)
//			{
//				if ((char.IsDigit(equation[i]) || equation[i] == ')') && (equation[i + 1] == '(' || char.IsDigit(equation[i + 1])))
//				{
//					equation = equation.Insert(i + 1, "*");
//				}
//			}
//			return equation;
//		}

//		private bool IsValidEquation(string equation)
//		{
//			// Check for cases where operators are not defined between operands or brackets
//			for (int i = 0; i < equation.Length - 1; i++)
//			{
//				char currentChar = equation[i];
//				char nextChar = equation[i + 1];

//				if ((char.IsDigit(currentChar) || currentChar == ')') &&
//					(nextChar == '(' || char.IsDigit(nextChar)))
//				{
//					return false;
//				}

//				if (currentChar == '(' && nextChar == ')')
//				{
//					return false;
//				}
//			}

//			// Check for missing brackets
//			int openBracketCount = 0;
//			int closeBracketCount = 0;
//			foreach (char c in equation)
//			{
//				if (c == '(')
//				{
//					openBracketCount++;
//				}
//				else if (c == ')')
//				{
//					closeBracketCount++;
//				}
//				if (closeBracketCount > openBracketCount)
//				{
//					return false;
//				}
//			}

//			if (openBracketCount != closeBracketCount)
//			{
//				return false;
//			}

//			// Check for missing operand after an operator
//			if (equation.EndsWith("+") || equation.EndsWith("-") || equation.EndsWith("*") || equation.EndsWith("/"))
//			{
//				return false;
//			}

//			return true;
//		}
//	}















//using Assignment_04;

//	class Program
//	{
//		static void Main(string[] args)
//		{
//			EquationSolver solver = new EquationSolver();

//			string equation1 = "(1 + 1) - 3 * (44 * 5) / 20";
//			string result1 = solver.Solve(equation1);
//			Console.WriteLine("Result 1: " + result1);

//			string equation2 = "(1 + 1) 3 + 4 * 5";
//			string result2 = solver.Solve(equation2);
//			Console.WriteLine("Result 2: " + result2);

//			string equation3 = "(((1 + 1) x 3) + 4 * 5";
//			string result3 = solver.Solve(equation3);
//			Console.WriteLine("Result 3: " + result3);

//			string equation4 = "1 + 2 + 3 - - 4";
//			string result4 = solver.Solve(equation4);
//			Console.WriteLine("Result 4: " + result4);

//			string equation5 = "1 + 2 + 3 -";
//			string result5 = solver.Solve(equation5);
//			Console.WriteLine("Result 5: " + result5);
//		}
//	}






