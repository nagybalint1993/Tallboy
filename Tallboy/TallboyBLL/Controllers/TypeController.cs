using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace TallboyBLL.Controllers
{
    public class TypeController
    {
        private const string actionName = "types";


        public TypeController()
        {
        }

        public void GetTypeAsync(Action<TallboyBLL.Models.Type> callback, int typeId)
        {
            callback(new TestData.Data().TypeList.Where(t => t.Id == typeId).FirstOrDefault());
        }
    }
}
