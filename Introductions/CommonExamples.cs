#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entities;
using Helpers;

#endregion

namespace Introductions
{
	[TestClass]
	public class CommonExamples
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

		[TestMethod]
		public void Example_1()
		{
			var result = (from employee in _employees
						  where employee.Experience > 1
						  group employee by employee.DepartmentName into grouping
						  select new
						  {
							  Department = grouping.Key,
							  Count = grouping.Count()

						  }).First();

			Console.WriteLine($"{ result.Department} - { result.Count} ");
		}

		[TestMethod]
		public void Example_2()
		{

		}

	}
}
