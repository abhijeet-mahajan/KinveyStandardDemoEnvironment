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
using System.Collections.Specialized;
using SQLite.Net.Platform.XamarinAndroid;
using KinveyXamarinAndroid;

namespace Standard_Demo_Environment
{
    public class KinveyClient
    {
        private static readonly string appkey = "kid_Z1ZBnjSuM-";
        private static readonly string appSecret = "af76310fc41444c3876669ad3a155eb0";

        private static Client kinveyClient;

        public static Client GetInstance()
        {
            if (kinveyClient == null)
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                kinveyClient = new Client.Builder(appkey, appSecret)
                                .setFilePath(path)
                                .setOfflinePlatform(new SQLitePlatformAndroid())
                                .SetProjectId("906362008503")
                                .build();

                kinveyClient.MICApiVersion = "v2";
                kinveyClient.Push().Initialize(Android.App.Application.Context);
            }
            return kinveyClient;

        }
    }
}
//                                .setLogger(delegate (string msg) { Console.WriteLine($"KINVEY{msg}"); })






//private static readonly string appkey = ConfigurationManager.AppSettings["AppKey"];
//private static readonly string appSecret = ConfigurationManager.AppSettings["AppSecret"];


//if (kinveyClient == null)
//{
//    var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//    kinveyClient = new Client.Builder(appkey, appSecret)
//                    .setLogger(delegate (string msg) { Console.WriteLine($"KINVEY{msg}"); })
//                    .setFilePath(path)
//                    .setOfflinePlatform(new SQLitePlatformAndroid())
//                    .build();

//    kinveyClient.MICApiVersion = "v2";

//}
//return kinveyClient;

