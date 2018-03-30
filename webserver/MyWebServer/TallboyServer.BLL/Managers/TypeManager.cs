using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallboyServer.BLL.Database;
using TallboyServer.BLL.Exceptions;

namespace TallboyServer.BLL.Managers
{
    public class TypeManager
    {
        public void GenerateTestData()
        {
            using(var ctx= new TallboyDBContext())
            {
                if (!ctx.Types.Any())
                {
                    ctx.Types.AddRange(new List<TallboyBLL.Models.Type>
                    {
                        new TallboyBLL.Models.Type{Name= "Szimering", Description= "CORTECO 8,8/12,2"},
                        new TallboyBLL.Models.Type{Name= "Akkumulátor", Description= "Bosch"},
                        new TallboyBLL.Models.Type{Name= "Kerékcsapágy", Description= "FEBI Kúpgörgős csapágy"}
                    });
                    ctx.SaveChanges();
                }
            }
        }

        public List<TallboyBLL.Models.Type> GetTypeList()
        {
            //GenerateTestData();
            using (var ctx= new TallboyDBContext())
            {
                var types = ctx.Types.ToList();

                if (types == null) throw new TallboyServerException("Can't find any Type in the database.");

                return types;
            }
        }

        public TallboyBLL.Models.Type GetType(int id)
        {
            GenerateTestData();
            using (var ctx = new TallboyDBContext())
            {
                var types = ctx.Types.FirstOrDefault(t => t.Id == id);

                if (types == null)
                    throw new TallboyServerException("Can't find Type with the ID: " + id.ToString() +" in the database.");

                return types;
            }
        }
    }
}
