using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL;
using TallboyBLL.Controllers;
using TallboyBLL.Models;
using TallboyBLL.Presenter;

namespace HelperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Presenter presenter = new Presenter();
            presenter.Start();

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
    }
}
