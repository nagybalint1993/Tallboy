using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TallboyBLL.Models;
using TallboyBLL.TestData;
using System.Linq;

namespace TallboyBLL.Controllers
{
    public class ContainerPartController
    {
        private const string actionName = "ContainerPart";

        public ContainerPartController()
        {
            
        }

        //return the ContainerPart with the given Id
        public void GetContainerPartAsync(Action<ContainerPart> action, int id)
        {
            var containerpart = new TestData.Data().ContainerPartList.Where(cp=> cp.Id == id).FirstOrDefault();
            action(containerpart);
        }


        // !!!! TODO now this method get all containerpart
        internal void GetContainerPartAsync(Action<List<ContainerPart>, string> getContainerPartsCallback, string uuid)
        {
            getContainerPartsCallback(new Data().ContainerPartList, uuid);
        }
    }
}
