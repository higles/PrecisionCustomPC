using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class TowerColor
    {
        public int ID { get; set; }

        public string Color { get; set; }

        public string ColorHash { get; set; }

        public List<TowerImage> Images { get; set; }
    }
}
