using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.scene
{
    class Wating
    {
        private static readonly int delay = 1000;

        public static void HomePort()
        {
            while (!Determine.InHomePort())
            {
                Outputs.Log("等待进入母港");
                Utils.Delay(delay);
            }
        }

        public static void Supply()
        {
            while (!Determine.InHomePort())
            {
                Outputs.Log("等待进入补给");
                Utils.Delay(delay);
            }
        }

    }
}
