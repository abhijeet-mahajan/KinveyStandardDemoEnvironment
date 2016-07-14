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
using Android.Net;

namespace Standard_Demo_Environment
{
    public class ConnectionManager : Activity
    {
        private ConnectivityManager _connectivityManager;
        protected ConnectivityManager ConnectivityManager
        {
            get
            {
                _connectivityManager = _connectivityManager ??
                                       (ConnectivityManager)GetSystemService(ConnectivityService);
                return _connectivityManager;
            }
        }
        public bool IsConnected
        {
            get
            {
                try
                {
                    var activeConnection = ConnectivityManager.ActiveNetworkInfo;
                    return ((activeConnection != null) && activeConnection.IsConnected);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}