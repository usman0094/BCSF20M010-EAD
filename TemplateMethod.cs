using System;

namespace Assignment_08
{
	// Example 1
	// Template Method Design Pattern

	// Abstract Class
	public abstract class AbstractClass
	{
		// Template method with steps defined by abstract methods
		public void TemplateMethod()
		{
			Step1();
			Step2();
			Step3();
		}

		// Abstract steps to be implemented by concrete classes
		protected abstract void Step1();
		protected abstract void Step2();
		protected abstract void Step3();
	}

	// Concrete Class 1
	public class ConcreteClass1 : AbstractClass
	{
		protected override void Step1()
		{
			Console.WriteLine("ConcreteClass1: Step 1");
		}

		protected override void Step2()
		{
			Console.WriteLine("ConcreteClass1: Step 2");
		}

		protected override void Step3()
		{
			Console.WriteLine("ConcreteClass1: Step 3");
		}
	}

	// Concrete Class 2
	public class ConcreteClass2 : AbstractClass
	{
		protected override void Step1()
		{
			Console.WriteLine("ConcreteClass2: Step 1");
		}

		protected override void Step2()
		{
			Console.WriteLine("ConcreteClass2: Step 2");
		}

		protected override void Step3()
		{
			Console.WriteLine("ConcreteClass2: Step 3");
		}
	}

	// Example 2
	// Template Method Design Pattern with Hook Methods

	// Abstract Class with Hook Methods
	public abstract class AbstractClassWithHooks
	{
		// Template method with steps and hook methods
		public void TemplateMethod()
		{
			Step1();
			Hook();
			Step3();
		}

		// Abstract steps to be implemented by concrete classes
		protected abstract void Step1();
		protected abstract void Step3();

		// Hook method with a default implementation
		protected virtual void Hook()
		{
			Console.WriteLine("Default Hook Implementation");
		}
	}

	// Concrete Class 3 with Hook Override
	public class ConcreteClass3 : AbstractClassWithHooks
	{
		protected override void Step1()
		{
			Console.WriteLine("ConcreteClass3: Step 1");
		}

		protected override void Step3()
		{
			Console.WriteLine("ConcreteClass3: Step 3");
		}

		// Override the hook method
		protected override void Hook()
		{
			Console.WriteLine("ConcreteClass3: Custom Hook Implementation");
		}
	}

	// Concrete Class 4 with Default Hook Implementation
	public class ConcreteClass4 : AbstractClassWithHooks
	{
		protected override void Step1()
		{
			Console.WriteLine("ConcreteClass4: Step 1");
		}

		protected override void Step3()
		{
			Console.WriteLine("ConcreteClass4: Step 3");
		}
	}
}
