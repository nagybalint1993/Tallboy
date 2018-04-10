using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyServer.BLL.Database;
using TallboyServer.BLL.Exceptions;

namespace TallboyServer.BLL.Managers
{
    public class ContainerPartContentManager
    {
        public List<TallboyBLL.Models.ContainerPartContent> GetContainerPartContents()
        {
            using (var ctx = new TallboyDBContext())
            {
                var containerPartContent = ctx.ContainerPartContents.ToList();

                if (containerPartContent == null) throw new TallboyServerException("Can't find any ContainerPartContent in the database.");

                return containerPartContent;
            }
        }

        public List<TallboyBLL.Models.ContainerPartContent> GetContainerPartContentToType(int id)
        {
            using (var ctx = new TallboyDBContext())
            {
                var containerPartContent = ctx.ContainerPartContents.Where(t => t.TypeId == id).ToList();

                if (containerPartContent == null)
                    throw new TallboyServerException("Any ContainerPartContent don't have TaskId: " + id.ToString() + " in the database.");

                return containerPartContent;
            }
        }
    }
}
