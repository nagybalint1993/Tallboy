using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL.Controllers;
using TallboyBLL.Models;
using TallboyBLL.TestData;

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
        public bool taskReady { get; set; }
        public bool taskelementReady { get; set; }
        List<TaskElement> taskelements { get; set; }
        int currentElement { get; set; }


        //TEST
        Data testdata;

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
            testdata = new Data();
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
                currentElement = 0;
            }
        }

        public List<ContainerPart> GetContainerParts(string uuid)
        {
            //containerPartController.GetContainerPartAsync(GetContainerPartsCallback, 1);
            List<ContainerPart> cplist = new List<ContainerPart> {
                new ContainerPart{ Id=1, XCoordinate= 0, YCoordinate= 0, Height= 55, Width= 270 },
                new ContainerPart{ Id=2, XCoordinate= 0, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=3, XCoordinate= 140, YCoordinate= 66, Height= 55, Width= 130 },
                new ContainerPart{ Id=4, XCoordinate= 0, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=5, XCoordinate= 55, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=6, XCoordinate= 110, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=7, XCoordinate= 165, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=8, XCoordinate= 220, YCoordinate= 130, Height= 35, Width= 45 },
                new ContainerPart{ Id=9, XCoordinate= 0, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=10, XCoordinate= 55, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=11, XCoordinate= 110, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=12, XCoordinate= 165, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=13, XCoordinate= 220, YCoordinate= 185, Height= 35, Width= 45 },
                new ContainerPart{ Id=14, XCoordinate= 0, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=15, XCoordinate= 55, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=16, XCoordinate= 110, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=17, XCoordinate= 165, YCoordinate= 240, Height= 35, Width= 45 },
                new ContainerPart{ Id=18, XCoordinate= 220, YCoordinate= 240, Height= 35, Width= 45 },
                };
            return cplist;
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
