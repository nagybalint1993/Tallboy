using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallboyBLL.Models
{
    public class ContainerPart
    {
        public int Id { get; set; }

        public int ContainerId { get; set; }

        public string Name { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
