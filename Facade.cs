using System;

namespace Assignment_07
{
	// Example 1: Home Theater System

	// Subsystem

	public class DvdPlayer
	{
		public void TurnOn()
		{
			Console.WriteLine("DVD player is on");
		}

		public void Play(string movie)
		{
			Console.WriteLine($"Playing movie: {movie}");
		}

		public void TurnOff()
		{
			Console.WriteLine("DVD player is off");
		}
	}

	// Subsystem
	public class Projector
	{
		public void TurnOn()
		{
			Console.WriteLine("Projector is on");
		}

		public void SetInput(DvdPlayer dvdPlayer)
		{
			Console.WriteLine("Setting input to DVD player");
		}

		public void TurnOff()
		{
			Console.WriteLine("Projector is off");
		}
	}

	// Subsystem
	public class SoundSystem
	{
		public void TurnOn()
		{
			Console.WriteLine("Sound system is on");
		}

		public void SetVolume(int volume)
		{
			Console.WriteLine($"Setting volume to {volume}");
		}

		public void TurnOff()
		{
			Console.WriteLine("Sound system is off");
		}
	}

	// Facade
	public class HomeTheaterFacade
	{
		private DvdPlayer dvdPlayer;
		private Projector projector;
		private SoundSystem soundSystem;

		public HomeTheaterFacade(DvdPlayer dvdPlayer, Projector projector, SoundSystem soundSystem)
		{
			this.dvdPlayer = dvdPlayer;
			this.projector = projector;
			this.soundSystem = soundSystem;
		}

		public void WatchMovie(string movie)
		{
			Console.WriteLine("Get ready to watch a movie...");
			dvdPlayer.TurnOn();
			projector.TurnOn();
			projector.SetInput(dvdPlayer);
			soundSystem.TurnOn();
			soundSystem.SetVolume(10);
			dvdPlayer.Play(movie);
		}

		public void EndMovie()
		{
			Console.WriteLine("Shutting down the home theater...");
			dvdPlayer.TurnOff();
			projector.TurnOff();
			soundSystem.TurnOff();
		}
	}

	// Example 2: Order Processing System

	// Subsystem
	public class InventoryManagement
	{
		public void UpdateInventory(string product, int quantity)
		{
			Console.WriteLine($"Updating inventory for {product} with quantity {quantity}");
		}
	}

	// Subsystem
	public class PaymentProcessing
	{
		public void ProcessPayment(string paymentMethod, decimal amount)
		{
			Console.WriteLine($"Processing {paymentMethod} payment of {amount:C}");
		}
	}

	// Subsystem
	public class ShippingService
	{
		public void ShipOrder(string address)
		{
			Console.WriteLine($"Shipping order to {address}");
		}
	}

	// Facade
	public class OrderProcessingFacade
	{
		private InventoryManagement inventoryManagement;
		private PaymentProcessing paymentProcessing;
		private ShippingService shippingService;

		public OrderProcessingFacade(InventoryManagement inventoryManagement, PaymentProcessing paymentProcessing, ShippingService shippingService)
		{
			this.inventoryManagement = inventoryManagement;
			this.paymentProcessing = paymentProcessing;
			this.shippingService = shippingService;
		}

		public void ProcessOrder(string product, int quantity, string paymentMethod, decimal amount, string shippingAddress)
		{
			Console.WriteLine("Processing order...");
			inventoryManagement.UpdateInventory(product, quantity);
			paymentProcessing.ProcessPayment(paymentMethod, amount);
			shippingService.ShipOrder(shippingAddress);
			Console.WriteLine("Order processing completed.");
		}
	}

}