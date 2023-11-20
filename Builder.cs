using System;

namespace Assignment_06
{
	// ----------------------------------------- ( EXAMPLE 01 ) -------------------------

	// Product class
	public class Meal
	{
		public string MainCourse { get; set; }
		public string SideDish { get; set; }
		public string Drink { get; set; }
		public string Dessert { get; set; }
	}

	// Builder interface
	public interface IMealBuilder
	{
		void BuildMainCourse();
		void BuildSideDish();
		void BuildDrink();
		void BuildDessert();
		Meal GetMeal();
	}

	// Concrete Builder class for Meal
	public class HealthyMealBuilder : IMealBuilder
	{
		private Meal _healthyMeal = new Meal();

		public void BuildMainCourse()
		{
			_healthyMeal.MainCourse = "Grilled Chicken Salad";
		}

		public void BuildSideDish()
		{
			_healthyMeal.SideDish = "Steamed Vegetables";
		}

		public void BuildDrink()
		{
			_healthyMeal.Drink = "Green Tea";
		}

		public void BuildDessert()
		{
			_healthyMeal.Dessert = "Fruit Salad";
		}

		public Meal GetMeal()
		{
			return _healthyMeal;
		}
	}

	// Director class
	public class MealDirector
	{
		private IMealBuilder _builder;

		public MealDirector(IMealBuilder builder)
		{
			_builder = builder;
		}

		public void ConstructMeal()
		{
			_builder.BuildMainCourse();
			_builder.BuildSideDish();
			_builder.BuildDrink();
			_builder.BuildDessert();
		}
	}

	// ----------------------------------------- ( EXAMPLE 02 ) -------------------------

	// Product class
	public class House
	{
		public string Foundation { get; set; }
		public string Walls { get; set; }
		public string Roof { get; set; }
		public string Interior { get; set; }
	}

	// Builder interface
	public interface IHouseBuilder
	{
		void BuildFoundation();
		void BuildWalls();
		void BuildRoof();
		void BuildInterior();
		House GetHouse();
	}

	// Concrete Builder class for House
	public class ModernHouseBuilder : IHouseBuilder
	{
		private House _modernHouse = new House();

		public void BuildFoundation()
		{
			_modernHouse.Foundation = "Concrete Slab";
		}

		public void BuildWalls()
		{
			_modernHouse.Walls = "Glass Panels";
		}

		public void BuildRoof()
		{
			_modernHouse.Roof = "Flat Roof";
		}

		public void BuildInterior()
		{
			_modernHouse.Interior = "Minimalistic Furniture";
		}

		public House GetHouse()
		{
			return _modernHouse;
		}
	}

	// Director class
	public class HouseDirector
	{
		private IHouseBuilder _builder;

		public HouseDirector(IHouseBuilder builder)
		{
			_builder = builder;
		}

		public void ConstructHouse()
		{
			_builder.BuildFoundation();
			_builder.BuildWalls();
			_builder.BuildRoof();
			_builder.BuildInterior();
		}
	}

	
	
}
