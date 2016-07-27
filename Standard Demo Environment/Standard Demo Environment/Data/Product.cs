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
using Newtonsoft.Json;
using KinveyXamarin;

namespace Standard_Demo_Environment
{
    [JsonObject]
    public class Product : KinveyObject
    {

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Image { get; set; }

        [JsonProperty]
        public string Thumbing { get; set; }

    }
}