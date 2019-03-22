#region Using

using System.Linq;
using System.Collections.Generic;

using Helpers;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class RangeRepeatEmptyOperations
	{
		#region Private fileds

		public List<Employee> _employees;

		#endregion

		#region Initialize

		[TestInitialize]
		public void Initialize()
		{
			_employees = DataProvider.GetEntities<Employee>();
		}

		#endregion

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Range_Example_1()
		{
			IEnumerable<int> collection = Enumerable.Range(1, 20);

			collection.Show(item => item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Repeat_Example_2()
		{
			int index = 0;

			var collection = Enumerable.Repeat(new { Name = "Alex", Age = ++index }, 20);

			collection.Show(item => $"{item.Name} - {item.Age}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Empty_Example_3()
		{
			var collection = Enumerable.Empty<int>();

			collection.Show(item => $"{item}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
