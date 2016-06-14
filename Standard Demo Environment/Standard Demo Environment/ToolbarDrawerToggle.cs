using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportToolbarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
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
    public class ToolbarDrawerToggle:SupportToolbarDrawerToggle
    {
        private AppCompatActivity HostActivity;
        private int OpenedResource;
        private int ClosedResource;


        public ToolbarDrawerToggle(AppCompatActivity host,DrawerLayout layout,int openedResource,int closedResource)
        :base(host,layout,openedResource,closedResource)
        {
            HostActivity = host;
            OpenedResource = openedResource;
            ClosedResource = closedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}