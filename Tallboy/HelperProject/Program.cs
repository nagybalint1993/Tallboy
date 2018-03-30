using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL;

namespace HelperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Interactor interactor = new Interactor();
            Task task= interactor.GetTasksAsync();
            task.Wait();

            Debug.WriteLine(interactor.description);
            Debug.WriteLine(interactor.currentMaterial.Name);
            Debug.WriteLine(interactor.currentMaterial.Description);
        }
    }
}
