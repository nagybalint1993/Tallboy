using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL;
using TallboyBLL.Controllers;

namespace HelperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeController typeController = new TypeController();
            TallboyBLL.Models.Type type= typeController.GetTypeAsync(1).Result;
            Debug.WriteLine(type.Name);
            type = typeController.GetTypeAsync(2).Result;
            Debug.WriteLine(type.Name);
            type = typeController.GetTypeAsync(3).Result;
            Debug.WriteLine(type.Name);
            type = typeController.GetTypeAsync(4).Result;
            Debug.WriteLine(type.Name);


            //Interactor interactor = new Interactor();
            //Task task= interactor.GetTasksAsync();
            //task.Wait();

            //Debug.WriteLine(interactor.description);
            //Debug.WriteLine(interactor.currentType.Name);
            //Debug.WriteLine(interactor.currentType.Description);
        }
    }
}
