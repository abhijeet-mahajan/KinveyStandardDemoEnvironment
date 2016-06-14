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
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;

namespace Standard_Demo_Environment
{
    [Activity(Label = "Products", Theme = "@style/MyTheme")]
    public class ProductManager : CustomActivity
    {
        private List<string> productList;
        private ListView products;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductManager);

            this.AddToolbar();
            this.AddSlidingDrawer();

            productList = new List<string>();
            products = FindViewById<ListView>(Resource.Id.productsListView);

            await DisplayProductsList();
        }

        public async System.Threading.Tasks.Task DisplayProductsList()
        {
            ProductResourceManager manager = new ProductResourceManager();
            productList = await manager.GetAllProductNames();

            ArrayAdapter<string> accountAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, productList);
            products.Adapter = accountAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_item, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override async void OnRefreshClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            await DisplayProductsList();
            Toast.MakeText(this, "Products", ToastLength.Short).Show();
            base.OnRefreshClicked(sender, e);
        }

        public override void OnAddItemClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            base.OnAddItemClicked(sender, e);
        }

    }
}