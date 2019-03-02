using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;
using KankoreMahoutsukai.scene;

namespace KankoreMahoutsukai.process
{
    class Expedition
    {
        private static int team;
        private static int expedition;

        public static bool Execution()
        {
            if (!Process.expeditionTeam[0] && !Process.expeditionTeam[1] && !Process.expeditionTeam[2])
            {
                Outputs.Log("不需要远征");
                return true;
            }
            try
            {
                SwitchScene.HomeToAttackChoice();
                SwitchScene.AttackChoiceToExpeditionChoice();
                for (int i = 0; i < Process.expeditionTeam.Length; i++)
                {
                    if (Process.expeditionTeam[i])
                    {
                        if (Process.expedition[i] == 0)
                        {
                            Process.expeditionTeam[i] = false;
                        }
                        else
                        {
                            Outputs.Log((i + 2).ToString() + "队准备远征");
                            team = i;
                            expedition = Process.expedition[i];
                            ChoiceSeaArea();
                            ChoiceExpedition();
                        }
                    }
                }

            }
            catch (ExpeditionException)
            {
                Operation.Click(20, 100, 10, 110, 0);
            }
            return true;
        }

        private static void End(string msg)
        {
            Outputs.Log(msg);
            Process.ResetProcess();
            throw new ExpeditionException(msg);
        }

        private static void ChoiceSeaArea()
        {
            int seaArea = 0;
            if (expedition >= 1 && expedition <= 8)
            {
                seaArea = 1;
            }
            if (expedition >= 9 && expedition <= 16)
            {
                seaArea = 2;
            }
            if (expedition >= 17 && expedition <= 24)
            {
                seaArea = 3;
            }
            if (expedition >= 33 && expedition <= 40)
            {
                seaArea = 6;
            }

            if (seaArea == 0)
            {
                End("无远征海域");
            }

            string seaAreaBmp = "远征" + seaArea.ToString() + "图";
            string seaAreaHoverBmp = "远征" + seaArea.ToString() + "图_hover";

            if (!Operation.FindPic(seaAreaHoverBmp))
            {
                int x, y;
                if (Operation.FindPic(seaAreaBmp, out x, out y))
                {
                    Operation.Click(x, 50, y, 30, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(seaAreaHoverBmp))
                    {
                        End("选择海域失败");
                    }
                }
                else
                {
                    End("选择海域失败");
                }
            }
        }

        private static void ChoiceExpedition()
        {
            string expeditionBmp = "远征" + expedition.ToString();
            string expeditionTaskBmp = "远征" + expedition.ToString() + "概要";
            if (!Operation.FindPic(expeditionBmp, out int x, out int y))
            {
                End("选择远征失败");
            }
            Operation.Click(x, 600, y, 25, 250);
            Utils.Delay(250);
            if (!Operation.FindPic("B", expeditionTaskBmp))
            {
                End("选择远征失败" + expedition.ToString());
            }
            if (!Operation.FindPic("D", new string[] { "出击决定", "出击决定_hover" }, out x, out y))
            {
                End(expedition.ToString() + "远征当前无法出击");
            }
            Operation.Click(x, 240, y, 40, 0);
        }
    }

    class ExpeditionException: ApplicationException
    {
        private string error;

        public ExpeditionException(string msg) : base(msg)
        {
            error = msg;
        }
        public string GetError()
        {
            return error;
        }
    }
}
