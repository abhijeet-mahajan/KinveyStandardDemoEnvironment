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

        public static void MICLogin(KinveyMICDelegate<User> micDelegate, string url)
        {
            KinveyClient.GetInstance().CurrentUser.LoginWithAuthorizationCodeLoginPage(url, micDelegate);
        }

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

        //sign up
        public bool Signup()
        {
            return true;

        }

    }
}