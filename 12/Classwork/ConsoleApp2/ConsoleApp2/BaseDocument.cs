using System;

namespace ConsoleApp2
{
	class BaseDocument
	{
		public string Title { get; set; }
		public string Number { get; set; }
		public DateTime IssueDate { get; set; }
		public string Description
		{
			get
			{
				return $"Name document {Title} , number document {Number}, date {IssueDate}";
			}
		}
		public void WriteToConsole()
		{
			Console.WriteLine(Description);
		}
	}
}
