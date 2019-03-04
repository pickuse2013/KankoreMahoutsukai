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
        private static int expedition;

        public static bool Execution()
        {
            if (!Process.expeditionTeam[0] && !Process.expeditionTeam[1] && !Process.expeditionTeam[2])
            {
                Outputs.Log("不需要远征");
                return true;
            }

            SwitchScene.HomeToAttackChoice();
            SwitchScene.AttackChoiceToExpeditionChoice();
            for (int i = 0; i < Process.expeditionTeam.Length; i++)
            {
                if (Process.expeditionTeam[i])
                {
                    try
                    {
                        Utils.Delay(500);
                        if (Process.expedition[i] == 0)
                        {
                            Process.expeditionTeam[i] = false;
                        }
                        else
                        {
                            Outputs.Log((i + 2).ToString() + "队准备远征");
                            expedition = Process.expedition[i];
                            ChoiceSeaArea();
                            ChoiceExpedition(i + 2);
                            ChoiceTeam(i + 2);
                            CheckTeam(i + 2);
                        }
                    }
                    catch (ExpeditionException)
                    {
                        continue;
                    }

                }
            }

            SwitchScene.ExpeditionChoiceToHome();
            Process.ResetProcess();
            return true;
        }

        private static void End(string msg)
        {
            Outputs.Log(msg);
            throw new ExpeditionException(msg);
        }

        private static void End(string msg, bool back)
        {
            Outputs.Log(msg);
            if (back)
            {
                Operation.Click(180, 280, 110, 120, 250);
            }
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
                if (Operation.FindPic(seaAreaBmp, out int x, out int y))
                {
                    Operation.Click(x, 50, y, 30, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(seaAreaHoverBmp))
                    {
                        End("选择海域" + seaArea.ToString() + "失败");
                    }
                }
                else
                {
                    End("选择海域" + seaArea.ToString() + "失败");
                }
            }
        }

        private static void ChoiceExpedition(int team)
        {
            string expeditionBmp = "远征" + expedition.ToString();
            string expeditionTaskBmp = "远征" + expedition.ToString() + "概要";
            if (!Operation.FindPic(expeditionBmp, out int x, out int y))
            {
                End("选择远征" + expedition.ToString() + "失败");
            }
            Operation.Click(x, 600, y, 25, 250);
            Utils.Delay(500);
            //if (!Operation.FindPic("B", expeditionTaskBmp, 0.5))
            //{
            //    End("选择远征" + expedition.ToString() + "失败");
            //}
            if (!Operation.FindPic("D", new string[] { "出击决定", "出击决定_hover" }, out x, out y))
            {
                Process.expeditionTeam[team - 2] = false;
                End(expedition.ToString() + "远征当前无法出击");
            }
            Operation.Click(x, 240, y, 40, 0);
        }

        private static void ChoiceTeam(int team)
        {
            Wating.TeamChoice();
            Outputs.Log("选择队伍中");
            string teamBmp = "team" + team.ToString();
            string teamHoverBmp = "team" + team.ToString() + "_hover";
            if (!Operation.FindPic(teamHoverBmp))
            {
                int x, y;
                if (Operation.FindPic(teamBmp, out x, out y))
                {
                    Operation.Click(x, 15, y, 15, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(teamHoverBmp))
                    {
                        End("选择队伍" + team.ToString() + "失败", true);
                    }
                }
                else
                {
                    End("选择队伍" + team.ToString() + "失败", true);
                }
            }
            Utils.Delay(250);
        }

        private static void CheckTeam(int team)
        {
            Outputs.Log("队伍检查中");

            if (Operation.FindPic("禁止远征"))
            {
                Process.expeditionTeam[team - 2] = false;
                End("队伍" + team.ToString() + "无法远征！", true);
            }

            if (!Operation.FindPic(new string[] { "远征开始", "远征开始_hover" }, out int expeditionX, out int expeditionY))
            {
                End("队伍" + team.ToString() + "远征出击失败！", true);
            }

            if (Operation.FindPic(522, 196, 766, 640, new string[] { "油_红色警告", "弹_红色警告", "油_黄色警告", "弹_黄色警告" }, 0.6))
            {
                Process.supplyTeam[team - 1] = true;
                End("队伍" + team.ToString() + "资源未补给！", true);
            }

            Operation.Click(expeditionX, 240, expeditionY, 40, 250);

            Utils.TimeOut(() =>
            {
                if (!Operation.FindPic("D", new string[] { "远征终止", "远征终止_hover" }))
                {
                    return true;
                }
                return false;
            }, 1000);

            Process.expeditionTeam[team - 2] = false;
            Outputs.Log("远征出击成功");
            Utils.Delay(3000);

        }

        private static void SetExpedition(int team, int index)
        {
            int i = team - 1;
            Process.expedition[team - 2] = index;
            if (i == 1)
            {
                Form1.form1.expedition1.SelectedIndex = index;
            }
            if (i == 2)
            {
                Form1.form1.expedition2.SelectedIndex = index;
            }
            if (i == 3)
            {
                Form1.form1.expedition3.SelectedIndex = index;
            }
        }
    }



    class ExpeditionException: ApplicationException
    {
        private string error;

        public ExpeditionException(string msg) : base(msg)
        {
            error = msg;
        }
    }
}
