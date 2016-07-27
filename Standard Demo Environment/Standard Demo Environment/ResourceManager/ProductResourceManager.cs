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
using KinveyXamarin;

namespace Standard_Demo_Environment
{
    public class ProductResourceManager
    {
        public DataStore<Product> _store;

        private DataStore<Product> GetProductStore()
        {
            if (_store != null)
            {
                return _store;
            }
            _store = DataStore<Product>.GetInstance(DataStoreType.SYNC, "Products", KinveyClient.GetInstance());
            return _store;

        }

        public async System.Threading.Tasks.Task<List<string>> GetAllProductNames()
        {
            List<string> productNames = new List<string>();

            try
            {
                var response = await GetProductStore().SyncAsync();
                var products = await GetProductStore().PullAsync();
                foreach (var product in products)
                    productNames.Add(product.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }
            return await System.Threading.Tasks.Task.Run(() => productNames);
        }
    }
}