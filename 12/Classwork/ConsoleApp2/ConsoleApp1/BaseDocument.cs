﻿using System;

namespace ConsoleApp2
{
	class BaseDocument
	{
		public virtual string Title { get; set; }
		public  virtual string Number { get; set; }
		public virtual DateTime IssueDate { get; set; }
		public virtual string Description
		{
			get
			{
				return $"Name document {Title} , number document {Number}, date {IssueDate}";
			}
		}
		public virtual void WriteToConsole()
		{
			Console.WriteLine(Description);
		}
	}
}
