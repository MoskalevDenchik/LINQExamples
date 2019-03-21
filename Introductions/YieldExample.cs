#region Using

using System;
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
			IEnumerable<int> elements = GetElements();

			foreach (int item in elements)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private methods

		private IEnumerable<int> GetElements()
		{
			var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10 };

			foreach (int item in list)
			{
				if (item > 4)
				{
					yield return item;
				}
			}

			yield return 5;

		}

		#endregion

	}
}
