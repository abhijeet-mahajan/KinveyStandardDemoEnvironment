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
    public class AccountResourceManager
    {
        public DataStore<Account> AccountStore
        {
            get
            {
                //var a = KinveyClient.GetInstance().AppData<Account>("Account", DataStoreType.SYNC);

                var a = DataStore<Account>.GetInstance( DataStoreType.NETWORK, "Account", KinveyClient.GetInstance());
                return a;
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllAccountNames()
        {
            List<string> accountNames = new List<string>();
            List<Account> accounts = new List<Account>();

            try
            {

                accounts = await AccountStore.FindAsync();

                //var accounts = await AccountStore.GetAsync();

                foreach (var account in accounts)
                    accountNames.Add(account.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }

            return await System.Threading.Tasks.Task.Run(() => accountNames);
        }
    }
}