﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallboyBLL.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public string Description { get; set; }
    }
}
