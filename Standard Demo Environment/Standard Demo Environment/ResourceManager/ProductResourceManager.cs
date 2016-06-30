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
        public DataStore<Product> ProductStore
        {
            get
            {
                return DataStore<Product>.GetInstance(DataStoreType.NETWORK, "Products", KinveyClient.GetInstance());
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllProductNames()
        {
            List<string> productNames = new List<string>();

            try
            {
                KinveyObserver<Product> observer = new KinveyObserver<Product>()
                {
                    onSuccess = (products) => {
                        foreach (var product in products)
                            productNames.Add(product.Title);
                    },
                    onError = (e) => Console.WriteLine(e.Message),
                    onCompleted = () => Console.WriteLine("completed")
                };

                await ProductStore.FindAsync(observer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }
            return await System.Threading.Tasks.Task.Run(() => productNames);
        }
    }
}