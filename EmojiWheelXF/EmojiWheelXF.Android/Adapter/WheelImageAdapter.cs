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
using EmojiWheelXF.Droid.Data;
using Github.Hellocsl.Cursorwheel;

namespace EmojiWheelXF.Droid.Adapter
{
    public class WheelImageAdapter : CursorWheelLayout.CycleWheelAdapter
    {
        private Context mContext;
        private List<ImageData> menuItems;
        private LayoutInflater layoutInflater;
        private GravityFlags mGravity;

        public WheelImageAdapter(Context mContext, List<ImageData> menuItems)
        {
            this.mContext = mContext;
            this.menuItems = menuItems;
            this.layoutInflater = LayoutInflater.From(mContext);
        }

        public override int Count => menuItems.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override View GetView(View view, int position)
        {
            ImageData item = menuItems[position];
            View root = layoutInflater.Inflate(Resource.Layout.WheelImageLayout, null, false);
            ImageView imgView = root.FindViewById<ImageView>(Resource.Id.wheel_menu_item_iv);
            imgView.SetImageResource(item.ImageResource);

            RelativeLayout container = root.FindViewById<RelativeLayout>(Resource.Id.emoji_container);
            container.SetBackgroundColor(Android.Graphics.Color.Transparent);
            switch (position)
            {
                case 0:
                    container.SetBackgroundResource(Resource.Drawable.slice_happy);
                    break;
                case 1:
                    container.SetBackgroundResource(Resource.Drawable.slice_peaceful);
                    break;
                case 2:
                    container.SetBackgroundResource(Resource.Drawable.slice_content);
                    break;
                case 3:
                    container.SetBackgroundResource(Resource.Drawable.slice_okay);
                    break;
                case 4:
                    container.SetBackgroundResource(Resource.Drawable.slice_sad);
                    break;
                case 5:
                    container.SetBackgroundResource(Resource.Drawable.slice_bored);
                    break;
                case 6:
                    container.SetBackgroundResource(Resource.Drawable.slice_worried);
                    break;
                case 7:
                    container.SetBackgroundResource(Resource.Drawable.slice_angry);
                    break;
            }
            container.ScaleX = 2.21f;
            container.ScaleY = 2.79f;
            imgView.ScaleX = 0.25f;
            imgView.ScaleY = 0.20f;

            return root;
        }
    }
}