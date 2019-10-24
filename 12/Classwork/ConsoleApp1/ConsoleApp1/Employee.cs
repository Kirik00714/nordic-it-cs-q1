namespace ConsoleApp1
{
	class Employee : Person
	{
		public string Company { get; set; }

		public new string Description =>
			$"{base.Description}, company {Company}";

		
	}
}
