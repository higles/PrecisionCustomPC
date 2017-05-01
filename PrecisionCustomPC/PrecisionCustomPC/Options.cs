using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC
{
    public class Options
    {
        public enum Sizes
        {
            MicroATX,
            ATX_Mid,
            ATX_Full
        };

        public enum RAMClasses
        {
            DDR3,
            DDR4
        }

        public enum RAMSizes
        {
            RAM_2GB,
            RAM_4GB,
            RAM_8GB,
            RAM_16GB,
            RAM_32GB,
            RAM_64GB,
            RAM_128GB
        }
    }
}
