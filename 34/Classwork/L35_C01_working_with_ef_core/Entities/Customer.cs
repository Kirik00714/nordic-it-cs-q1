using System.Collections.Generic;

namespace L35_C01_working_with_ef_core.Entities
{
	public class Customer
	{
		public int Id { get; private set; }
		public string Firstname { get; set; }
		public string Lastname { get; private set; }
		public ICollection<Order> Orders { get; private set; }

		private Customer()
		{
			Orders = new List<Order>();
		}

		public Customer(string name, string lastname) : this()
		{
			Firstname = name;
			Lastname = lastname;
		}
	}
}
