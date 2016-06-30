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
        public DataStore<todo> TaskStore
        {
            get
            {
                var task= DataStore<todo>.GetInstance(DataStoreType.NETWORK, "todo", KinveyClient.GetInstance());
                return task;
            }
        }

        public async System.Threading.Tasks.Task<List<string>> GetAllTaskTitles()
        {
            List<string> taskTitles = new List<string>();

            try
            {
                KinveyObserver<todo> observer = new KinveyObserver<todo>()
                {
                    onSuccess = (tasks) => {
                        foreach (var task in tasks)
                            taskTitles.Add(task.Title);
                    },
                    onError = (e) => Console.WriteLine(e.Message),
                    onCompleted = () => Console.WriteLine("completed")
                };

                await TaskStore.FindAsync(observer);
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
                createdTask = await TaskStore.SaveAsync(task);
            }
            catch (Exception e)
            {
                return null;
            }
            return await System.Threading.Tasks.Task.Run(() => createdTask);
        }

    }
}