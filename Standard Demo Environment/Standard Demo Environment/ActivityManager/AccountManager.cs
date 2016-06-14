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
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using Android.Support.V4.Widget;
using Standard_Demo_Environment;


namespace Standard_Demo_Environment
{
    [Activity(Label = "Accounts", Theme = "@style/MyTheme")]
    public class AccountManager : CustomActivity
    {
        private ListView accounts;
        private List<string> accountList;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AccountManager);

                        this.AddToolbar();
            //
            //toolbar = FindViewById<SupportToolBar>(Standard_Demo_Environment.Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

            //toolbar.MenuItemClick += Toolbar_MenuItemClick;
            //



            this.AddSlidingDrawer();
            //
            //var optionsList = new List<string>();
            //optionsList.Add("Home");
            //optionsList.Add("Accounts");
            //optionsList.Add("Tasks");
            //optionsList.Add("Products");
            //optionsList.Add("Logout");

            //var optionsDrawer = FindViewById<ListView>(Resource.Id.leftDrawer);
            //ArrayAdapter<string> optionsAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, optionsList);
            //optionsDrawer.Adapter = optionsAdapter;

            //optionsDrawer.ItemClick += OnOptionSelected;
            //




            accounts = FindViewById<ListView>(Resource.Id.accountsListView);
            accountList = new List<string>();

            await DisplayAccountsList();
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    hamburger.OnOptionsItemSelected(item);
        //    return base.OnOptionsItemSelected(item);
        //}

        public async System.Threading.Tasks.Task DisplayAccountsList()
        {
            AccountResourceManager manager = new AccountResourceManager();
            accountList = await manager.GetAllAccountNames();

            ArrayAdapter<string> accountAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, accountList);
            accounts.Adapter = accountAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_item, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override async void OnRefreshClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            await DisplayAccountsList();
            Toast.MakeText(this, "Accounts", ToastLength.Short).Show();
            base.OnRefreshClicked(sender, e);
        }

        public override void OnAddItemClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            base.OnAddItemClicked(sender, e);
        }

    }
}