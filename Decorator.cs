using System;


namespace Assignment_07
{
	// Example 1
	// Text Formatting

	// Component interface
	public interface IText
	{
		string GetText();
	}

	// Concrete Component
	public class PlainText : IText
	{
		private string text;

		public PlainText(string text)
		{
			this.text = text;
		}

		public string GetText()
		{
			return text;
		}
	}

	// Decorator
	public abstract class TextDecorator : IText
	{
		protected IText decoratedText;

		public TextDecorator(IText text)
		{
			this.decoratedText = text;
		}

		public virtual string GetText()
		{
			return decoratedText.GetText();
		}
	}

	// Concrete Decorator 1
	public class BoldTextDecorator : TextDecorator
	{
		public BoldTextDecorator(IText text) : base(text) { }

		public override string GetText()
		{
			return $"<b>{decoratedText.GetText()}</b>";
		}
	}

	// Concrete Decorator 2
	public class ItalicTextDecorator : TextDecorator
	{
		public ItalicTextDecorator(IText text) : base(text) { }

		public override string GetText()
		{
			return $"<i>{decoratedText.GetText()}</i>";
		}
	}

	// Example 2
	// Car Customization

	// Component interface
	public interface ICar
	{
		string GetDescription();
		double GetCost();
	}

	// Concrete Component
	public class BasicCar : ICar
	{
		public string GetDescription()
		{
			return "Basic Car";
		}

		public double GetCost()
		{
			return 20000.0;
		}
	}

	// Decorator
	public abstract class CarDecorator : ICar
	{
		protected ICar decoratedCar;

		public CarDecorator(ICar car)
		{
			this.decoratedCar = car;
		}

		public virtual string GetDescription()
		{
			return decoratedCar.GetDescription();
		}

		public virtual double GetCost()
		{
			return decoratedCar.GetCost();
		}
	}

	// Concrete Decorator 1
	public class SportsPackageDecorator : CarDecorator
	{
		public SportsPackageDecorator(ICar car) : base(car) { }

		public override string GetDescription()
		{
			return $"{decoratedCar.GetDescription()} with Sports Package";
		}

		public override double GetCost()
		{
			return decoratedCar.GetCost() + 5000.0;
		}
	}

	// Concrete Decorator 2
	public class LuxuryPackageDecorator : CarDecorator
	{
		public LuxuryPackageDecorator(ICar car) : base(car) { }

		public override string GetDescription()
		{
			return $"{decoratedCar.GetDescription()} with Luxury Package";
		}

		public override double GetCost()
		{
			return decoratedCar.GetCost() + 10000.0;
		}
	}
}