using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.scene
{
    class Determine
    {
        public static bool InHomePort()
        {
            int x, y;
            if (!Operation.FindPic(450, 628, 700, -1, "表示", 0.8, out x, out y))
            {
                return false;
            }
            return true;
        }

        public static bool InSupply()
        {
            int x, y;
            if (!Operation.FindPic(450, 628, 700, -1, "表示", 0.8, out x, out y))
            {
                return false;
            }
            return true;
        }
    }
}
