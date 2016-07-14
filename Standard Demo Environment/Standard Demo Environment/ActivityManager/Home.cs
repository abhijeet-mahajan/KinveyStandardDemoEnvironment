using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace Standard_Demo_Environment
{
    [Activity(Label = "Home", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class Home : CustomActivity
    {
        private ImageView HomeScreenLogo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            HomeScreenLogo = FindViewById<ImageView>(Resource.Id.homeScreenLogo);
            HomeScreenLogo.SetBackgroundResource(Resource.Drawable.kinvey_logo_black);   
            //HomeScreenLogo = new ImageView(this, null, Resource.Drawable.Icon);

            this.AddToolbar();
            this.AddSlidingDrawer();
        }

    }
}