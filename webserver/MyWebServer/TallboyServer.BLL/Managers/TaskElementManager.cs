using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyServer.BLL.Database;
using TallboyServer.BLL.Exceptions;

namespace TallboyServer.BLL.Managers
{
    public class TaskElementManager
    {
        public List<TallboyBLL.Models.TaskElement> GetTaskElementToTask(int id)
        {
            using (var ctx = new TallboyDBContext())
            {
                var taskElements = ctx.TaskElements.Where(t => t.TaskId == id).ToList();

                if (taskElements == null) throw new TallboyServerException("Can't find any Taskelement in the database to the task");

                return taskElements;
            }
        }

        public TallboyBLL.Models.TaskElement GetTaskElement(int id)
        {
            using (var ctx = new TallboyDBContext())
            {
                var taskElement = ctx.TaskElements.FirstOrDefault(t => t.Id == id);

                if (taskElement == null)
                    throw new TallboyServerException("Can't find TaskElement with the ID: " + id.ToString() + " in the database.");

                return taskElement;
            }
        }

        public List<TallboyBLL.Models.TaskElement> GetTaskElement()
        {
            using (var ctx = new TallboyDBContext())
            {
                var taskElement = ctx.TaskElements.ToList();

                if (taskElement == null)
                    throw new TallboyServerException("Can't find any TaskElement in the database.");

                return taskElement;
            }
        }
    }
}
