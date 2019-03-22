#region Using

using System;
using System.Linq;
using System.Collections.Generic;

using Helpers;
using Entities;
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

			exprResult.Show(item => $" {item.FirstName} - {item.Experience}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void Select_Example_2()
		{
			IEnumerable<string> exprResult = _employees.Select(employee => employee.FirstName);

			IEnumerable<string> extResult = from employee in _employees
											select employee.FirstName;

			exprResult.Show(item => item);
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


			exprResult.Show(item => $"{item.Name} - {item.Department} - {item.Experience}");
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

			exprResult.Show(item => $"{item.Name} - {item.Department} - {item.Experience}");
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

			extResult.Show(item => $"{item.Name} - {item.Department} - {item.Experience} - {item.Index}");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void SelectMany_Example_6()
		{
			IEnumerable<List<Phone>> extResult = _employees.Select(employee => employee.Phones);

			IEnumerable<Phone> extResultMany = _employees.SelectMany(employee => employee.Phones);

			foreach (List<Phone> list in extResult)
			{
				foreach (Phone item in list)
				{
					Console.WriteLine($"{item.Number} - {item.Type}");
				}
			}

			Console.WriteLine(new string('-', 50));

			foreach (Phone item in extResultMany)
			{
				Console.WriteLine($"{item.Number} - {item.Type}");
			}
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void SelectMany_Example_7()
		{
			var collectionA = new[] { 1, 2, 3, 4, 5 };
			var collectionB = new[] { 1, 2, 3, 4, 5 };

			var result = from a in collectionA
						 from b in collectionB
						 select new
						 {
							 a,
							 b
						 };

			result.Show(item => $"{item.a} - {item.b}");
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
