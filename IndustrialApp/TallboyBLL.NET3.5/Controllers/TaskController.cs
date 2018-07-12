using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TallboyBLL.Models;
using TallboyBLL.TestData;

namespace TallboyBLL.Controllers
{
    public class TaskController
    {
        private const string actionName = "task";

        public TaskController()
        {
        }

        //return with the tasks
        public void GetTasksAsync(Action<List<Models.Task>> getTasksCallback)
        {
            getTasksCallback(new Data().TaskList);
        }
    }
}
