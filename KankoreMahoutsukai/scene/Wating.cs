using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;
using KankoreMahoutsukai.process;

namespace KankoreMahoutsukai.scene
{
    class Wating
    {

        private static void Wati(Func<bool> func, string scene)
        {
            int i = 0;
            while (!func())
            {
                i++;
                if (i > 10)
                {
                    Process.End("超时，等待进入" + scene + "失败");
                }
                Outputs.Log("等待进入" + scene);
                Utils.Delay(1000);
            }
        }

        public static void Home()
        {
            Wati(Determine.InHome, "母港");
        }

        public static void Supply()
        {
            Wati(Determine.InSupply, "补给");
        }

        public static void AttackChoice()
        {
            Wati(Determine.InAttackChoice, "出击选择");
        }

        public static void SeaAreaChoice()
        {
            Wati(Determine.InSeaAreaChoice, "海域选择");
        }

        public static void AttackInfo()
        {
            Wati(Determine.InAttackInfo, "出击详细");
        }

        public static void TeamChoice()
        {
            Wati(Determine.InTeamChoice, "舰队选择");
        }

    }
}
