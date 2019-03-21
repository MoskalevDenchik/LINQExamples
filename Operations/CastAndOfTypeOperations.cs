#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class CastAndOfTypeOperations
	{
		[TestMethod]
		public void CastOperation_Example_1()
		{
			var arrayList = new ArrayList()
			{
				"Den",
				"Met",
				"Victor"
			};

			IEnumerable<string> result = arrayList.Cast<string>();

			foreach (string item in result)
			{
				Console.WriteLine(item);
			}
		}

		[TestMethod]
		public void OfTypeOperation_Example_2()
		{
			var arrayList = new ArrayList()
			{
				"Den",
				"Met",
				"Victor"
			};

			IEnumerable<string> result = arrayList.OfType<string>();

			foreach (string item in result)
			{
				Console.WriteLine(item);
			}
		}

		[TestMethod]
		public void OfTypeOperation_Example_3()
		{
			var arrayList = new ArrayList()
			{
				"Den",
				"Met",
				(int)4,
				"Victor"
			};

			IEnumerable<string> result = arrayList.OfType<string>();

			foreach (string item in result)
			{
				Console.WriteLine(item);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void CastOperation_Example_4()
		{
			var arrayList = new ArrayList()
			{
				"Den",
				"Met",
				(int)4,
				"Victor"
			};

			IEnumerable<string> result = arrayList.Cast<string>();

			foreach (string item in result)
			{
				Console.WriteLine(item);
			}
		}
	}
}
