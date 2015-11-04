
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Graphics;

namespace CalculatePercent
{
	public class DiscountFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.Discount, container, false);

			var discount = view.FindViewById<EditText> (Resource.Id.discountEditText);
			var price = view.FindViewById<EditText> (Resource.Id.priceEditText);
			var finalPrice = view.FindViewById<TextView> (Resource.Id.discountResultValue);
			var calculateButton = view.FindViewById<Button> (Resource.Id.discountCalculateButton);

			discount.SetBackgroundColor (Color.Black);
			price.SetBackgroundColor (Color.Black);

			//Get fragment's associated Activity context
			Activity context = this.Activity;

			finalPrice.Text = "---";

			calculateButton.Click+= (object sender, EventArgs e) => 
			{
				//Dismiss keyboard
				InputMethodManager imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow (context.CurrentFocus.WindowToken, 0);

				try{
					if ((!String.IsNullOrEmpty(discount.Text)&&(!String.IsNullOrEmpty(price.Text)))){
						int dscnt = Convert.ToInt16 (discount.Text);
						int prc = Convert.ToInt16 (price.Text);
						double rslt = (double)(prc * dscnt) / 100;
						finalPrice.Text = (prc - rslt).ToString();
					}
					else
					{
						Toast.MakeText(context,"Empty field!",ToastLength.Short).Show();
					}
				}
				catch(Exception exc)
				{
					Console.WriteLine("EXCEPTION!!! = "+exc.ToString());
				}
			};



			return view;
		}
	}
}

