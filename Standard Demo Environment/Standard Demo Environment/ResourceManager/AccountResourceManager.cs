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
using Android.Net;

namespace Standard_Demo_Environment
{
    public class AccountResourceManager
    {
        private DataStore<Account> _store;

        private DataStore<Account> GetAccountStore()
        {
            if (_store != null)
                return _store;
            _store = DataStore<Account>.GetInstance(DataStoreType.SYNC, "Account", KinveyClient.GetInstance());
            return _store;
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllAccountNames()
        {
            List<string> accountNames = new List<string>();
            List<Account> accounts;

            try
            {
                var response = await GetAccountStore().SyncAsync();
                accounts = await GetAccountStore().PullAsync();
                foreach (var account in accounts)
                    accountNames.Add(account.Name);
            }
            catch (Exception ex)
            {
                KinveyObserver<Account> observer = new KinveyObserver<Account>()
                {
                    onSuccess = (offlineAccounts) =>
                    {
                        foreach (var account in offlineAccounts)
                            accountNames.Add(account.Name);
                    },
                    onError = (e) => Console.WriteLine(e.Message),
                    onCompleted = () => Console.WriteLine("completed")
                };

                await GetAccountStore().FindAsync(observer);

            }

            return await System.Threading.Tasks.Task.Run(() => accountNames);
        }

        public async System.Threading.Tasks.Task<Account> CreateNewAccount(Account account)
        {
            Account createdAccount = null;

            try
            {
                //                var accounts = await AccountStore.PullAsync();
                createdAccount = await GetAccountStore().SaveAsync(account);

                try
                {
                    var response = await GetAccountStore().SyncAsync();
                }
                catch
                {
                    //                    Toast.MakeText(this,"No Internet Access!! Data Saved Locally",ToastLength.Short).Show();
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return await System.Threading.Tasks.Task.Run(() => createdAccount);
        }


    }
}