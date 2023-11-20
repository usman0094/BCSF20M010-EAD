using System;

namespace Assignment_06
{
	// ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 

	// Abstract Product: Electronic Device
	public interface IElectronicDevice
	{
		void DisplayInfo();
	}

	// Concrete Products: Laptop and Smartphone
	public class Laptop : IElectronicDevice
	{
		public void DisplayInfo()
		{
			Console.WriteLine("Laptop - High-performance computing on the go.");
		}
	}

	public class Smartphone : IElectronicDevice
	{
		public void DisplayInfo()
		{
			Console.WriteLine("Smartphone - Your pocket-sized digital companion.");
		}
	}

	// Abstract Factory: Electronic Device Factory
	public interface IElectronicDeviceFactory
	{
		IElectronicDevice CreateLaptop();
		IElectronicDevice CreateSmartphone();
	}

	// Concrete Factories: HighPerformanceFactory and EverydayUseFactory
	public class HighPerformanceFactory : IElectronicDeviceFactory
	{
		public IElectronicDevice CreateLaptop()
		{
			return new Laptop();
		}

		public IElectronicDevice CreateSmartphone()
		{
			return new Smartphone();
		}
	}

	public class EverydayUseFactory : IElectronicDeviceFactory
	{
		public IElectronicDevice CreateLaptop()
		{
			return new Laptop(); // For simplicity, both factories create the same type of laptop
		}

		public IElectronicDevice CreateSmartphone()
		{
			return new Smartphone();
		}
	}

	// ----------------------------------------- ( EXAMPLE 02 ) -------------------------

	// Abstract Product: Kitchen Appliance
	public interface IKitchenAppliance
	{
		void Operate();
	}

	// Concrete Products: Microwave and Blender
	public class Microwave : IKitchenAppliance
	{
		public void Operate()
		{
			Console.WriteLine("Microwave - Quickly heat or cook your food.");
		}
	}

	public class Blender : IKitchenAppliance
	{
		public void Operate()
		{
			Console.WriteLine("Blender - Easily prepare smoothies and shakes.");
		}
	}

	// Abstract Factory: Kitchen Appliance Factory
	public interface IKitchenApplianceFactory
	{
		IKitchenAppliance CreateMicrowave();
		IKitchenAppliance CreateBlender();
	}

	// Concrete Factories: QuickCookingFactory and SmoothieFactory
	public class QuickCookingFactory : IKitchenApplianceFactory
	{
		public IKitchenAppliance CreateMicrowave()
		{
			return new Microwave();
		}

		public IKitchenAppliance CreateBlender()
		{
			return new Blender();
		}
	}

	public class SmoothieFactory : IKitchenApplianceFactory
	{
		public IKitchenAppliance CreateMicrowave()
		{
			return new Microwave(); // For simplicity, both factories create the same type of microwave
		}

		public IKitchenAppliance CreateBlender()
		{
			return new Blender();
		}
	}
}
