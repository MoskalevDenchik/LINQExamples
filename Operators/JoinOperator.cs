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
	public class JoinOperator
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

		// Standard join (inner)
		[TestMethod]
		public void JoinMethod()
		{
			var extGroups = _employees.Join(
				_departments, // inner collection or right collection
				employee => employee.DepartmentName, // outer key or left key
				department => department.Name, // inner key or right key
				(employee, department) => new // result selector
				{
					Name = employee.FirstName,
					employee.Experience,
					Department = department.Name
				});

			var expGroups = from employee in _employees
							join department in _departments
							on employee.DepartmentName equals department.Name
							select new
							{
								Name = employee.FirstName,
								employee.Experience,
								Department = department.Name
							};

			foreach (var item in extGroups)
			{
				Console.WriteLine($"{item.Name} - {item.Experience} - {item.Department}");
			}

			Console.WriteLine(new string('-', 50));

			foreach (var item in expGroups)
			{
				Console.WriteLine($"{item.Name} - {item.Experience} - {item.Department}");

			}
		}
	}
}
