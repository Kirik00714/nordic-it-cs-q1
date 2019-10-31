using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public ErrorList(string category, List<string> errors)
		{
			Category = category;
			Errors = errors;
		}

		public string Category { get; set; }
		private List<string> Errors; 
		public void Dispose()
		{
			Errors.Clear();
			Errors = null;
		}
		public void Add(string errorMEssage)
		{
			Errors.Add(errorMEssage);
			
		}


		public IEnumerator<string> GetEnumerator()
		{
			return Errors.GetEnumerator() ;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
