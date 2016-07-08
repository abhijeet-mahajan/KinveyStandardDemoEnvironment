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

namespace Standard_Demo_Environment
{
    [JsonObject]
    public class Account
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("accountname")]
        public string Name { get; set; }

        [JsonProperty("accountcompany")]
        public string Company { get; set; }

        //[JsonProperty]
        //public AccountCompany Company { get; set; }

        //[JsonObject("accountcompany")]
        //public class AccountCompany
        //{
        //    [JsonProperty]
        //    public string Name { get; set; }

        //    [JsonProperty]
        //    public string CatchPhrase { get; set; }

        //    [JsonProperty]
        //    public string BS { get; set; }

        //}

        [JsonProperty]
        public string Email { get; set; }

        //[JsonProperty]
        //public AccountAddress Address { get; set; }

        //[JsonObject]
        //public class AccountAddress
        //{
        //    [JsonProperty]
        //    public string Street { get; set; }

        //    [JsonProperty]
        //    public string Suit { get; set; }

        //    [JsonProperty]
        //    public string City { get; set; }

        //    [JsonProperty]
        //    public string ZipCode { get; set; }

        //    [JsonProperty]
        //    public GeoLocation Geo { get; set; }

        //    [JsonObject]
        //    public class GeoLocation
        //    {
        //        [JsonProperty]
        //        public string Latitude { get; set; }

        //        [JsonProperty]
        //        public string Longitude { get; set; }
        //    }
        //}

        [JsonProperty]
        public string Phone { get; set; }

        [JsonProperty]
        public string Website { get; set; }

        [JsonProperty]
        public string Username { get; set; }

        public Account()
        {

        }
        public Account(string accountName,string companyName)
        {
            Name = accountName;
            Company = companyName;
        }
    }
}