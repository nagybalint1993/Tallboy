using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallboyBLL.Models;
using TallboyServer.BLL.Managers;

namespace MyWebServer.Controllers
{
    public class TaskElementController : ApiController
    {
        // GET: api/TaskElement
        public IEnumerable<TaskElement> Get()
        {
            return new TaskElementManager().GetTaskElement();
        }

        // GET: api/TaskElement/5
        public IEnumerable<TaskElement> Get(int id)
        {
            return new TaskElementManager().GetTaskElementToTask(id);
        }

        // POST: api/TaskElement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaskElement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaskElement/5
        public void Delete(int id)
        {
        }
    }
}
