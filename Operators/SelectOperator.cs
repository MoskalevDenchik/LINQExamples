#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operators
{
	[TestClass]
	public class SelectOperator
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

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_1()
		{
			var extResult = _employees.Where(employee => employee.Experience > 2);

			var exprResult = from employee in _employees
							 where employee.Experience > 2
							 select employee;


			foreach (Employee item in exprResult)
			{
				Console.WriteLine($" {item.FirstName} - {item.Experience}");
			}

		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_2()
		{
			IEnumerable<string> exprResult = _employees.Select(employee => employee.FirstName);

			IEnumerable<string> extResult = from employee in _employees
											select employee.FirstName;

			foreach (string item in exprResult)
			{
				Console.WriteLine(item);
			}

		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_3()
		{
			var extResult = _employees.Select(employee => new CustomEmployee
			{
				Name = employee.FirstName,
				Department = employee.DepartmentName,
				Experience = employee.Experience
			});

			var exprResult = from employee in _employees
							 select new CustomEmployee
							 {
								 Name = employee.FirstName,
								 Department = employee.DepartmentName,
								 Experience = employee.Experience
							 };


			foreach (CustomEmployee item in exprResult)
			{
				Console.WriteLine($"{item.Name} - {item.Department} - {item.Experience}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_4()
		{
			var extResult = _employees.Select(employee => new
			{
				Name = employee.FirstName,
				Department = employee.DepartmentName,
				employee.Experience
			});

			var exprResult = from employee in _employees
							 select new
							 {
								 Name = employee.FirstName,
								 Department = employee.DepartmentName,
								 employee.Experience
							 };


			foreach (var item in exprResult)
			{
				Console.WriteLine($"{item.Name} - {item.Department} - {item.Experience}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_5() // with index 
		{
			var extResult = _employees.Select((employee, index) => new
			{
				Name = employee.FirstName,
				Department = employee.DepartmentName,
				employee.Experience,
				Index = index
			});


			foreach (var item in extResult)
			{
				Console.WriteLine($"{item.Name} - {item.Department} - {item.Experience} - {item.Index}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private members

		private class CustomEmployee
		{
			public string Name { get; set; }

			public string Department { get; set; }

			public int Experience { get; set; }
		}

		#endregion
	}
}
