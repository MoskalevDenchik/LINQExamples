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

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Join_Example_1() // Standard join (inner)
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

			extGroups.ShowAndCompareWith(expGroups, item => $"{item.Name} - {item.Experience} - {item.Department}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void GroupJoin_Example_2()
		{
			var expGroups = from department in _departments
							join employee in _employees
							on department.Name equals employee.DepartmentName into grouping
							select new
							{
								Department = department.Name,
								Employees = grouping
							};

			var extGroups = _departments.GroupJoin(
				_employees, // inner collection or right collection
				department => department.Name, // outer key or left key
				employee => employee.DepartmentName, // inner key or right key
				(department, employees) => new // result selector
				{
					Department = department.Name,
					Employees = employees
				});

			expGroups.ShowAndCompareWith(extGroups, item => $"{item.Department} - {item.Employees.Count()}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
