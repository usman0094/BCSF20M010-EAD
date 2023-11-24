using System;

namespace Assignment_07
{
	// Target Interface
	public interface IStorage
	{
		void Read();
		void Write();
	}

	// Adaptee 1
	public class HardDisk
	{
		public void FetchData()
		{
			Console.WriteLine("Reading data from hard disk");
		}

		public void StoreData()
		{
			Console.WriteLine("Writing data to hard disk");
		}
	}

	// Adaptee 2
	public class USBDrive
	{
		public void RetrieveData()
		{
			Console.WriteLine("Reading data from USB drive");
		}

		public void SaveData()
		{
			Console.WriteLine("Writing data to USB drive");
		}
	}

	// Example 1: Class Adapter Pattern
	public class HardDiskAdapter : IStorage
	{
		private HardDisk hardDisk;

		public HardDiskAdapter(HardDisk hardDisk)
		{
			this.hardDisk = hardDisk;
		}

		public void Read()
		{
			hardDisk.FetchData();
		}

		public void Write()
		{
			hardDisk.StoreData();
		}
	}

	// Example 2: Object Adapter Pattern
	public class USBDriveAdapter : IStorage
	{
		private USBDrive usbDrive;

		public USBDriveAdapter(USBDrive usbDrive)
		{
			this.usbDrive = usbDrive;
		}

		public void Read()
		{
			usbDrive.RetrieveData();
		}

		public void Write()
		{
			usbDrive.SaveData();
		}
	}
}
    


