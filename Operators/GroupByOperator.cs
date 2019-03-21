#region Using

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Helpers;
using Entities;

#endregion

namespace Operators
{
	[TestClass]
	public class GroupByOperator
	{
		#region Private fileds

		public List<Employee> _employees;

		public List<Department> _departments;

		#endregion

		#region Initialize

		[TestInitialize]
		public void Initialize()
		{
			_employees = DataProvider.GetEntities<Employee>();
			_departments = DataProvider.GetEntities<Department>();
		}

		#endregion

		// Standard grouping
		[TestMethod]
		public void GroupByMethod()
		{
			IEnumerable<IGrouping<string, Employee>> extGroups = _employees.GroupBy(employee => employee.DepartmentName);

			IEnumerable<IGrouping<string, Employee>> expGroups = from employee in _employees
																 group employee by employee.DepartmentName;



			foreach (var item in extGroups)
			{
				Console.WriteLine($"{item.Key} - {item.Count()}");
			}

			Console.WriteLine(new string('-', 50));

			foreach (var item in expGroups)
			{
				Console.WriteLine($"{item.Key} - {item.Count()}");
			}
		}


		// Grouping by anonymous types
		[TestMethod]
		public void GroupByMethod2()
		{
			var extGroups = _employees.GroupBy(employee => new { Department = employee.DepartmentName, employee.Experience });

			var expGroups = from employee in _employees
							group employee by new { Department = employee.DepartmentName, employee.Experience };



			foreach (var item in extGroups)
			{
				Console.WriteLine($"{item.Key.Department} | {item.Key.Experience} - {item.Count()}");
			}

			Console.WriteLine(new string('-', 50));

			foreach (var item in expGroups)
			{
				Console.WriteLine($"{item.Key.Department} | {item.Key.Experience} - {item.Count()}");
			}
		}


	}
}
