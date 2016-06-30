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
                return DataStore<Account>.GetInstance(DataStoreType.NETWORK, "Account", KinveyClient.GetInstance());

                //var a = KinveyClient.GetInstance().AppData<Account>("Account", DataStoreType.SYNC);
                //var client = KinveyClient.GetInstance();
                //var a = DataStore<Account>.GetInstance( DataStoreType.NETWORK, "Account", client);
                //return a;
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllAccountNames()
        {
            List<string> accountNames = new List<string>();

            try
            {
                KinveyObserver<Account> observer = new KinveyObserver<Account>()
                {
                    onSuccess = (accounts) => {
                        foreach (var account in accounts)
                            accountNames.Add(account.Name);
                    },
                    onError = (e) => Console.WriteLine(e.Message),
                    onCompleted = () => Console.WriteLine("completed")
                };

                await AccountStore.FindAsync(observer);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }

            return await System.Threading.Tasks.Task.Run(() => accountNames);
        }
    }
}