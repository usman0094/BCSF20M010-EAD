using Asssignment_06;
using System;

namespace Assignment_06
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("----- Singleton Design Pattern -----");
			SingletonExample();

			Console.WriteLine("\n----- Factory Method Design Pattern -----");
			FactoryMethodExample();

			Console.WriteLine("\n----- Abstract Factory Design Pattern -----");
			AbstractFactoryExample();

			Console.WriteLine("\n----- Builder Design Pattern -----");
			BuilderExample();

			Console.WriteLine("\n----- Prototype Design Pattern -----");
			PrototypeExample();
		}

		static void SingletonExample()
		{
			// Example 01
			Singleton instance1 = Singleton.GetInstance();
			Singleton instance2 = Singleton.GetInstance();

			// Example 02
			ThreadSafeSingleton threadSafeInstance1 = ThreadSafeSingleton.GetInstance(1);
			ThreadSafeSingleton threadSafeInstance2 = ThreadSafeSingleton.GetInstance(2);
		}

		static void FactoryMethodExample()
		{
			// Example 01
			IAnimalFactory dogFactory = new DogFactory();
			IAnimalFactory catFactory = new CatFactory();

			IAnimal dog = dogFactory.CreateAnimal();
			IAnimal cat = catFactory.CreateAnimal();

			Console.WriteLine("Factory Method - Animal Sounds:");
			dog.Speak();
			cat.Speak();

			// Example 02
			ILoggerFactory consoleLoggerFactory = new ConsoleLoggerFactory();
			ILoggerFactory fileLoggerFactory = new FileLoggerFactory();

			ILogger consoleLogger = consoleLoggerFactory.CreateLogger();
			ILogger fileLogger = fileLoggerFactory.CreateLogger();

			Console.WriteLine("\nFactory Method - Logging Messages:");
			consoleLogger.Log("This is a console log message.");
			fileLogger.Log("This is a file log message.");
		}

		static void AbstractFactoryExample()
		{
			// Example 01
			IElectronicDeviceFactory highPerformanceFactory = new HighPerformanceFactory();
			IElectronicDeviceFactory everydayUseFactory = new EverydayUseFactory();

			IElectronicDevice highPerformanceLaptop = highPerformanceFactory.CreateLaptop();
			IElectronicDevice everydayUseSmartphone = everydayUseFactory.CreateSmartphone();

			Console.WriteLine("\nAbstract Factory - Electronic Devices:");
			highPerformanceLaptop.DisplayInfo();
			everydayUseSmartphone.DisplayInfo();

			// Example 02
			IKitchenApplianceFactory quickCookingFactory = new QuickCookingFactory();
			IKitchenApplianceFactory smoothieFactory = new SmoothieFactory();

			IKitchenAppliance quickCookingMicrowave = quickCookingFactory.CreateMicrowave();
			IKitchenAppliance smoothieBlender = smoothieFactory.CreateBlender();

			Console.WriteLine("\nAbstract Factory - Kitchen Appliances:");
			quickCookingMicrowave.Operate();
			smoothieBlender.Operate();
		}

		static void BuilderExample()
		{
			// Example 01
			IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
			MealDirector healthyMealDirector = new MealDirector(healthyMealBuilder);
			healthyMealDirector.ConstructMeal();
			Meal healthyMeal = healthyMealBuilder.GetMeal();

			Console.WriteLine("\nBuilder - Healthy Meal:");
			Console.WriteLine($"Main Course: {healthyMeal.MainCourse}");
			Console.WriteLine($"Side Dish: {healthyMeal.SideDish}");
			Console.WriteLine($"Drink: {healthyMeal.Drink}");
			Console.WriteLine($"Dessert: {healthyMeal.Dessert}");

			// Example 02
			IHouseBuilder modernHouseBuilder = new ModernHouseBuilder();
			HouseDirector modernHouseDirector = new HouseDirector(modernHouseBuilder);
			modernHouseDirector.ConstructHouse();
			House modernHouse = modernHouseBuilder.GetHouse();

			Console.WriteLine("\nBuilder - Modern House:");
			Console.WriteLine($"Foundation: {modernHouse.Foundation}");
			Console.WriteLine($"Walls: {modernHouse.Walls}");
			Console.WriteLine($"Roof: {modernHouse.Roof}");
			Console.WriteLine($"Interior: {modernHouse.Interior}");
		}

		static void PrototypeExample()
		{
			// Example 01
			IGraphicObject circlePrototype = new Circle(5);
			IGraphicObject clonedCircle = (IGraphicObject)circlePrototype.Clone();

			Console.WriteLine("\nPrototype - Graphic Objects:");
			Console.WriteLine("Original Circle:");
			circlePrototype.Draw();
			Console.WriteLine("Cloned Circle:");
			clonedCircle.Draw();

			// Example 02
			IDocument resumePrototype = new Resume();
			IDocument clonedResume = (IDocument)resumePrototype.Clone();
			clonedResume.AddElement("Additional Experience: Freelancing");

			Console.WriteLine("\nPrototype - Documents:");
			Console.WriteLine("Original Resume:");
			resumePrototype.Print();
			Console.WriteLine("Cloned Resume:");
			clonedResume.Print();
		}
	}
}
