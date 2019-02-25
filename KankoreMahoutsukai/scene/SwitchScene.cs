using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.scene
{
    class SwitchScene
    {
        public static bool HomePortToSupply()
        {
            Wating.HomePort();
            int x, y;
            if (!Operation.FindPic(50, 240, 170, 380, "补给", 0.8, out x, out y))
            {
                Outputs.Log("进入补给失败");
                return false;
            }
            Operation.Click(x + 20, 60, y + 10, 50, 0);

            return true;
        }
    }
}
