using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyServer.BLL.Database;
using TallboyServer.BLL.Exceptions;

namespace TallboyServer.BLL.Managers
{
    public class TaskManager
    {
        public TallboyBLL.Models.Task GetTask(int id)
        {
            using (var ctx = new TallboyDBContext())
            {
                var task = ctx.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                    throw new TallboyServerException("Can't find Task with the ID: " + id.ToString() + " in the database.");

                return task;
            }
        }

        public List<TallboyBLL.Models.Task> GetTask()
        {
            using (var ctx = new TallboyDBContext())
            {
                var task = ctx.Tasks.ToList();

                if (task == null)
                    throw new TallboyServerException("Can't find Task in the database.");

                return task;
            }
        }
    }
}
