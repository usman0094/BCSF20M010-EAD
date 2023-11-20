using System;

namespace Asssignment_06
{
	// Singleton Design Pattern

	// ----------------------------------------- ( EXAMPLE 01 ) -------------------------

	public sealed class Singleton
	{
		private static readonly Singleton instance = new Singleton();
		private static int Id { get; set; } = 0;

		private Singleton() { }

		public static Singleton GetInstance()
		{
			Id++;
			Console.WriteLine("ID:" + Id);
			return instance;
		}
	}

	// ----------------------------------------- ( EXAMPLE 02 ) -------------------------

	public sealed class ThreadSafeSingleton
	{
		private ThreadSafeSingleton() { }

		private static readonly ThreadSafeSingleton instance = new ThreadSafeSingleton();
		private static int Id { get; set; } = 0;
		private static readonly object threadLock = new object();

		public static ThreadSafeSingleton GetInstance(int id)
		{
			lock (threadLock)
			{
				Id = id;
				Console.WriteLine("ID:" + id);
				return instance;
			}
		}
	}
}
