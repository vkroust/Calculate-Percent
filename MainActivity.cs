using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CalculatePercent
{
	[Activity (Label = "CalculatePercent", Icon = "@drawable/percentIcon")]
	public class MainActivity : Activity
	{
		Intent intent;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			intent = new Intent (this, typeof(PercentDrawer));

			var layout = FindViewById<LinearLayout> (Resource.Id.mainLayout);
			layout.SetBackgroundColor (Android.Graphics.Color.AntiqueWhite);

			ColorDrawable colorDrawable = new ColorDrawable (Color.Black);
			this.ActionBar.SetBackgroundDrawable (colorDrawable);

			var listView = FindViewById<ListView> (Resource.Id.mainListView);

			listView.Adapter = new MainAdapter (this, CalculationData.Calculations);

			listView.ItemClick += ListView_ItemClick;
		}

		void ListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			switch (e.Position) 
			{
			case 0:
				intent.PutExtra ("CalculationType", 0);
				StartActivity (intent);
				break;
			case 1:
				intent.PutExtra ("CalculationType", 1);
				StartActivity (intent);
				break;
			case 2:
				intent.PutExtra ("CalculationType", 2);
				StartActivity (intent);
				break;
			}
			
		}
	}
}


