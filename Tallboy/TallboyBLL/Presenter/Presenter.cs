using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL.Controllers;
using TallboyBLL.Models;

namespace TallboyBLL.Presenter
{
    public class Presenter
    {
        ContainerPartController containerPartController;
        ContainerPartContentController containerPartContentController;
        TaskElementController taskElementController;
        TypeController typeController;
        TaskController taskController;

        TallboyBLL.Models.Task task;
        List<TaskElement> taskelements;
        TaskElement currentElement;
        
        public Presenter()
        {
            containerPartContentController = new ContainerPartContentController();
            containerPartController = new ContainerPartController();
            taskElementController = new TaskElementController();
            typeController = new TypeController();
            taskController = new TaskController();
        }

        public void Start()
        {
            List<TallboyBLL.Models.Task> tasks = taskController.GetTasksAsync().Result;
            if(tasks != null)
            {
                task = tasks[0];
                Debug.WriteLine("Current taskID :" + task.Id);
                taskelements = taskElementController.GetTaskElementsAsync(task.Id).Result;
                if(taskelements != null)
                {
                    Debug.WriteLine("Taskelements downloaded, there are " + taskelements.Count + " element");
                    taskelements.Sort(SortByOrder);

                    foreach(TaskElement te in taskelements)
                    {
                        DoTaskElement(te);
                    }
                }
                else
                {
                    Debug.WriteLine("There isn't any taskelement to task with ID: " + task.Id);
                }
                

                

                
            }
        }

        public void DoTaskElement(TaskElement element)
        {
            Debug.WriteLine("Current taskelement:");
            Debug.WriteLine("ID: " + element.Id + "\n Name:" + element.Name + "\n Description: " + element.Description);
            if(element.TypeId != null)
            {
                Models.Type type = typeController.GetTypeAsync(element.TypeId).Result;
                Debug.WriteLine("Required type: " + type.Name + "\n" + type.Description);
                Debug.WriteLine("+++++++++++++");
                List<ContainerPartContent> cpcList = containerPartContentController.GetContainerPartContentAsync(type.Id).Result;
                if(cpcList != null)
                {
                    var cpc = cpcList.FirstOrDefault();
                    ContainerPart containerPart = containerPartController.GetContainerPartAsync(cpc.ContainerPartId).Result;
                    Debug.WriteLine("There is/are " + cpc.Amount + " in the " + containerPart.Name + " containerpart.");
                }
                else
                {
                    throw new Exception("There isn't containerpart which contains the given type.");
                }
            }

            
        }

        public int SortByOrder(TaskElement a, TaskElement b)
        {
            return a.Order.CompareTo(b.Order);
        }
    }
}
