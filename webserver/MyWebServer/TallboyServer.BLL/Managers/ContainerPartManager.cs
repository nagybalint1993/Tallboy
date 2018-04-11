using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyServer.BLL.Database;
using TallboyServer.BLL.Exceptions;

namespace TallboyServer.BLL.Managers
{
    public class ContainerPartManager
    {
        public TallboyBLL.Models.ContainerPart GetContainerPart(int id)
        {
            using (var ctx = new TallboyDBContext())
            {
                var containerPart = ctx.ContainerParts.FirstOrDefault(t => t.Id == id);

                if (containerPart == null)
                    throw new TallboyServerException("Can't find ContainerPart with the ID: " + id.ToString() + " in the database.");

                return containerPart;
            }
        }

        public List<TallboyBLL.Models.ContainerPart> GetContainerParts()
        {
            using (var ctx = new TallboyDBContext())
            {
                var containerPart = ctx.ContainerParts.ToList();

                if (containerPart == null)
                    throw new TallboyServerException("Can't finda any ContainerPart in the database.");

                return containerPart;
            }
        }
    }
}
