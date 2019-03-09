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
        private static void Switch(string bmp, out int x, out int y, string scene)
        {
            int i = 0;
            while (!Operation.FindPic(bmp, out x, out y))
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

        private static void Switch(string[] bmps, out int x, out int y, string scene)
        {
            int i = 0;
            while (!Operation.FindPic(bmps, out x, out y))
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
            Switch("补给", out x, out y, "补给");
            Operation.Click(x, 90, y, 70, 0);
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
            Switch("出击", out x, out y, "出击选择");
            Operation.Click(x, 130, y, 110, 250);
            Wating.AttackChoice();
        }

        public static void AttackChoiceToSeaAreaChoice()
        {
            Wating.AttackChoice();
            Switch(new string[] { "出击选择出击", "出击选择出击_hover" }, out int x, out int y, "出击");
            Operation.Click(x, 200, y, 200, 0);
            Wating.SeaAreaChoice();
        }

        public static void AttackChoiceToExpeditionChoice()
        {
            Wating.AttackChoice();
            Switch(new string[] { "出击选择远征", "出击选择远征_hover" }, out int x, out int y, "远征");
            Operation.Click(x, 200, y, 200, 0);
            Wating.ExpeditionChoice();
        }

        public static void ExpeditionChoiceToHome()
        {
            Wating.ExpeditionChoice();
            Operation.Click(20, 100, 10, 110, 0);
            Wating.Home();
        }

        public static void HomeToDock()
        {
            Wating.Home();
            Switch("入渠", out int x, out int y, "船坞");
            Operation.Click(x, 90, y, 70, 0);
            Wating.Dock();
        }

        public static void DockToHome()
        {
            Wating.Dock();
            Operation.Click(20, 100, 10, 110, 0);
            Wating.Home();
        }
    }
}
