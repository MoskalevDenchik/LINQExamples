#region Using

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Helpers;
using Entities;

#endregion

namespace Operators
{
	[TestClass]
	public class OrderByOperator
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
		public void OrderBy_Example_1() // Standard ordering
		{
			IOrderedEnumerable<Employee> extGroups = _employees.OrderBy(employee => employee.Experience);

			IOrderedEnumerable<Employee> expGroups = from employee in _employees
													 orderby employee.Experience
													 select employee;

			extGroups.Show(item => $"{item.FirstName} - {item.Experience}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void OrderByDescending_Example_2() // Descending ordering
		{
			IOrderedEnumerable<Employee> extGroups = _employees.OrderByDescending(employee => employee.Experience);

			IOrderedEnumerable<Employee> expGroups = from employee in _employees
													 orderby employee.Experience descending
													 select employee;

			extGroups.Show(item => $"{item.FirstName} - {item.Experience}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void OrderBy_Example_3() // Mix ordering
		{
			IOrderedEnumerable<Employee> extGroups = _employees
													.OrderBy(employee => employee.Experience)
													.ThenBy(employee => employee.DepartmentName);

			IOrderedEnumerable<Employee> expGroups = from employee in _employees
													 orderby employee.Experience, employee.DepartmentName
													 select employee;

			extGroups.Show(item => $"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void OrderBy_Example_4() // Problem with ordering
		{
			IOrderedEnumerable<Employee> extGroups = _employees
				.OrderBy(employee => employee.DepartmentName)
				.OrderBy(employee => employee.Experience); // <----

			extGroups.Show(item => $"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void OrderBy_Example_5() // Comparer
		{
			IOrderedEnumerable<Employee> extGroups = _employees
				.OrderBy(employee => employee, new EmployeeComparer());

			extGroups.Show(item => $"{item.FirstName} - {item.Experience} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private members

		private class EmployeeComparer : IComparer<Employee>
		{
			public int Compare(Employee x, Employee y)
			{
				return x.FirstName.Length + x.LastName.Length == y.FirstName.Length + y.LastName.Length
					? 0
					: x.FirstName.Length + x.LastName.Length > y.FirstName.Length + y.LastName.Length
						? 1
						: -1;
			}
		}

		#endregion
	}
}
