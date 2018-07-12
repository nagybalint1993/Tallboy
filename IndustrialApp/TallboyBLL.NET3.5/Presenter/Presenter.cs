using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public TallboyBLL.Models.Task currentTask { get; set; }
        public Models.Type currentType { get; set; }
        public bool containerPartChanged { get; set; }
        public ContainerPart currentContainerPart { get; set; }
        public TaskElement currentTaskElement { get; set; }
        List<TaskElement> taskelements { get; set; }
        private int currentElement { get; set; }

        public bool TypeIsReady { get; set; }


        //TEST
        Data testdata;

        private static Presenter instance;

        private Presenter()
        {
            containerPartContentController = new ContainerPartContentController();
            containerPartController = new ContainerPartController();
            taskElementController = new TaskElementController();
            typeController = new TypeController();
            taskController = new TaskController();
            var s= GetContainerParts("sad");
            testdata = new Data();
            containerPartChanged = false;
        }

        public static Presenter GetPresenter()
        {          
            if (instance == null)
            {
                instance = new Presenter();
            }
            return instance;       
        }

        public void Start()
        {
            taskController.GetTasksAsync(GetTasksCallback);
        }

        public void GetTasksCallback(List<TallboyBLL.Models.Task> tasks)
        {
            if(tasks != null)
            {
                currentTask = tasks[0];
                Debug.WriteLine("Current taskID :" + currentTask.Id);
                taskElementController.GetTaskElementsToTaskAsync(GetTaskElementsCallback ,currentTask.Id);
            }
        }

        public void GetTaskElementsCallback(List<TaskElement> elements)
        {
            if (elements != null)
            {
                taskelements = elements;
                Debug.WriteLine("Taskelements downloaded, there are " + elements.Count + " element");
                taskelements.Sort(SortByOrder);
                currentElement = 0;
                DoTaskElement();
            }
        }

        public List<ContainerPart> GetContainerParts(string uuid)
        {
            //containerPartController.GetContainerPartAsync(GetContainerPartsCallback, 1);
            List<ContainerPart> cplist = new List<ContainerPart> {
                new ContainerPart{ Id=1, XCoordinate= 0.0f, YCoordinate= 0.0f, Height= 0.055f , Width= 0.27f },
                new ContainerPart{ Id=2, XCoordinate= 0.0f, YCoordinate= 0.066f, Height= 0.055f, Width= 0.13f },
                new ContainerPart{ Id=3, XCoordinate= 0.140f, YCoordinate= 0.066f, Height= 0.055f, Width= 0.13f },
                new ContainerPart{ Id=4, XCoordinate= 0.0f, YCoordinate= 0.130f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=5, XCoordinate= 0.055f, YCoordinate= 0.130f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=6, XCoordinate= 0.11f, YCoordinate= 0.130f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=7, XCoordinate= 0.165f, YCoordinate= 0.130f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=8, XCoordinate= 0.22f, YCoordinate= 0.130f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=9, XCoordinate= 0.0f, YCoordinate= 0.175f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=10, XCoordinate= 0.055f, YCoordinate= 0.175f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=11, XCoordinate= 0.11f, YCoordinate= 0.175f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=12, XCoordinate= 0.165f, YCoordinate= 0.175f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=13, XCoordinate= 0.22f, YCoordinate= 0.175f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=14, XCoordinate= 0.0f, YCoordinate= 0.220f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=15, XCoordinate= 0.055f, YCoordinate= 0.220f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=16, XCoordinate= 0.11f, YCoordinate= 0.220f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=17, XCoordinate= 0.165f, YCoordinate= 0.220f, Height= 0.035f, Width= 0.045f },
                new ContainerPart{ Id=18, XCoordinate= 0.220f, YCoordinate= 0.220f, Height= 0.035f, Width= 0.045f },
                };
            return cplist;
        }

        public void GetContainerPartsCallback(List<ContainerPart> list)
        {

        }

        public void DoTaskElement()
        {
            TypeIsReady = false;
            var element = taskelements[currentElement];
            if (element != null)
            {
                currentTaskElement = taskelements[currentElement];
                //Debug.WriteLine("Current taskelement:");
                //Debug.WriteLine("ID: " + element.Id + "\n Name:" + element.Name + "\n Description: " + element.Description);
                typeController.GetTypeAsync(GetTypeAsyncCallback, element.TypeId);
            }

        }

        public void TaskElementDone()
        {
            currentElement++;
            DoTaskElement();
        }

        private void GetTypeAsyncCallback(Models.Type type)
        {
            //Debug.WriteLine("Required type: " + type.Name + "\n" + type.Description);
            //Debug.WriteLine("+++++++++++++");
            currentType = type;

            // !!!!!!!!!!!!!!!!!!! TO DO !!!!!!!!!!!!!!!!!!!!!!
            // This method get all the containerpartcontents to a type, but we need only the those which belong to our containers
            if(type != null)
            {
                containerPartContentController.GetContainerPartContentAsync(GetContainerPartContentCallback, type.Id);
            }
            else
            {
                //containerPartChanged = true;
            }
        }

        private void GetContainerPartContentCallback(List<ContainerPartContent> cpcList)
        {
            if (cpcList != null)
            {
                var cpc = cpcList.FirstOrDefault();
                containerPartController.GetContainerPartAsync(GetContainerPartAsyncCallback , cpc.ContainerPartId);
            }
            else
            {
                throw new Exception("There isn't containerpart which contains the given type.");
            }
        }

        private void GetContainerPartAsyncCallback(ContainerPart cp)
        {
            currentContainerPart = cp;
            containerPartChanged = true;
        }

        public int SortByOrder(TaskElement a, TaskElement b)
        {
            return a.Order.CompareTo(b.Order);
        }

        public bool isType(string uuid)
        {
            if( testdata.TypeList.Exists(t => t.UUID == uuid))
            {
                return true;
            }
            return false;
        }

        public void GetContainerParts(Action<List<ContainerPart>, string> action, string uuid)
        {
            containerPartController.GetContainerPartAsync(action,uuid);
        }

        public void TypeFound(string uuid)
        {
            if(currentType.UUID == uuid)
            {
                TypeIsReady = true;
                //TaskElementDone();
            }
        }
    }


    
}
