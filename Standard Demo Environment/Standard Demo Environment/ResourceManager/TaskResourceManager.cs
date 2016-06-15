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
    public class TaskResourceManager
    {
        public DataStore<Task> TaskAppData
        {
            get
            {
                return DataStore<Task>.GetInstance(DataStoreType.NETWORK, "todo", KinveyClient.GetInstance());
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllTaskTitles()
        {
            List<string> taskTitles = new List<string>();

            try
            {
                var tasks = await TaskAppData.FindAsync();
                foreach (var task in tasks)
                    taskTitles.Add(task.Action);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }
            return await System.Threading.Tasks.Task.Run(() => taskTitles);
        }

        public async System.Threading.Tasks.Task<Task> CreateNewTask(Task task)
        {
            Task createdTask = null;

            try
            {
                createdTask = await TaskAppData.SaveAsync(task);
            }
            catch (Exception e)
            {
                return null;
            }
            return await System.Threading.Tasks.Task.Run(() => createdTask);
        }

    }
}