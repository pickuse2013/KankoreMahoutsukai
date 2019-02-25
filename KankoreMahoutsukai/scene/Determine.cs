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
        private static bool IsIn(int x1, int y1, int x2, int y2, string bmp, double sim)
        {
            if (!Operation.FindPic(x1, y1, x2, y2, bmp, sim))
            {
                return false;
            }
            return true;
        }
        public static bool InHome()
        {
            return IsIn(450, 628, 700, 692, "表示", 0.8);
        }

        public static bool InSupply()
        {
            return IsIn(870, 140, 1153, 200, "补给资材数", 0.8);
        }

        public static bool InAttackChoice()
        {
            return IsIn(170, 90, 280, 140, "出击选择", 0.8);
        }

        public static bool InSeaAreaChoice()
        {
            return IsIn(170, 90, 280, 140, "海域选择", 0.8);
        }

        public static bool InAttackInfo()
        {
            return IsIn(820, 90, 920, 140, "出击详细", 0.8);
        }

        public static bool InTeamChoice()
        {
            return IsIn(485, 90, 585, 140, "海域选择", 0.8);
        }
    }
}
