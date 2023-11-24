using System;

namespace Assignment_07
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Adapter Pattern Examples:");
			Console.WriteLine("--------------------------");
			IStorage hardDiskAdapter = new HardDiskAdapter(new HardDisk());
			hardDiskAdapter.Read();
			hardDiskAdapter.Write();

			IStorage usbDriveAdapter = new USBDriveAdapter(new USBDrive());
			usbDriveAdapter.Read();
			usbDriveAdapter.Write();

			Console.WriteLine("\nBridge Pattern Examples:");
			Console.WriteLine("--------------------------");
			IMessageSender emailSender = new EmailSender();
			IMessageSender smsSender = new SMSSender();

			Message urgentEmail = new UrgentMessage(emailSender);
			Message normalSMS = new NormalMessage(smsSender);

			urgentEmail.Send("This is an urgent email.");
			normalSMS.Send("This is a normal SMS.");

			IDocumentFormatter plainTextFormatter = new PlainTextFormatter();
			IDocumentFormatter htmlFormatter = new HTMLFormatter();

			Document plainTextDocument = new PlainTextDocument(plainTextFormatter);
			Document htmlDocument = new HTMLDocument(htmlFormatter);

			plainTextDocument.Display("This is a plain text document.");
			htmlDocument.Display("<p>This is an HTML document.</p>");

			

			Console.WriteLine("\nProxy Pattern Examples:");
			Console.WriteLine("--------------------------");
			IImage image = new ImageProxy("sample.jpg");
			image.Display();

			IBankAccount bankAccount = new BankAccountProxy("authorized", "password");
			bankAccount.Deposit(1000);
			bankAccount.Withdraw(500);
			Console.WriteLine($"Current balance: {bankAccount.GetBalance():C}");

			Console.WriteLine("\nFlyweight Pattern Examples:");
			Console.WriteLine("--------------------------");
			TextCharacter A = new TextCharacter('A', ConsoleColor.Red);
			TextCharacter B = new TextCharacter('B', ConsoleColor.Green);
			TextCharacter C = new TextCharacter('C', ConsoleColor.Blue);

			A.Display();
			B.Display();
			C.Display();

			MusicalComposition composition = new MusicalComposition();
			composition.AddNote("C");
			composition.AddNote("D");
			composition.AddNote("E");

			composition.PlayNotes("Piano");

			Console.WriteLine("\nFacade Pattern Examples:");
			Console.WriteLine("--------------------------");
			DvdPlayer dvdPlayer = new DvdPlayer();
			Projector projector = new Projector();
			SoundSystem soundSystem = new SoundSystem();

			HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem);
			homeTheater.WatchMovie("Inception");
			homeTheater.EndMovie();

			InventoryManagement inventoryManagement = new InventoryManagement();
			PaymentProcessing paymentProcessing = new PaymentProcessing();
			ShippingService shippingService = new ShippingService();

			OrderProcessingFacade orderProcessing = new OrderProcessingFacade(inventoryManagement, paymentProcessing, shippingService);
			orderProcessing.ProcessOrder("Laptop", 2, "Credit Card", 2000.0m, "123 Main St");

			Console.WriteLine("\nDecorator Pattern Examples:");
			Console.WriteLine("--------------------------");
			IText plainText = new PlainText("This is a plain text.");
			IText boldText = new BoldTextDecorator(plainText);
			IText italicText = new ItalicTextDecorator(boldText);

			Console.WriteLine("Original Text: " + plainText.GetText());
			Console.WriteLine("Decorated Text: " + boldText.GetText());
			Console.WriteLine("Doubly Decorated Text: " + italicText.GetText());

			ICar basicCar = new BasicCar();
			ICar sportsCar = new SportsPackageDecorator(basicCar);
			ICar luxuryCar = new LuxuryPackageDecorator(sportsCar);

			Console.WriteLine("Car Description: " + luxuryCar.GetDescription());
			Console.WriteLine("Car Cost: " + luxuryCar.GetCost());

		


			Console.WriteLine("\nComposite Pattern Examples:");
			Console.WriteLine("--------------------------");

			


			// Composite Example 1: Menu
			Console.WriteLine("-----Example 1------");
			IMenuItem menuItem1 = new MenuItem("Option 1");
			IMenuItem menuItem2 = new MenuItem("Option 2");

			Menu menu = new Menu("Main Menu");
			menu.AddItem(menuItem1);
			menu.AddItem(menuItem2);

			// Display the menu
			Console.WriteLine("Displaying Menu:");
			menu.Display();

			Console.WriteLine();

			// Composite Example 2: Document Section
			Console.WriteLine("-----Example 2------");
			IDocumentElement textElement1 = new TextElement("Introduction");
			IDocumentElement textElement2 = new TextElement("Body Text");

			DocumentSection section = new DocumentSection("Main Section");
			section.AddElement(textElement1);
			section.AddElement(textElement2);

			// Display the document section
			Console.WriteLine("Displaying Document Section:");
			section.Display();
		}
	}
}

