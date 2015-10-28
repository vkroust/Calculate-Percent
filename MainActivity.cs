using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CalculatePercent
{
	[Activity (Label = "CalculatePercent", Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var layout = FindViewById<LinearLayout> (Resource.Id.mainLayout);
			layout.SetBackgroundColor (Android.Graphics.Color.AntiqueWhite);

			var listView = FindViewById<ListView> (Resource.Id.mainListView);

			listView.Adapter = new MainAdapter (this, CalculationData.Calculations);
		}
	}
}


