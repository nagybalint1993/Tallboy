using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyBLL.Models;

namespace TallboyServer.BLL.Database
{
    class TallboyDBContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }

        public DbSet<ContainerPart> ContainerParts { get; set; }

        public DbSet<ContainerPartContent> ContainerPartContents { get; set; }

        public DbSet<TallboyBLL.Models.Task> Tasks { get; set; }

        public DbSet<TaskElement> TaskElements { get; set; }

        public DbSet<TallboyBLL.Models.Type> Types { get; set; }

    }
}
