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
	public class ConvertingOperations
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
		public void ToArray_Example_1()
		{
			Employee[] resultArray = _employees
									 .Where(item => item.Experience > 1)
									 .ToArray();

			resultArray.Show(item => $"{item.FirstName} - {item.DepartmentName} ");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void ToList_Example_2()
		{
			List<Employee> resultList = _employees
										.Where(item => item.Experience > 1)
										.ToList();

			resultList.Show(item => $"{item.FirstName} - {item.DepartmentName} ");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void ToDictionary_Example_3()
		{
			Dictionary<string, IGrouping<string, Employee>> dictionaryResult = _employees
																			   .GroupBy(employee => employee.DepartmentName)
																			   .ToDictionary(grouping => grouping.Key, grouping => grouping);

			dictionaryResult.Show(item => $"{item.Key} - {item.Value.Count()} ");
		}

		//----------------------------------------------------------------------------------------------------------------------------//

		[TestMethod]
		public void ToLookUp_Example_4()
		{
			ILookup<string, Employee> lookUpResult = _employees
				.ToLookup(employee => employee.DepartmentName);

			lookUpResult.Show(item => $"{item.Key} - {item} ");
		}

		//----------------------------------------------------------------------------------------------------------------------------//
	}
}
