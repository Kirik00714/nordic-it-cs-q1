namespace ConsoleApp2
{
	class Passport : BaseDocument
	{
		public virtual string Country { get; set; }
		public virtual string PersonName { get; set; }
		public override  string Description
		{
			get
			{
				return $"{base.Description}, country {Country}, name is {PersonName}";
			}
		}
		
	}
}
