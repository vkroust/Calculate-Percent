﻿
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
using System.Threading;

namespace CalculatePercent
{
	[Activity (Label = "Splash", MainLauncher = true, Icon = "@drawable/percentIcon", Theme = "@style/Theme.Splash", NoHistory = true)]			
	public class SplashActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

//			Thread.Sleep (1000);

			StartActivity (typeof(MainActivity));

		}
	}
}

