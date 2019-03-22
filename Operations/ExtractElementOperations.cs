#region Using

using System;
using System.Linq;
using System.Collections.Generic;

using Helpers;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class ExtractElementOperations
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
		public void First_Example_1()
		{
			Employee item = _employees.First();

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void First_Example_2()
		{
			Employee item = _employees.First(employee => employee.Experience > 1);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void First_Example_3()
		{
			Employee item = _employees.First(employee => employee.Experience > 10);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void FirstOrDefault_Example_4()
		{
			Employee item = _employees.FirstOrDefault(employee => employee.Experience > 10);

			Console.WriteLine(item == null ? "Nothing found" : item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Last_Example_5()
		{
			Employee item = _employees.Last();

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Last_Example_6()
		{
			Employee item = _employees.Last(employee => employee.Experience > 1);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Last_Example_7()
		{
			Employee item = _employees.Last(employee => employee.Experience > 10);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void LastOrDefault_Example_8()
		{
			Employee item = _employees.LastOrDefault(employee => employee.Experience > 10);

			Console.WriteLine(item == null ? "Nothing found" : item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Single_Example_9()
		{
			var array = new[] { 1 };

			Console.WriteLine(array.Single().ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Single_Example_10()
		{
			Employee item = _employees.Single(employee => employee.Experience == 5);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Single_Example_11()
		{
			Employee item = _employees.Single(employee => employee.Experience > 10);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void SingleOrDefault_Example_12()
		{
			Employee item = _employees.SingleOrDefault(employee => employee.Experience > 10);

			Console.WriteLine(item == null ? "Nothing found" : item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void ElementAt_Example_13()
		{
			Employee item = _employees.ElementAt(3);

			Console.WriteLine($"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ElementAt_Example_14()
		{
			Employee item = _employees.ElementAt(10);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void ElementAtOrDefault_Example_16()
		{
			Employee item = _employees.ElementAtOrDefault(10);

			Console.WriteLine(item == null ? "Nothing found" : item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
