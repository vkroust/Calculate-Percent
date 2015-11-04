
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
	public class PercentFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.Percent, container, false);

			var percent = view.FindViewById<EditText> (Resource.Id.percentEditText);
			var value = view.FindViewById<EditText> (Resource.Id.valueEditText);
			var result = view.FindViewById<TextView> (Resource.Id.percentResultValue);
			var calculateButton = view.FindViewById<Button> (Resource.Id.calculateButton);

			percent.SetBackgroundColor (Color.Black);
			value.SetBackgroundColor (Color.Black);

			//Get fragment's associated Activity context
			Activity context = this.Activity;

			result.Text = "---";

			calculateButton.Click+= (object sender, EventArgs e) => 
			{
				//Dismiss keyboard
				InputMethodManager imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow (context.CurrentFocus.WindowToken, 0);

				try{
					if ((!String.IsNullOrEmpty(percent.Text)&&(!String.IsNullOrEmpty(value.Text)))){
						int prcnt = Convert.ToInt16 (percent.Text);
						int vl = Convert.ToInt16 (value.Text);
						double rslt = (double)(vl * prcnt) / 100;
						result.Text = rslt.ToString();
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

