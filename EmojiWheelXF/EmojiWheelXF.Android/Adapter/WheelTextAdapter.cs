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
    public class WheelTextAdapter : CursorWheelLayout.CycleWheelAdapter
    {
        private Context mContext;
        private List<MenuItemData> menuItems;
        private LayoutInflater layoutInflater;
        private GravityFlags mGravity;

        public WheelTextAdapter(Context mContext, List<MenuItemData> menuItems)
        {
            this.mContext = mContext;
            this.menuItems = menuItems;
            layoutInflater = LayoutInflater.FromContext(mContext);
            mGravity = GravityFlags.Center;
        }
        public override int Count => menuItems.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override View GetView(View view, int position)
        {
            var itemData = menuItems[position];
            View root = layoutInflater.Inflate(Resource.Layout.WheelTextLayout, null, false);
            TextView textView = root.FindViewById<TextView>(Resource.Id.wheel_menu_item_tv);
            textView.Visibility = ViewStates.Visible;
            textView.SetTextSize(Android.Util.ComplexUnitType.Sp, 14);
            textView.Text = itemData.mTitle;
            if (textView.LayoutParameters is FrameLayout.LayoutParams)
                ((FrameLayout.LayoutParams)textView.LayoutParameters).Gravity = mGravity;
            if (position == 4)
                textView.SetTextColor(Android.Graphics.Color.Red);
            if (position == 0)
            {
                FrameLayout container = root.FindViewById<FrameLayout>(Resource.Id.TextContainer);
                container.SetBackgroundColor(Android.Graphics.Color.Transparent);
                container.SetBackgroundResource(Resource.Drawable.slice_happy);
                container.SetMinimumHeight(340);
                container.SetPadding(0, 0, 0, 0);
                //container.s
            }
            return root;
        }
    }
}