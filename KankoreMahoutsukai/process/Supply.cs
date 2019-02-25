using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.scene;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.process
{
    class Supply
    {
        public static bool Execution()
        {
            if (Process.supplyTeam1 == false && Process.supplyTeam2 == false && Process.supplyTeam3 == false && Process.supplyTeam4 == false)
            {
                Outputs.Log("不需要补给");
                return true;
            }
            SwitchScene.HomeToSupply();
            if (Process.supplyTeam1)
            {
                SupplyTeam(1);
                Process.supplyTeam1 = false;
            }
            if (Process.supplyTeam2)
            {
                SupplyTeam(2);
                Process.supplyTeam2 = false;
            }
            if (Process.supplyTeam3)
            {
                SupplyTeam(3);
                Process.supplyTeam3 = false;
            }
            if (Process.supplyTeam4)
            {
                SupplyTeam(4);
                Process.supplyTeam4 = false;
            }
            Outputs.Log("全部补给完毕");
            SwitchScene.SupplyToHome();
            Process.ResetProcess();
            return true;
        }

        private static void SupplyTeam(int team)
        {
            string teamBmp = "supply_team" + team.ToString();
            string teamHoverBmp = "supply_team" + team.ToString() + "_hover";
            if (!Operation.FindPic(185, 150, 365, 190, teamHoverBmp, 0.8))
            {
                int x, y;
                if (Operation.FindPic(185, 150, 365, 190, teamBmp, 0.8, out x, out y))
                {
                    Operation.Click(x, 20, y, 20, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(185, 150, 365, 190, teamHoverBmp, 0.8))
                    {
                        Process.End("选择队伍失败");
                    }
                }
                else
                {
                    Process.End("选择队伍失败");
                }
            }

            bool w = true;
            while (w)
            {
                Outputs.Log("等待补给完成");
                if(Operation.FindPic(1010, 570, 1110, 620, "舰队全补给", 0.8))
                {
                    w = false;
                }
                else
                {
                    Operation.Click(160, 20, 166, 18, 250);
                }
                Utils.Delay(1000);
            }
            Outputs.Log("补给team" + team + "完成");
        }
    }
}
