#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class TakeAndSkipOperations
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
		public void Take_Example_1()
		{
			IEnumerable<Employee> result = _employees.Take(4);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void TakeWhile_Example_2()
		{
			IEnumerable<Employee> result = _employees.TakeWhile(employee => employee.Experience > 1);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void TakeWhile_Example_3() // with index
		{
			IEnumerable<Employee> result = _employees.TakeWhile((employee, index) => employee.Experience > 0 && index < 4);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Skip_Example_4()
		{
			IEnumerable<Employee> result = _employees.Skip(4);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void SkipWhile_Example_5()
		{
			IEnumerable<Employee> result = _employees.SkipWhile(employee => employee.Experience > 1);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void SkipWhile_Example_6() // with index
		{
			IEnumerable<Employee> result = _employees.SkipWhile((employee, index) => employee.Experience > 1 && index < 4);

			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.FirstName} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
