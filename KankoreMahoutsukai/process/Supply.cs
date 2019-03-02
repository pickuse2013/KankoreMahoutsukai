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
            if (Process.supplyTeam[0] == false && Process.supplyTeam[1] == false && Process.supplyTeam[2] == false && Process.supplyTeam[3] == false)
            {
                Outputs.Log("不需要补给");
                return true;
            }
            SwitchScene.HomeToSupply();


            try
            {
                for (int i = 0; i < Process.supplyTeam.Length; i++)
                {
                    if (Process.supplyTeam[i])
                    {
                        SupplyTeam(i + 1);
                    }
                }
                Outputs.Log("全部补给完毕");
                SwitchScene.SupplyToHome();
                Process.ResetProcess();
            }
            catch (SupplyException)
            {
                Operation.Click(20, 100, 10, 110, 0);
            }
            return true;
        }

        private static void End(string msg)
        {
            Outputs.Log("msg");
            Process.ResetProcess();
            throw new SupplyException(msg);
        }

        private static void SupplyTeam(int team)
        {
            int x, y;
            string teamBmp = "supply_team" + team.ToString();
            string teamHoverBmp = "supply_team" + team.ToString() + "_hover";
            if (!Operation.FindPic(teamHoverBmp))
            {
                if (Operation.FindPic(teamBmp, out x, out y))
                {
                    Operation.Click(x, 15, y, 15, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(teamHoverBmp))
                    {
                        End("选择队伍失败");
                    }
                }
                else
                {
                    End("选择队伍失败");
                }
            }

            bool w = true;
            while (w)
            {
                Outputs.Log("等待补给完成");
                if(Operation.FindPic("舰队全补给"))
                {
                    w = false;
                }
                else
                {
                    if (!Operation.FindPic("全部补给", out x, out y))
                    {
                        End("补给失败");
                    }
                    Operation.Click(x, 25, y, 25, 250);
                }
                Utils.Delay(1000);
            }
            Process.supplyTeam[team - 1] = false;
            Outputs.Log("补给team" + team + "完成");
        }
    }

    class SupplyException : ApplicationException
    {
        private string error;

        public SupplyException(string msg) : base(msg)
        {
            error = msg;
        }
        public string GetError()
        {
            return error;
        }
    }
}
