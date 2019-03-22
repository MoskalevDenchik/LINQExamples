#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Introductions
{
	[TestClass]
	public class EnumerableExample
	{
		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Iterator_Example_1()
		{
			IEnumerable<int> sequence = GetSequence_1();

			using (IEnumerator<int> enumerator = sequence.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Console.WriteLine(enumerator.Current);
				}
			}

			Console.WriteLine(new string('-', 50));

			foreach (int item in sequence)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Iterator_Example_2()
		{
			IEnumerable<int> sequence = GetSequence_2();

			foreach (int item in sequence)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Iterator_Example_3()
		{
			IEnumerable<int> sequence = GetSequence_2();

			IEnumerable<int> resultSequence = GetSequenceByPredicate(sequence, item => item > 3);

			foreach (int item in resultSequence)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private members

		private IEnumerable<int> GetSequence_1()
		{
			return new TestSequence();
		}

		private IEnumerable<int> GetSequence_2()
		{
			var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			for (var i = 0; i < array.Length; i++)
			{
				yield return array[i];
			}
		}

		private IEnumerable<int> GetSequenceByPredicate(IEnumerable<int> source, Predicate<int> predicate)
		{
			foreach (int item in source)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}


		#region Custom  Simple Iterator

		private class TestSequence : IEnumerable<int>
		{
			public IEnumerator<int> GetEnumerator()
			{
				return new TestIterator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class TestIterator : IEnumerator<int>
		{
			private int[] _array;
			private int _current;
			private int _currentIndex;

			public TestIterator()
			{
				_array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				_currentIndex = -1;
			}

			public int Current
			{
				get
				{
					return _current;
				}
			}

			public bool MoveNext()
			{
				_currentIndex++;

				if (_array.Length > _currentIndex)
				{
					_current = _array[_currentIndex];
					return true;
				}
				else
				{
					return false;
				}
			}

			object IEnumerator.Current => _current;

			public void Dispose()
			{
				_currentIndex = 0;
			}

			public void Reset()
			{
				throw new NotSupportedException();
			}

		}

		#endregion

		#region Autogenearted Iterator



		#endregion


		#endregion

	}
}
