#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Introductions
{
	[TestClass]
	public class LazyExample
	{
		[TestMethod]
		public void Method_Example_1()
		{
			int[] array = { 1, 2, 3, 4 };

			IEnumerable<int> filter = array.Where(item => item > 2);

			array[0] = 4;

			foreach (int item in filter)
			{
				Console.WriteLine(item);
			}
		}
	}
}
