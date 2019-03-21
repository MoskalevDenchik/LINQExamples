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
	public class ConcatOperations
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
		public void Concat_Example_1()
		{
			var newEmployees = new List<Employee>
			{
				new Employee {FirstName = "SomeName", Experience = 3, LastName = "SomeLastName",DepartmentName = "SomeDepartmentsName"},
				new Employee {FirstName = "SomeName", Experience = 4, LastName = "SomeLastName",DepartmentName = "SomeDepartmentsName"},
				new Employee {FirstName = "SomeName", Experience = 5, LastName = "SomeLastName",DepartmentName = "SomeDepartmentsName"}
			};

			IEnumerable<Employee> result = _employees.Concat(newEmployees);

			foreach (Employee item in result)
			{
				Console.WriteLine($" {item.FirstName} - {item.Experience} - {item.DepartmentName}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
