#region Using

using System.Collections.Generic;

#endregion

namespace Entities
{
	public class Employee
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string DepartmentName { get; set; }

		public List<Phone> Phones { get; set; }

		public int Experience { get; set; }
	}
}
