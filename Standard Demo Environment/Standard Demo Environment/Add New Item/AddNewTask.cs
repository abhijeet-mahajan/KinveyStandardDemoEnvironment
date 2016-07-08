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

namespace Standard_Demo_Environment
{
    public class OnAddNewTask : EventArgs
    {
        public string Action { get; set; }
        public string DueDate { get; set; }
        public bool Status { get; set; }

        public OnAddNewTask(string action, string dueDate,bool status)
        {
            Action = action;
            DueDate = dueDate;
            Status = status;
        }
    }

    public class AddNewTask : DialogFragment
    {
        private Button saveTask;
        private EditText taskName;
        private EditText dueDate;
        private CheckBox taskStatus;

        public event EventHandler<OnAddNewTask> createNewTask;

        View view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.AddNewTask, container, false);

            saveTask = view.FindViewById<Button>(Resource.Id.saveNewTask);

            saveTask.Click += SaveNewTask;

            return view;
        }

        private void SaveNewTask(object sender, EventArgs e)
        {
            taskName = view.FindViewById<EditText>(Resource.Id.newTaskName);
            dueDate = view.FindViewById<EditText>(Resource.Id.newTaskDueDate);
            taskStatus = view.FindViewById<CheckBox>(Resource.Id.newTaskStatus);

            createNewTask.Invoke(this, new OnAddNewTask(taskName.Text, dueDate.Text, taskStatus.Checked));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }


    }
}