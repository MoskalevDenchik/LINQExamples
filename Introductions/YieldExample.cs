#region Using

using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Introductions
{
	[TestClass]
	public class YieldExample
	{
		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Yield_Example_1()
		{
			IEnumerable<string> elements = GetSequence();

			foreach (string item in elements)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private methods

		//private IEnumerable<string> GetSequence()
		//{
		//	yield return "item_1";
		//	yield return "item_2";
		//	yield return "item_3";
		//	Console.WriteLine("Hello");
		//	yield return "item_4";
		//	yield return "item_5";
		//}

		private static IEnumerable<string> GetSequence()
		{
			return new GeneratedClass(-2);
		}

		private sealed class GeneratedClass : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
		{
			private int _state;
			private string _current;
			private int _initialThreadId;

			public GeneratedClass(int param1)
			{
				_state = param1;
				_initialThreadId = Environment.CurrentManagedThreadId;
			}

			bool IEnumerator.MoveNext()
			{
				switch (_state)
				{
					case 0:
						_state = -1;
						_current = "item_1";
						_state = 1;
						return true;
					case 1:
						_state = -1;
						_current = "item_2";
						_state = 2;
						return true;
					case 2:
						_state = -1;
						_current = "item_3";
						_state = 3;
						return true;
					case 3:
						_state = -1;
						Console.WriteLine("Hello");
						_current = "item_4";
						_state = 4;
						return true;
					case 4:
						_state = -1;
						_current = "item_5";
						_state = 5;
						return true;
					case 5:
						_state = -1;
						return false;
					default:
						return false;
				}
			}

			public IEnumerator<string> GetEnumerator()
			{
				GeneratedClass getCollectionD1;

				if (_state == -2 && _initialThreadId == Environment.CurrentManagedThreadId)
				{
					_state = 0;
					getCollectionD1 = this;
				}
				else
				{
					getCollectionD1 = new GeneratedClass(0);
				}

				return getCollectionD1;
			}

			string IEnumerator<string>.Current => _current;

			object IEnumerator.Current => _current;

			void IEnumerator.Reset() => throw new NotSupportedException();

			void IDisposable.Dispose() { }

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		#endregion

	}
}
