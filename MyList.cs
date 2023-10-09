using System;
using System.Collections.Generic;

namespace Assignmnet_03
{
	public class MyList<T>
	{
		private List<T> list;

		public MyList()
		{
			list = new List<T>();
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		public bool Remove(T item)
		{
			return list.Remove(item);
		}

		public void Display()
		{
			foreach (T item in list)
			{
				Console.WriteLine(item);
			}
		}
	}
}
