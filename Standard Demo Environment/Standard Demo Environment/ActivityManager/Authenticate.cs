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
using KinveyXamarinAndroid;
using KinveyXamarin;

namespace Standard_Demo_Environment
{
    [Activity(Label = "Kinvey", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, "android.intent.category.BROWSABLE" },
        DataScheme = "myredirecturi")]
    public class Authenticate : AppCompatActivity
    {
        private EditText Username;
        private EditText Password;

        private SupportToolBar toolbar;

        private Button LoginWithKinvey;
        private Button LoginWithMIC;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Intent.DataString != null)
            {
                if (Intent.DataString.StartsWith("myredirecturi", StringComparison.OrdinalIgnoreCase))
                {
                    KinveyClient.GetInstance().CurrentUser.OnOAuthCallbackRecieved(this.Intent);
                        AfterSuccessfulLogin();
                }
            }
            SetContentView(Resource.Layout.Authenticate);

            Username = FindViewById<EditText>(Standard_Demo_Environment.Resource.Id.username);
            Password = FindViewById<EditText>(Standard_Demo_Environment.Resource.Id.password);

            toolbar = FindViewById<SupportToolBar>(Standard_Demo_Environment.Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.TextAlignment = TextAlignment.Center;

            LoginWithKinvey = FindViewById<Button>(Resource.Id.Login);
            LoginWithKinvey.Click += KinveyLogin;

            LoginWithMIC = FindViewById<Button>(Resource.Id.MICLogin);
            LoginWithMIC.Click += MICLogin;
        }

        private async void KinveyLogin(object sender, EventArgs e)
        {
            bool isLoginSuccessful = false;

            string username = Username.Text;
            string password = Password.Text;

            AuthenticationManager.Logout();

            //            isLoginSuccessful = await AuthenticationManager.Login("ab","ab");
            isLoginSuccessful = await AuthenticationManager.Login(username, password);
            if (isLoginSuccessful)
                AfterSuccessfulLogin();
            else
                AfterLoginFailed();
        }

        private void MICLogin(object sender, EventArgs e)
        {
            AuthenticationManager.Logout();

            var micDelegate = new KinveyMICDelegate<User>
            {
                onSuccess = (user) => {},
                onError = (exception) => { AfterLoginFailed(); },
                onReadyToRender = (renderURL) =>
                {
                    var uri = Android.Net.Uri.Parse(renderURL);
                    var intent = new Intent(Intent.ActionView, uri);
                    this.StartActivity(intent);
                }
            };

            AuthenticationManager.MICLogin(micDelegate, "myredirecturi://");

        }

        private void AfterSuccessfulLogin()
        {
            Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();

            Intent loginIntent = new Intent(this, typeof(Home));
            this.StartActivity(loginIntent);
        }

        private void AfterLoginFailed()
        {
            Toast.MakeText(this, "Could Not Login", ToastLength.Short).Show();

            Intent loginIntent = new Intent(this, typeof(Authenticate));
            this.StartActivity(loginIntent);
        }

    }
}