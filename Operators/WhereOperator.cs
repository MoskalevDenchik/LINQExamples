﻿#region Using

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
	public class WhereOperator
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
		public void Where_Example_1() // Simple where
		{
			IEnumerable<Employee> extResult = _employees.Where(employee => employee.Experience > 3);

			IEnumerable<Employee> exprResult = from employee in _employees
											   where employee.Experience > 3
											   select employee;

			extResult.Show(item => $"{item.FirstName} - {item.Experience}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Where_Example_2() // With index
		{
			var extResult = _employees.Where((employee, index) => index > 2 && employee.Experience > 1);

			extResult.Show(item => $"{item.FirstName} - {item.Experience}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}