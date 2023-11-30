using System;
using System.Collections;

namespace Assignment_08
{
	// Aggregate Interface
	public interface IAggregate
	{
		IIterator CreateIterator();
	}

	// Iterator Interface
	public interface IIterator
	{
		bool HasNext();
		object Next();
	}

	// Concrete Aggregate
	public class ConcreteAggregate : IAggregate
	{
		private ArrayList items = new ArrayList();

		public void Add(object item)
		{
			items.Add(item);
		}

		public IIterator CreateIterator()
		{
			return new ConcreteIterator(this);
		}

		public int Count => items.Count;

		public object this[int index] => items[index];
	}

	// Concrete Iterator
	public class ConcreteIterator : IIterator
	{
		private ConcreteAggregate aggregate;
		private int index = 0;

		public ConcreteIterator(ConcreteAggregate aggregate)
		{
			this.aggregate = aggregate;
		}

		public bool HasNext()
		{
			return index < aggregate.Count;
		}

		public object Next()
		{
			if (HasNext())
			{
				return aggregate[index++];
			}
			else
			{
				throw new InvalidOperationException("End of collection reached");
			}
		}
	}
}
