#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class PredicateOperations
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
		public void Any_Example_1()
		{
			bool result = _employees.Any();

			Console.WriteLine(result);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Any_Example_2()
		{
			bool result = _employees.Any(employee => employee.Experience > 1);

			Console.WriteLine(result);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void All_Example_3()
		{
			bool result = _employees.All(employee => employee.Experience > 1);

			Console.WriteLine(result);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Contains_Example_4()
		{
			var array = new[] { 1, 2, 3, 4, 5, 6 };

			bool result = array.Contains(2);

			Console.WriteLine(result);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Contains_Example_5()
		{
			var newEmployee = new Employee
			{
				FirstName = "Den",
				DepartmentName = "IT"
			};

			bool result = _employees.Contains(newEmployee, new EmployeeComparer());

			Console.WriteLine(result);
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private members

		private class EmployeeComparer : IEqualityComparer<Employee>
		{
			public bool Equals(Employee first, Employee second) =>
				first.FirstName.Equals(second.FirstName) && first.DepartmentName.Equals(second.DepartmentName);

			public int GetHashCode(Employee employee) =>
				employee.FirstName.GetHashCode() + employee.DepartmentName.GetHashCode();
		}

		#endregion
	}
}
