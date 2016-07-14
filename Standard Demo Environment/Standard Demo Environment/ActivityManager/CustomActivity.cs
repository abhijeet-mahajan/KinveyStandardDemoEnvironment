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
using Android.Support.V7.App;
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Net;

namespace Standard_Demo_Environment
{
    public class CustomActivity : AppCompatActivity
    {
        private SupportToolBar toolbar;
        private ListView optionsDrawer;
        private List<string> optionsList;

        private DrawerLayout drawerLayout;
        private ToolbarDrawerToggle hamburger;


        protected void AddToolbar()
        {
            toolbar = FindViewById<SupportToolBar>(Standard_Demo_Environment.Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            toolbar.MenuItemClick += Toolbar_MenuItemClick;

            this.AddHamburger();
        }

        protected void AddHamburger()
        {
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            hamburger = new ToolbarDrawerToggle(
                this,
                drawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            drawerLayout.AddDrawerListener(hamburger);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            hamburger.SyncState();

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            hamburger.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }


        protected void AddSlidingDrawer()
        {
            optionsList = new List<string>();
            optionsList.Add("Home");
            optionsList.Add("Accounts");
            optionsList.Add("Tasks");
            optionsList.Add("Products");
            optionsList.Add("Logout");

            optionsDrawer = FindViewById<ListView>(Resource.Id.leftDrawer);
            ArrayAdapter<string> optionsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, optionsList);
            optionsDrawer.Adapter = optionsAdapter;

            optionsDrawer.ItemClick += OnOptionSelected;
        }

        protected void Toolbar_MenuItemClick(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            if(e.Item.ToString()=="Refresh")
            {
                this.OnRefreshClicked(sender,e);
            }
            else if (e.Item.ToString() == "Add")
            {
                this.OnAddItemClicked(sender, e);
            }
        }

        public virtual  void OnRefreshClicked(object sender, SupportToolBar.MenuItemClickEventArgs e) {}

        public virtual  void OnAddItemClicked(object sender, SupportToolBar.MenuItemClickEventArgs e){}

        protected void OnOptionSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectedOption = optionsList[e.Position];

            if (selectedOption == "Home")
            {
                Toast.MakeText(this, selectedOption, ToastLength.Short).Show();
                GoHome(sender, e);
            }
            else if (selectedOption == "Accounts")
            {
                Toast.MakeText(this, selectedOption, ToastLength.Short).Show();
                FetchAccounts(sender, e);
            }
            else if (selectedOption == "Tasks")
            {
                Toast.MakeText(this, selectedOption, ToastLength.Short).Show();
                FetchTasks(sender, e);
            }
            else if (selectedOption == "Products")
            {
                Toast.MakeText(this, selectedOption, ToastLength.Short).Show();
                FetchProducts(sender, e);
            }
            else if (selectedOption == "Logout")
                BeginLogout();

        }

        protected void GoHome(object sender, EventArgs e)
        {
            Intent home = new Intent(this, typeof(Home));
            this.StartActivity(home);
        }

        protected void FetchProducts(object sender, EventArgs e)
        {
            Intent accounts = new Intent(this, typeof(ProductManager));
            this.StartActivity(accounts);
        }

        protected void FetchTasks(object sender, EventArgs e)
        {
            Intent accounts = new Intent(this, typeof(TaskManager));
            this.StartActivity(accounts);
        }

        protected void FetchAccounts(object sender, EventArgs e)
        {
            Intent accounts = new Intent(this, typeof(AccountManager));
            this.StartActivity(accounts);
        }

        protected void BeginLogout()
        {
            if (AuthenticationManager.Logout())
            {
                Toast.MakeText(this, "User Logged Out", ToastLength.Short).Show();
                Intent mainActivity = new Intent(this, typeof(Authenticate));
                this.StartActivity(mainActivity);
            }
            else
                Toast.MakeText(this, "Logout Failed", ToastLength.Short).Show();
        }


    }
}