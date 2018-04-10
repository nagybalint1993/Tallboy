using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallboyBLL.Models;
using TallboyServer.BLL.Managers;

namespace TallboyServer.Controllers
{
    public class TaskController : ApiController
    {
        // GET api/Task+
        public IEnumerable<Task> Get()
        {
            return new TaskManager().GetTask();
        }

        // GET api/Task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Task
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Task/5
        public void Delete(int id)
        {
        }
    }
}