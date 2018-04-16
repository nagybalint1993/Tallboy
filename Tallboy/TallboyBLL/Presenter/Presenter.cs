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

        TallboyBLL.Models.Task task { get; set; }
        List<TaskElement> taskelements { get; set; }
        TaskElement currentElement { get; set; }

        public Presenter()
        {
            containerPartContentController = new ContainerPartContentController();
            containerPartController = new ContainerPartController();
            taskElementController = new TaskElementController();
            typeController = new TypeController();
            taskController = new TaskController();
            var s= GetContainerParts("sad");
        }

        public void Start()
        {
            taskController.GetTasksAsync(GetTasksCallback);
        }

        public void GetTasksCallback(List<TallboyBLL.Models.Task> tasks)
        {
            if(tasks != null)
            {
                task = tasks[0];
                Debug.WriteLine("Current taskID :" + task.Id);
                taskElementController.GetTaskElementsAsync(GetTaskElementsCallback ,task.Id);
            }
        }

        public void GetTaskElementsCallback(List<TaskElement> elements)
        {
            if (elements != null)
            {
                taskelements = elements;
                Debug.WriteLine("Taskelements downloaded, there are " + elements.Count + " element");
                elements.Sort(SortByOrder);
            }
        }

        public List<ContainerPart> GetContainerParts(string uuid)
        {
            //containerPartController.GetContainerPartAsync(GetContainerPartsCallback, 1);
            List<ContainerPart> list = new List<ContainerPart> {
                new ContainerPart{ Id=1, XCoordinate= 0, YCoordinate= 0, Height= 12, Width= 100 },
                new ContainerPart{ Id=2, XCoordinate= 0, YCoordinate= 13, Height= 12, Width= 45 },
                new ContainerPart{ Id=3, XCoordinate= 50, YCoordinate= 13, Height= 12, Width= 15 },
                new ContainerPart{ Id=4, XCoordinate= 0, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=5, XCoordinate= 12, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=6, XCoordinate= 24, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=7, XCoordinate= 36, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=8, XCoordinate= 48, YCoordinate= 26, Height= 10, Width= 10 },
                new ContainerPart{ Id=9, XCoordinate= 0, YCoordinate= 40, Height= 30, Width= 100 }
                };

            return list;

        }

        public void GetContainerPartsCallback(List<ContainerPart> list)
        {

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
