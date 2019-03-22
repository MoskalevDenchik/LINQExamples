#region Using

using System.Linq;
using System.Collections.Generic;

using Helpers;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Operations
{
	[TestClass]
	public class DistinctUnionExceptIntersectOperations
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
		public void Distinct_Example_1()
		{
			var collection = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9, 1 };

			var result = collection.Distinct();

			result.Show(item => item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Distinct_Example_2()
		{
			var result = _employees.Distinct(new EmployeeComparer());

			result.Show(item => $"{item.FirstName} - {item.DepartmentName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Union_Example_3()
		{
			var first = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9, 1 };

			var second = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			var result = first.Union(second);

			result.Show(item => item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Union_Example_4()
		{
			var newEmployees = new List<Employee>
			{
				new Employee {FirstName = "Den", LastName = "Malkin", Experience = 3, DepartmentName = "SomeDepartmentsName"},
				new Employee {FirstName = "Vera", LastName = "SomeLastName", Experience = 4, DepartmentName = "SomeDepartmentsName"},
				new Employee {FirstName = "SomeName", LastName = "SomeLastName", Experience = 5, DepartmentName = "SomeDepartmentsName"}
			};

			var result = _employees.Union(newEmployees, new EmployeeComparer());

			result.Show(item => $"{item.FirstName} - {item.LastName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Except_Example_5()
		{
			var first = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9, 1 };

			var second = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			var result = first.Except(second);

			result.Show(item => item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Except_Example_6()
		{
			var second = _employees.Take(4);

			var result = _employees.Except(second, new EmployeeComparer());

			result.Show(item => $"{item.FirstName} - {item.LastName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Intersect_Example_7()
		{
			var first = new[] { 2, 3, 4, 5, 6, 7, 11, 23 };

			var second = new[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			var result = first.Intersect(second);

			result.Show(item => item.ToString());
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Intersect_Example_8()
		{
			var result = _employees
						.Take(5)
						.Intersect(_employees.Skip(4), new EmployeeComparer());

			result.Show(item => $"{item.FirstName} - {item.LastName}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		#region Private members

		private class EmployeeComparer : IEqualityComparer<Employee>
		{
			public bool Equals(Employee first, Employee second) =>
				first.DepartmentName.Equals(second.DepartmentName) && first.DepartmentName.Equals(second.DepartmentName);

			public int GetHashCode(Employee employee) =>
				employee.FirstName.GetHashCode() + employee.LastName.GetHashCode();
		}

		#endregion
	}
}