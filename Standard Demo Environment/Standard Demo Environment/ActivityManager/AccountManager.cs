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
            this.AddSlidingDrawer();
            
            accounts = FindViewById<ListView>(Resource.Id.accountsListView);
            accountList = new List<string>();

            await DisplayAccountsList();
        }

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
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            AddNewAccount newAccount = new AddNewAccount();
            newAccount.Show(transaction, "Add New Task");

            base.OnAddItemClicked(sender, e);

            newAccount.createNewAccount += CreateNewAccount;
        }

        private async void CreateNewAccount(object sender, OnAddNewAccount e)
        {
            Account newAccount = new Account(e.AccountName, e.CompanyName);

            AccountResourceManager manager = new AccountResourceManager();
            var createdAccount = await manager.CreateNewAccount(newAccount);

            if (createdAccount != null)
            {
                Toast.MakeText(this, "New Account Created", ToastLength.Short).Show();
                await DisplayAccountsList();
            }
            else
            {
                Toast.MakeText(this, "Something went wrong", ToastLength.Short).Show();
            }
        }

    }
}