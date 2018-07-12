using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TallboyBLL.Models;

namespace TallboyBLL.Controllers
{
    public class TaskElementController
    {
        private const string actionName = "taskelement";

        public TaskElementController()
        {
        }

        //return the ContainerPartContents which have reference to the Type with the given typeId
        public void GetTaskElementsToTypeAsync(Action<List<TaskElement>> getTaskElementsCallback, int typeId)
        {
            getTaskElementsCallback(new TestData.Data().TaskElementList.Where(te => te.TypeId == typeId).ToList());
        }

        internal void GetTaskElementsToTaskAsync(Action<List<TaskElement>> getTaskElementsCallback, int id)
        {
            getTaskElementsCallback(new TestData.Data().TaskElementList.Where(te => te.TaskId == id).ToList());
        }
    }
}
