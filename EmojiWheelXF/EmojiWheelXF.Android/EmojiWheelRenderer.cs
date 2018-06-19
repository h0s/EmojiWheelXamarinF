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
using EmojiWheelXF;
using EmojiWheelXF.Droid;
using EmojiWheelXF.Droid.Adapter;
using EmojiWheelXF.Droid.Data;
using Github.Hellocsl.Cursorwheel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(EmojiWheel), typeof(EmojiWheelRenderer))]

namespace EmojiWheelXF.Droid
{
    public class EmojiWheelRenderer : ViewRenderer, CursorWheelLayout.IOnMenuSelectedListener
    {
        public EmojiWheelRenderer(Context context) : base(context)
        {

          
        }
       
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            var view = ((Activity)this.Context).LayoutInflater.Inflate(Resource.Layout.Main, null);
            SetNativeControl(view);
            InitViews();
            LoadData();

            wheel_image.SetOnMenuSelectedListener(this);
            wheel_image.SetBackgroundColor(Android.Graphics.Color.Transparent);
           
        }
        CursorWheelLayout wheel_image { get; set; }
        //CursorWheelLayout wheel_text;
        List<ImageData> FirstImage { get; set; }
        //List<MenuItemData> FirstText;
        ImageView eclipse { get; set; }
        private void InitViews()
        {
            wheel_image = FindViewById<CursorWheelLayout>(Resource.Id.wheel_image);
            FirstImage = new List<ImageData>();
            eclipse = FindViewById<ImageView>(Resource.Id.WheelContainer);
            //wheel_text = FindViewById<CursorWheelLayout>(Resource.Id.wheel_text);
        }
        private void LoadData()
        {
            eclipse.SetBackgroundResource(Resource.Drawable.eclipse_cover);

            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_happy, ImageDescription = "Happy" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_peacefull, ImageDescription = "Peaceful" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_content, ImageDescription = "Content" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_okay, ImageDescription = "Okay" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_sad, ImageDescription = "Sad" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_bored, ImageDescription = "Bored" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_worried, ImageDescription = "Worried" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_angry, ImageDescription = "Angry" });
            WheelImageAdapter imageAdapter = new WheelImageAdapter(this.Context, FirstImage);
            wheel_image.SetAdapter(imageAdapter);

            //Number Wheel Start
            //FirstText = new List<MenuItemData>();
            //for (int i = 0; i < 9; i++)
            //    FirstText.Add(new MenuItemData() { mTitle = Convert.ToString(i) });
            //FirstText.Add(new MenuItemData() { mTitle = "OFF" });
            //WheelTextAdapter textAdapter = new WheelTextAdapter(BaseContext, FirstText);
            //wheel_text.SetAdapter(textAdapter);
            //Number Wheel End
        }
        public void OnItemSelected(CursorWheelLayout wheel, View view, int position)
        {
            //if (wheel.Id == Resource.Id.wheel_text)
            //{
            //    Toast.MakeText(BaseContext, "Selected: " + FirstText[position].mTitle, ToastLength.Short).Show();
            //}
            //else 
            if (wheel.Id == Resource.Id.wheel_image)
            {
                Toast.MakeText(this.Context, "Selected: " + FirstImage[position].ImageDescription, ToastLength.Short).Show();
            }
        }

        public void OnItemSelected(CursorWheelLayout p0, Android.Views.View p1, int p2)
        {
            Toast.MakeText(this.Context, "Selected: " + FirstImage[p2].ImageDescription, ToastLength.Short).Show();

        }
    }
}