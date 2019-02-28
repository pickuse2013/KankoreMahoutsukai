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
        private static bool IsIn(string bmp)
        {
            if (!Operation.FindPic(bmp))
            {
                return false;
            }
            return true;
        }
        public static bool InHome()
        {
            return IsIn("表示");
        }

        public static bool InSupply()
        {
            return IsIn("补给资材数");
        }

        public static bool InAttackChoice()
        {
            return IsIn("出击选择");
        }

        public static bool InSeaAreaChoice()
        {
            return IsIn("海域选择");
        }

        public static bool InAttackInfo()
        {
            return IsIn("出击详细");
        }

        public static bool InTeamChoice()
        {
            return IsIn("海域选择");
        }
    }
}
