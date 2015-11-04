
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CalculatePercent
{
	[Activity (Label = "Choose Calculation", Icon = "@drawable/percentIcon")]			
	public class PercentDrawer : Activity
	{

		DrawerLayout drawerLayout;
		ActionBarDrawerToggle drawerToggle;
		ListView drawerListView;

		Fragment[] fragments = new Fragment[]{new PercentFragment(), new DiscountFragment()};
		string[] calculationTitles = new string[]{"Percent","Discount","Split the bill"};

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			int calcNo = Intent.GetIntExtra("CalculationType",-1);

			SetContentView (Resource.Layout.PercentDrawer);

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
			drawerLayout.SetBackgroundColor(Android.Graphics.Color.AntiqueWhite);
			ColorDrawable colorDrawable = new ColorDrawable (Color.Black);
			this.ActionBar.SetBackgroundDrawable (colorDrawable);

			drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, Resource.String.DrawerOpenDescription, Resource.String.DrawerCloseDescription);

			drawerLayout.SetDrawerListener (drawerToggle);

			drawerListView = FindViewById<ListView> (Resource.Id.drawerListView);
			drawerListView.Adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, calculationTitles);
			drawerListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => OnMenuItemClick(e.Position);
			drawerListView.SetItemChecked (calcNo, true);
			OnMenuItemClick (calcNo);

			ActionBar.SetDisplayHomeAsUpEnabled (true);
		}

		void OnMenuItemClick (int position)
		{
			base.FragmentManager.BeginTransaction ().Replace (Resource.Id.frameLayout, fragments[position]).Commit ();
			this.Title = calculationTitles [position];
			drawerLayout.CloseDrawer (drawerListView);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (drawerToggle.OnOptionsItemSelected (item)) 
				return true;			

			return base.OnOptionsItemSelected (item);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			drawerToggle.SyncState ();
			base.OnPostCreate (savedInstanceState);
		}
	}
}

