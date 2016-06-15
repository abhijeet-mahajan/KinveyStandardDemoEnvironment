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
    public class AuthenticationManager
    {
        public static async System.Threading.Tasks.Task<bool> Login(string username, string password)
        {
            try
            {
                if (KinveyClient.GetInstance().CurrentUser.isUserLoggedIn())
                {
                    Logout();
                }

                var user = await KinveyClient.GetInstance().CurrentUser.LoginAsync(username, password);
                if (user != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //public static async System.Threading.Tasks.Task<bool> Login(string username, string password,Activity activity)
        //{
        //    var result = false;
        //    KinveyClient.GetInstance().User().LoginWithAuthorizationCodeLoginPage("http://localhost:8100", new KinveyMICDelegate<User>
        //    {
        //        onSuccess = (user) =>
        //        {
        //            result = true;
        //        },
        //        onError = (error) =>
        //        {
        //            result = false;
        //        },
        //        OnReadyToRender = (url) =>
        //        {
        //            var uri = Android.Net.Uri.Parse(url);
        //            var intent = new Intent(Intent.ActionView, uri);
        //            activity.StartActivity(intent);
        //        }
        //    });

        //    return await System.Threading.Tasks.Task.Run(() => result);
        //}



        public static bool Logout()
        {
            try
            {
                KinveyClient.GetInstance().CurrentUser.Logout();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool Signup()
        {
            return true;

        }

    }
}