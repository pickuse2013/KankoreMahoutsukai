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
            bool All = true;
            if (!Process.supplyTeam[0] && !Process.supplyTeam[1] && !Process.supplyTeam[2] && !Process.supplyTeam[3])
            {
                Outputs.Log("不需要补给");
                return true;
            }

            SwitchScene.HomeToSupply();
            for (int i = 0; i < Process.supplyTeam.Length; i++)
            {
                if (Process.supplyTeam[i])
                {
                    try
                    {
                        SupplyTeam(i + 1);
                    }
                    catch (SupplyException)
                    {
                        All = false;
                        continue;
                    }
                }
            }
            if (All)
            {
                Outputs.Log("全部补给完毕");
            }
            else
            {
                Outputs.Log("补给未全部完成，即将重新补给");
            }
            
            SwitchScene.SupplyToHome();
            Process.ResetProcess();

            return true;
        }

        private static void End(string msg)
        {
            Outputs.Log(msg);
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
                        End("选择队伍" + team.ToString() + "失败");
                    }
                }
                else
                {
                    End("选择队伍" + team.ToString() + "失败");
                }
            }

            Utils.TimeOut(() =>
            {
                Outputs.Log("等待补给完成");
                if (Operation.FindPic("舰队全补给"))
                {
                    return false;
                }
                else
                {
                    if (!Operation.FindPic("全部补给", out x, out y))
                    {
                        End("补给队伍" + team.ToString() + "失败");
                    }
                    Operation.Click(x, 25, y, 25, 250);
                    return true;
                }
            }, 1000);

            Process.supplyTeam[team - 1] = false;
            Outputs.Log("补给队伍" + team.ToString() + "完成");
        }
    }

    class SupplyException : ApplicationException
    {
        private string error;

        public SupplyException(string msg) : base(msg)
        {
            error = msg;
        }
    }
}
