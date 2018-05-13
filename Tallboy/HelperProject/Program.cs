using System;
using System.Collections.Generic;
using System.Diagnostics;
using TallboyBLL.Presenter;

namespace HelperProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Presenter presenter = new Presenter();
            presenter.Start();

            Debug.Write("Task: " + presenter.currentTaskElement.Name);
            Debug.Write("Description: " + presenter.currentTaskElement.Description);

            presenter.TypeFound("20ede1ea-44bc-4cc9-9000-94bdc66cc5b0");
            Debug.Write("Task: " + presenter.currentTaskElement.Name);
            Debug.Write("Description: " + presenter.currentTaskElement.Description);

            presenter.TypeFound("464d6419-d6ed-4229-9509-890cd5807f9b");
            Debug.Write("Task: " + presenter.currentTaskElement.Name);
            Debug.Write("Description: " + presenter.currentTaskElement.Description);

            presenter.TypeFound("057d09e2-2bc7-4098-8ba0-ad428f3ddf41");
            Debug.Write("Task: " + presenter.currentTaskElement.Name);
            Debug.Write("Description: " + presenter.currentTaskElement.Description);

            Debug.Write("Container: " + presenter.isType("20ede1ea - 44bc - 4cc9 - 9000 - 94bdc66cc5b0"));
            Debug.Write("Type1: " + presenter.isType("057d09e2-2bc7-4098-8ba0-ad428f3ddf41"));
            Debug.Write("Type2: " + presenter.isType("464d6419-d6ed-4229-9509-890cd5807f9b"));


            /*
            TypeController typeController = new TypeController();
            TallboyBLL.Models.Type type= typeController.GetTypeAsync(1).Result;
            Debug.WriteLine(type.Name);

            ContainerPartContentController containerPartContentController = new ContainerPartContentController();
            List<ContainerPartContent> cpcList= containerPartContentController.GetContainerPartContentAsync(3).Result;
            foreach(ContainerPartContent cpc in cpcList)
            {
                Debug.WriteLine(cpc.Id);
                Debug.WriteLine(cpc.TypeId);
                Debug.WriteLine(cpc.Amount);
            }

            TaskElementController taskElementController = new TaskElementController();
            List<TaskElement> teList = taskElementController.GetTaskElementsAsync(1).Result;
            foreach (TaskElement te in teList)
            {
                Debug.WriteLine(te.Id);
                Debug.WriteLine(te.Name);
                Debug.WriteLine(te.Description);
            }

            ContainerPartController containerPartController = new ContainerPartController();
            ContainerPart cp = containerPartController.GetContainerPartAsync(2).Result;
            Debug.WriteLine(cp.Name);
            Debug.WriteLine("x: " + cp.XCoordinate + " y: " + cp.YCoordinate);

    */

            //Interactor interactor = new Interactor();
            //Task task= interactor.GetTasksAsync();
            //task.Wait();

            //Debug.WriteLine(interactor.description);
            //Debug.WriteLine(interactor.currentType.Name);
            //Debug.WriteLine(interactor.currentType.Description);
        }

            public static void GetTask(List<TallboyBLL.Models.Task> list)
        {
            foreach(TallboyBLL.Models.Task t in list)
            {
                Debug.Write(list[0].Name + "\n" + list[0].Description);
            }
        }
    }
}
