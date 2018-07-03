using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TallboyBLL.Models
{
    public class ContainerPart
    {
        public int Id { get; set; }

        public int ContainerId { get; set; }

        public string Name { get; set; }

        public float XCoordinate { get; set; }

        public float YCoordinate { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }
    }
}
