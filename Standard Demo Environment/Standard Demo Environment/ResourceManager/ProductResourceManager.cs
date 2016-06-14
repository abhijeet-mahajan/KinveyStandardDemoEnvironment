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
        public AsyncAppData<Product> ProductAppData
        {
            get
            {
                return KinveyClient.GetInstance().AppData<Product>("Products", typeof(Product));

                //                return KinveyClient.GetInstance().AppData<Product>("Products", typeof(Product));
                //return DataStore<Product>.GetInstance(DataStoreType.NETWORK, "Products", KinveyClient.GetInstance());


            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllProductNames()
        {
            List<string> productNames = new List<string>();

            try
            {
                //var client = 
                //var productStore = DataStore<Product>.GetInstance(DataStoreType.NETWORK, "Products",client );
                var products = await ProductAppData.GetAsync();
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