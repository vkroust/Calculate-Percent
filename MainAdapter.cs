
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
using Android.Graphics.Drawables;

namespace CalculatePercent
{
	[Activity (Label = "MainAdapter")]			
	public class MainAdapter : BaseAdapter<Calculation>
	{
		Activity context;
		List<Calculation> calculations;

		public MainAdapter(Activity context, List<Calculation> calculations)
		{
			this.context = context;
			this.calculations = calculations;
		}			
		
		public override Calculation this[int position]
		{
			get{
				return calculations [position];
			}
		}


		public override long GetItemId (int position)
		{
			return position;
		}


		public override int Count {
			get 
			{
				return calculations.Count;
			}
		}


		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			
			if (view == null) 
			{
				view = context.LayoutInflater.Inflate (Resource.Layout.MainListRow, parent, false);

				var image = view.FindViewById<ImageView> (Resource.Id.calculationImage);
				var title = view.FindViewById<TextView> (Resource.Id.calculationTitleText);
				var details = view.FindViewById<TextView> (Resource.Id.calculationDetailsText);

				view.Tag = new ViewHolder () { Image = image, Title = title, Details = details };
			}

			var holder = (ViewHolder)view.Tag;

			holder.Image.SetImageDrawable(Drawable.CreateFromStream(context.Assets.Open(calculations[position].ImageUrl),null));
			holder.Title.Text = calculations [position].Title;
			holder.Details.Text = calculations [position].Details;

			return view;
		}
		
	}
}

