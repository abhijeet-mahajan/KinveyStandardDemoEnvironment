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

namespace Standard_Demo_Environment
{
    public class OnAddNewAccount : EventArgs
    {
        public string AccountName { get; set; }
        public string CompanyName { get; set; }

        public OnAddNewAccount(string accountName, string companyName)
        {
            AccountName = accountName;
            CompanyName = companyName;
        }
    }


    public class AddNewAccount: DialogFragment
    {
        private Button saveAccount;
        private EditText accountName;
        private EditText companyName;

        public event EventHandler<OnAddNewAccount> createNewAccount;

        View view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.AddNewAccount, container, false);

            saveAccount = view.FindViewById<Button>(Resource.Id.saveNewAccount);

            saveAccount.Click += SaveNewAccount;

            return view;
        }

        private void SaveNewAccount(object sender, EventArgs e)
        {
            accountName = view.FindViewById<EditText>(Resource.Id.newAccountName);
            companyName = view.FindViewById<EditText>(Resource.Id.newAccountCompanyName);

            createNewAccount.Invoke(this, new OnAddNewAccount(accountName.Text, companyName.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }


    }
}