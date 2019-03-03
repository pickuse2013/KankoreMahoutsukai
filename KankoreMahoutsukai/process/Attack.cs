using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.scene;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.process
{
    class Attack
    {
        private static int team = 1;
        public static bool Execution()
        {
            if (Process.attackCount <= 0)
            {
                return true;
            }
            try
            {
                SwitchScene.HomeToAttackChoice();
                SwitchScene.AttackChoiceToSeaAreaChoice();
                ChoiceSeaArea();
                ChoicePoint();
                ChoiceTeam();
                CheckTeam();
                Battle();
                Process.attackCount--;
                Form1.form1.attackCount.Text = Process.attackCount.ToString();
                Process.ResetProcess();
            }
            catch (AttackException)
            {
                Operation.Click(20, 100, 10, 110, 0);
            }

            return true;
        }

        private static void End(string  msg)
        {
            Outputs.Log(msg);
            throw new AttackException(msg);
        }

        private static void End(string msg, bool ResetProcess)
        {
            Process.ResetProcess();
            End(msg);
        }

        private static void ChoiceSeaArea()
        {
            Outputs.Log("选择海域中");
            int seaArea = Process.seaArea;
            string seaAreaBmp = seaArea.ToString() + "图";
            string seaAreaHoverBmp = seaArea.ToString() + "图_hover";
            if (!Operation.FindPic(seaAreaHoverBmp))
            {
                int x, y;
                if (Operation.FindPic(seaAreaBmp, out x, out y))
                {
                    Operation.Click(x, 50, y, 40, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic( seaAreaHoverBmp))
                    {
                        End("选择海域失败", true);
                    }
                }
                else
                {
                    End("选择海域失败", true);
                }
            }

        }

        private static void ChoicePoint()
        {
            Outputs.Log("选择关卡中");
            int seaArea = Process.seaArea;
            int point = Process.point;
            int x, y;
            if (point > 0 && point <= 4)
            {
                Operation.Click(200 + (point + 1) % 2 * 500, 250, 220 + Convert.ToInt32(Math.Floor(Convert.ToDouble(point / 3))) * 220, 0, 0);
            }
            else
            {
                if (Operation.FindPic("前往扩展海域", out x, out y))
                {
                    Operation.Click(x, 70, y, 80, 0);
                    Utils.Delay(500);
                    Operation.Click(200, 900, (point - 5) * 144 + 220, 100, 0);
                }
                else
                {
                    End("没有扩展海域", true);
                }
            }

            Wating.AttackInfo();
            string pointBmp = "图" + seaArea.ToString() + "-" + point.ToString() + "作战名";
            if (!Operation.FindPic("B", pointBmp))
            {
                End("选择关卡失败" + pointBmp, true);
            }
            if (!Operation.FindPic("D", new string[] { "出击决定", "出击决定_hover" }, out x, out y))
            {
                End("当前无法出击");
            }
            Operation.Click(x, 240, y, 40, 0);
            Outputs.Log("选择关卡" + seaArea + "-" + point);
            Utils.Delay(500);
        }

        private static void ChoiceTeam()
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

        private static void CheckTeam()
        {
            int resourceIndex = Process.resourceIndex;
            int resource = Process.resource;
            int fatigueIndex = Process.fatigueIndex;
            int fatigue = Process.fatigue;
            int breakageIndex = Process.breakageIndex;
            int breakage = Process.breakage;
            int attackX;
            int attackY;
            bool isResource = false;
            bool isFatigue = false;
            bool isBreakage = false;
            Outputs.Log("队伍检查中");

            if (Operation.FindPic("禁止出击"))
            {
                End("无法出击！");
            }

            if (!Operation.FindPic(new string[] { "出击开始", "出击开始_hover" }, out attackX, out attackY))
            {
                End("出击失败！");
            }

            // 大破检查
            if (Operation.FindPic("大破") || Operation.FindPic("大破") || Operation.FindPic("大破"))
            {
                isBreakage = true;
                Outputs.Log("舰娘大破，无法出击");
            }

            int x1, y1, x2, y2;

            // 资源检查
            GetPosition(resourceIndex, out x1, out y1, out x2, out y2);
            if (resource > 0)
            {
                if (resource == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, new string[] { "油_黄色警告", "弹_黄色警告" }, 0.6))
                    {
                        isResource = true;
                        Outputs.Log("资源未补给！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, new string[] { "油_红色警告", "弹_红色警告" }, 0.6))
                {
                    isResource = true;
                    Outputs.Log("资源未补给！");
                }
            }


            // 破损检查
            GetPosition(breakageIndex, out x1, out y1, out x2, out y2);
            if (breakage > 0)
            {
                if (breakage == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, "小破", 0.6))
                    {
                        isBreakage = true;
                        Outputs.Log("舰娘未修复！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, "中破", 0.6))
                {
                    isBreakage = true;
                    Outputs.Log("舰娘未修复！");
                }
            }

            // 疲劳检查
            GetPosition(fatigueIndex, out x1, out y1, out x2, out y2);
            if (fatigue > 0)
            {
                if (fatigue == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, "黄脸", 0.6))
                    {
                        isFatigue = true;
                        Outputs.Log("舰娘疲劳！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, "红脸", 0.6))
                {
                    isFatigue = true;
                    Outputs.Log("舰娘疲劳！");
                }
            }

            if (isResource || isBreakage || isFatigue)
            {
                if (isResource)
                {
                    Process.supplyTeam[team - 1] = true;
                }
                if (isFatigue)
                {
                    End("出击失败，即将返回母港");
                }
                End("出击失败，即将返回母港", true);
            }


            Operation.Click(attackX, 180, attackY, 30, 250);
        }

        private static void Battle()
        {
            string formation = Process.formation;
            bool isNightFighting = Process.isNightFighting;
            int aimAttackNum = Process.aimAttackNum;
            bool isAttack = true;
            int attackNum = 1;
            int x, y;

            Process.supplyTeam[team - 1] = true;

            bool w1 = true;
            while (w1)
            {
                Outputs.Log("航行中");
                if (attackNum > aimAttackNum)
                {
                    Outputs.Log("已达到战斗次数，即将撤退");
                    isAttack = false;
                }

                // 等待选择阵型
                if (Operation.FindPic("F", "请选择阵型"))
                {
                    Outputs.Log("选择阵型中");
                    if (!Operation.FindPic(formation, out x, out y))
                    {
                        Outputs.Log("无所选阵型，即将选择单纵阵并撤退停止战斗");
                        formation = "单纵阵";
                        isNightFighting = false;
                        isAttack = false;
                        Process.attackCount = 0;
                        continue;
                    }
                    Operation.Click(x, 130, y, 30, 250);
                    Outputs.Log("选择" + formation);

                    // 等待战斗结束 || 进入夜战
                    bool w2 = true;
                    while (w2)
                    {
                        Outputs.Log("战斗中");

                        
                        if (Operation.FindPic("D", "次", out x , out y))
                        {
                            Outputs.Log("战斗结束");
                            Operation.Click(x, 40, y, 40, 250);
                            Utils.Delay(500);
                            w2 = false;
                            bool w3 = true;
                            while (w3)
                            {
                                if (Operation.FindPic("D", "次", out x, out y))
                                {
                                    Outputs.Log("战斗结算");
                                    // 战损检查
                                    if (Operation.FindPic("战斗大破", 0.8))
                                    {
                                        Outputs.Log("舰娘大破，即将撤退！");
                                        isAttack = false;
                                    }
                                    else
                                    {
                                        Outputs.Log("无大破战损");
                                    }
                                    Operation.Click(x, 40, y, 40, 250);
                                    w3 = false;
                                }
                                Utils.Delay(1000);
                            }

                        }
                        else if (Operation.FindPic("逃跑或夜战", 0.8, out x, out y))
                        {
                            if (isNightFighting)
                            {
                                Outputs.Log("进入夜战");
                                Operation.Click(x + 320, 140, y, 60, 250);
                            }
                            else
                            {
                                Outputs.Log("脱离战斗");
                                Operation.Click(x, 140, y, 60, 250);
                            }
                        }
                        Utils.Delay(1000);
                    }
                }

                // 等待罗盘
                if (Operation.FindPic("C", "往哪走"))
                {
                    Outputs.Log("旋转罗盘");
                    Operation.Click(350, 700, 600, 60, 250);
                    Utils.Delay(5000);// 罗盘旋转需要时间
                }

                // 等待新船归队
                if (Operation.FindPic("D", "归", out x, out y))
                {
                    Outputs.Log("新船归队");
                    Operation.Click(x, 40, y, 40, 250);
                }

                // 等待进击或撤退
                if (Operation.FindPic("进击或撤退", out x, out y))
                {
                    if (isAttack)
                    {
                        Outputs.Log("进击");
                        attackNum++;
                        Operation.Click(x, 140, y, 50, 250);
                    }
                    else
                    {
                        Outputs.Log("撤退");
                        Operation.Click(x + 330, 140, y, 50, 250);
                    }
                }

                // 旗舰大破
                if (Operation.FindPic("B", "旗舰大破"))
                {
                    Outputs.Log("旗舰大破，强制回港");
                    Operation.Click(850, 200, 370, 200, 250);
                }

                // 回港
                if (Determine.InHome())
                {
                    Outputs.Log("返回母港，战斗结束");
                    w1 = false;
                }
                Utils.Delay(1000);
            }
        }

        private static void GetPosition(int index, out int x1, out int y1, out int x2, out int y2)
        {
            x1 = 532;
            y1 = 197;
            x2 = 776;
            y2 = 266;
            int space = 75;
            if (index == 0)
            {
                y1 = 197;
                y2 = 266 + space * 5;
            }
            else
            {
                y1 = 197 + (index - 1) * space;
                y2 = 266 + (index - 1) * space;
            }
        }
    }

    class AttackException : ApplicationException
    {
        private string error;

        public AttackException(string msg) : base(msg)
        {
            error = msg;
        }
    }
}
