using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC
{
    public class Options
    {
        public enum TowerSize
        {
            MicroATX,
            ATX_Mid,
            ATX_Full
        };

        public enum RAMClasse
        {
            DDR3,
            DDR4
        }

        public enum RAMSize
        {
            RAM_2GB,
            RAM_4GB,
            RAM_8GB,
            RAM_16GB,
            RAM_32GB,
            RAM_64GB,
            RAM_128GB
        }

        public enum FormFactor
        {
            HDD,
            SSHD,
            SSD,
            M2,
            NVME
        }

        public enum Modular
        {
            No,
            Semi,
            Full
        }

        public enum FanSize
        {
            _80mm,
            _120mm,
            _140mm,
            _180mm,
        }

        public enum Color
        {
            Red = ColorHash._FF0000,
            Green = ColorHash._00FF00,
            Blue = ColorHash._0000FF,
            Purple = ColorHash._9433FF,
            Pink = ColorHash._FC33FF,
            Orange = ColorHash._FFA833,
            Yellow = ColorHash._F9FF33,
            White = ColorHash._FFFFFF,
            Black = ColorHash._000000,
            Silver = ColorHash._C3C3C3,
            RGB
        }
        public enum ColorHash
        {
            _FF0000, //Red
            _00FF00, //Green
            _0000FF, //Blue
            _9433FF, //Purple
            _FC33FF, //Pink
            _FFA833, //Orange
            _F9FF33, //Yellow
            _FFFFFF, //White
            _000000, //Black
            _C3C3C3, //Silver
        }
    }
}
