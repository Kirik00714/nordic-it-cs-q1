using System;

namespace ConsoleApp1
{
	class RDG : EventArgs
	{
		public RDG(int dS, int bDTRE)
		{
			DS = dS;
			this.bDTRE = bDTRE;
		}

		public int DS {get; set;}
		public int bDTRE { get; set; }

	}
}
