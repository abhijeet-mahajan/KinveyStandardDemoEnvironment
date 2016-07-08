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
using SQLite.Net.Platform.XamarinAndroid;

namespace Standard_Demo_Environment
{
    public class AccountResourceManager
    {
        public DataStore<Account> AccountStore
        {
            get
            {
                var store = DataStore<Account>.GetInstance(DataStoreType.SYNC, "Account", KinveyClient.GetInstance());
                //                store.setOffline(null);
                return store;
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllAccountNames()
        {
            List<string> accountNames = new List<string>();

            try
            {
                //KinveyObserver<Account> observer = new KinveyObserver<Account>()
                //{
                //    onSuccess = (accounts) =>
                //    {
                //        foreach (var account in accounts)
                //            accountNames.Add(account.Name);
                //    },
                //    onError = (e) => Console.WriteLine(e.Message),
                //    onCompleted = () => Console.WriteLine("completed")
                //};
                //await AccountStore.FindAsync(observer);

                var accounts = await AccountStore.PullAsync();

                foreach (var account in accounts)
                    accountNames.Add(account.Name);

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }

            return await System.Threading.Tasks.Task.Run(() => accountNames);
        }

        public async System.Threading.Tasks.Task<Account> CreateNewAccount(Account account)
        {
            Account createdAccount = null;

            try
            {
//                var accounts = await AccountStore.PullAsync();
                createdAccount = await AccountStore.SaveAsync(account);
                var response =await AccountStore.SyncAsync();
                Console.WriteLine();
                //createdAccount = await AccountStore.SaveAsync(account);
            }
            catch (Exception e)
            {
                return null;
            }
            return await System.Threading.Tasks.Task.Run(() => createdAccount);
        }


    }
}