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
        DataScheme = "http://localhost:8100")]
    public class Authenticate : ActionBarActivity
    {
        private EditText Username;
        private EditText Password;

        private SupportToolBar toolbar;

        private Button Login;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Authenticate);

            Username = FindViewById<EditText>(Standard_Demo_Environment.Resource.Id.username);
            Password = FindViewById<EditText>(Standard_Demo_Environment.Resource.Id.password);

            toolbar = FindViewById<SupportToolBar>(Standard_Demo_Environment.Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.TextAlignment = TextAlignment.Center;

            Login = FindViewById<Button>(Resource.Id.Login);

            Login.Click += BeginLogin;
        }

        private async void BeginLogin(object sender, EventArgs e)
        {
            bool isLoginSuccessful = false;

            string username = Username.Text;
            string password = Password.Text;

            AuthenticationManager.Logout();

             isLoginSuccessful = await AuthenticationManager.Login(username, password);

            if (isLoginSuccessful)
                AfterSuccessfulLogin();
            else
                Toast.MakeText(this, "Could Not Login", ToastLength.Short).Show();


            //isLoginSuccessful = await AuthenticationManager.Login("ab", "ab");

            //try
            //{
            //    this.MICLogin();
            //    AfterSuccessfulLogin();
            //}
            //catch
            //{
            //    Toast.MakeText(this, "Could Not Login", ToastLength.Short).Show();

            //}


        }

        private void AfterSuccessfulLogin()
        {
            Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();

            Intent loginIntent = new Intent(this, typeof(Home));
            this.StartActivity(loginIntent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            KinveyClient.GetInstance().CurrentUser.OnOAuthCallbackRecieved(intent);
        }

        //public async void MICLogin()
        //{
        //    var url = await KinveyClient.GetInstance().User().LoginWithAuthorizationCodeLoginPage("http://localhost:8100");
        //    var uri = Android.Net.Uri.Parse(url);
        //    var intent = new Intent(Intent.ActionView, uri);
        //    StartActivity(intent);



        //    //{
        //    //    onSuccess = (user) =>
        //    //    {
        //    //        //                    Console.WriteLine("Successful!!");
        //    //    },
        //    //    onError = (error) =>
        //    //    {
        //    //        //                  Console.WriteLine("Something Went wrong");
        //    //    },
        //    //    OnReadyToRender = (url) =>
        //    //    {
        //    //        var uri = Android.Net.Uri.Parse(url);
        //    //        var intent = new Intent(Intent.ActionView, uri);
        //    //        StartActivity(intent);
        //    //    }
        //    //});
        //}
    }
}