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

        public enum RAMClass
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
            Red = 0xFF0000,
            Green = 0x00FF00,
            Blue = 0x0000FF,
            Purple = 0x9433FF,
            Pink = 0xFC33FF,
            Orange = 0xFFA833,
            Yellow = 0xF9FF33,
            White = 0xFFFFFF,
            Black = 0x000000,
            Silver = 0xC3C3C3,
            RGB
        }
    }
}