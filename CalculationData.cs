using System;
using System.Linq;
using System.Collections.Generic;

namespace CalculatePercent
{
	public static class CalculationData
	{
		public static List<Calculation> Calculations;

		static CalculationData ()
		{
			var list = new List<Calculation> ();

			AddCalculations (list);

			Calculations = list;
		}

		static void AddCalculations(List<Calculation> calculations)
		{
			calculations.Add (new Calculation () {
				Title = "Calculate Percent",
				Details = "Give numer and percentage and get the result",
				ImageUrl = "images/percent.png"
			});
			calculations.Add (new Calculation () {
				Title = "Calculate Discount",
				Details = "Give price and percentage of discount and get the final price",
				ImageUrl = "images/discount.png"
			});
			calculations.Add (new Calculation () {
				Title = "Split the bill",
				Details = "Calculate how much money per person, including tip",
				ImageUrl = "images/tip.png"
			});
		}
	}
}

