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
using KinveyXamarinAndroid;
using Android.Support.V4.App;

namespace Standard_Demo_Environment
{
    [Service]
    public class PushNotificationService : KinveyGCMService
    {
        public override void onDelete(int deleted)
        {
            displayNotification(""+deleted);
        }

        public override void onError(string error)
        {
            displayNotification(error);
        }

        public override void onMessage(string message)
        {
            displayNotification(message);
        }

        public override void onRegistered(string gcmID)
        {
            displayNotification(gcmID);
        }

        public override void onUnregistered(string oldID)
        {
            displayNotification(oldID);
        }

        private void displayNotification(String message)
        {
            Console.WriteLine(message);
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
              .SetContentTitle("New Notification From kinvey") // Set the title
              .SetSmallIcon(Resource.Drawable.Icon) // This is the icon to display
              .SetContentText(message); // the message to display.

            NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(100, builder.Build());
        }

    }
}