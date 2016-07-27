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
        private DataStore<todo> _store;

        private DataStore<todo> GetTaskStore()
        {
            if (_store != null)
                return _store;

            _store = DataStore<todo>.GetInstance(DataStoreType.SYNC, "todo", KinveyClient.GetInstance());
            return _store;
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllTaskTitles()
        {
            List<string> taskTitles = new List<string>();

            try
            {
                var response = await GetTaskStore().SyncAsync();
                var tasks = await GetTaskStore().PullAsync();
                foreach (var task in tasks)
                    taskTitles.Add(task.Action);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong : " + e.StackTrace);
            }
            return await System.Threading.Tasks.Task.Run(() => taskTitles);
        }

        public async System.Threading.Tasks.Task<todo> CreateNewTask(todo task)
        {
            todo createdTask = null;

            try
            {
                createdTask = await GetTaskStore().SaveAsync(task);
                var response = await GetTaskStore().SyncAsync();
            }
            catch
            {
                return null;
            }
            return createdTask;
        }
    }
}