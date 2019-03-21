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
		public void WhereMethod() // Simple where
		{
			IEnumerable<Employee> extResult = _employees.Where(employee => employee.Experience > 3);

			IEnumerable<Employee> exprResult = from employee in _employees
											   where employee.Experience > 3
											   select employee;


			foreach (Employee item in exprResult)
			{
				Console.WriteLine(item);
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void WhereMethod2() // With index
		{

			var extResult = _employees.Where((employee, index) => index > 2 && employee.Experience > 1);

			foreach (Employee item in extResult)
			{
				Console.WriteLine($"{item.FirstName} - {item.Experience}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
