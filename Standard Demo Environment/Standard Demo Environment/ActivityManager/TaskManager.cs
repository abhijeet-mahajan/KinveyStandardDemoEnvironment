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
using SupportToolBar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;

namespace Standard_Demo_Environment
{
    [Activity(Label = "Tasks", Theme = "@style/MyTheme")]
    public class TaskManager : CustomActivity
    {
        private List<string> taskList;
        private ListView tasks;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskManager);

            this.AddToolbar();
            this.AddSlidingDrawer();

            taskList = new List<string>();
            tasks = FindViewById<ListView>(Resource.Id.tasksListView);

            await this.DisplayTasksList();

        }

        private async System.Threading.Tasks.Task DisplayTasksList()
        {
            TaskResourceManager manager = new TaskResourceManager();
            taskList = await manager.GetAllTaskTitles();

            ArrayAdapter<string> accountAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, taskList);
            tasks.Adapter = accountAdapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_item, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override async void OnRefreshClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            await DisplayTasksList();
            Toast.MakeText(this, "Tasks", ToastLength.Short).Show();
            base.OnRefreshClicked(sender, e);
        }

        public override void OnAddItemClicked(object sender, SupportToolBar.MenuItemClickEventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            AddNewTask newTask = new AddNewTask();
            newTask.Show(transaction,"Add New Task");

            base.OnAddItemClicked(sender, e);

            newTask.createNewTask += CreateNewTask;

        }

        private async void CreateNewTask(object sender, OnAddNewTask e)
        {
            Task newTask = new Task(e.Action, e.DueDate, e.Status);

            TaskResourceManager manager = new TaskResourceManager();
            var createdTask = await manager.CreateNewTask(newTask);

            if (createdTask != null)
            {
                Toast.MakeText(this, "New Task Created", ToastLength.Short).Show();
                await DisplayTasksList();
            }
            else
            {
                Toast.MakeText(this, "Something went wrong", ToastLength.Short).Show();
            }
        }

       

    }
}