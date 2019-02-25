using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.process;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.scene
{
    class SwitchScene
    {
        // 查找切换场景需要的按钮
        private static void Switch(int x1, int y1, int x2, int y2, string bmp, double sim, out int x, out int y, string scene)
        {
            int i = 0;
            while (!Operation.FindPic(x1, y1, x2, y2, bmp, sim, out x, out y))
            {
                i++;
                if (i > 10)
                {
                    Process.End("超时，进入" + scene + "失败");
                }
                Outputs.Log("正在进入" + scene);
                Utils.Delay(1000);
            }
        }


        public static void HomeToSupply()
        {
            Wating.Home();
            int x, y;
            Switch(50, 240, 170, 380, "补给", 0.8, out x, out y, "补给");
            Operation.Click(x + 20, 60, y + 10, 50, 0);
            Wating.Supply();
        }

        public static void SupplyToHome()
        {
            Wating.Supply();
            Operation.Click(20, 100, 10, 110, 0);
            Wating.Home();
        }

        public static void HomeToAttackChoice()
        {
            Wating.Home();
            int x, y;
            Switch(170, 280, 380, 490, "出击", 0.8, out x, out y, "出击选择");
            Operation.Click(x + 20, 80, y + 10, 50, 250);
            Wating.AttackChoice();
        }

        public static void AttackChoiceToSeaAreaChoice()
        {
            Wating.AttackChoice();
            int x, y;
            Switch(200, 530, 440, 640, "出击说明", 0.8, out x, out y, "出击");
            Operation.Click(x, 150, y - 280, 180, 0);
            Wating.SeaAreaChoice();
        }
    }
}
