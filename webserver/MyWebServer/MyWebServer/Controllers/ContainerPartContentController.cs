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
    public class ContainerPartContentController : ApiController
    {
        // GET: api/ContainerPartContent
        public IEnumerable<ContainerPartContent> Get()
        {
            return new ContainerPartContentManager().GetContainerPartContents();
        }

        // GET: api/ContainerPartContent/5
        public IEnumerable<ContainerPartContent> Get(int id)
        {
            return new ContainerPartContentManager().GetContainerPartContentToType(id);
        }

        public IEnumerable<ContainerPartContent> ToType(int id)
        {
            return new ContainerPartContentManager().GetContainerPartContentToType(id);
        }

        /*

        // POST: api/ContainerPartContent
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ContainerPartContent/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ContainerPartContent/5
        public void Delete(int id)
        {
        }

        */
    }
}
