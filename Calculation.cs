using System;

namespace CalculatePercent
{
	public class Calculation
	{
		public Calculation (){}

		public string Title;
		public string ImageUrl;
		public string Details;

		public override string ToString ()
		{
			return Title + " " + Details;
		}
	}
}

