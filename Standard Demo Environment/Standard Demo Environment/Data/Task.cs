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
    public class Task
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("duedate")]
        public string DueDate { get; set; }

        [JsonProperty("completed")]
        public bool isCompleted { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        public Task()
        {

        }
        public Task(string action,string dueDate,bool status)
        {
            Action = action;
            DueDate = dueDate;
            isCompleted = status;
            Class = "Personal";
            Title = "Personal";
        }

    }
}