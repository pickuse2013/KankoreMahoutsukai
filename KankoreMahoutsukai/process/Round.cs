using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;
using KankoreMahoutsukai.scene;

namespace KankoreMahoutsukai.process
{
    class Round
    {
        public static bool Execution()
        {
            int d = 2;
            Wating.Home();
            while (d > 0)
            {
                Outputs.Log((d * 30).ToString() + "秒后刷新");
                Utils.Delay(30000);
                d--;
            }
            SwitchScene.HomeToSupply();
            SwitchScene.SupplyToHome();
            return true;
        }
    }
}
