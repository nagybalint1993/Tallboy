using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TallboyBLL.Models;

namespace TallboyBLL.Controllers
{
    public class ContainerPartContentController
    {
        private const string actionName = "ContainerPartContent";

        public ContainerPartContentController()
        {
        }


        //return the ContainerPartContents which have reference to the Type with the given typeId
        public void GetContainerPartContentAsync(Action<List<ContainerPartContent>> action, int typeId)
        {
            var cpContent = new TestData.Data().ContainerPartContentList.Where(cp => cp.TypeId == typeId).ToList();
            action(cpContent);
        }

    }
}
