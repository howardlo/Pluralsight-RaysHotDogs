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
using RaysHotDogs.Core.Model;
using RaysHotDogs.Utility;

namespace RaysHotDogs.Adapter
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> items;
        Activity context;

        public HotDogListAdapter(Activity context, List<HotDog> items) : base ()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override HotDog this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            // This is the first simple list
            //if(convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            //}
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

            // this is the second example using ActivityListItem (adds image)
            //var imageBitmap = ImageHelper.GetImageBitmapFromUrl($"http://gillcleerenpluralsight.blob.core.windows.net/files/{item.ImagePath}.jpg");
            //if (convertView == null)
            //{
            //    convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            //}
            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            //convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(imageBitmap);

            // this is the third example using a custom HotDogRowView (adds image)
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl($"http://gillcleerenpluralsight.blob.core.windows.net/files/{item.ImagePath}.jpg");
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }
    }
}