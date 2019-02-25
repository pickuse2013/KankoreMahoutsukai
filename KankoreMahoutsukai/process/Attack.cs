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
        public static bool Execution()
        {
            if (Process.attackCount <= 0)
            {
                return true;
            }
            SwitchScene.HomeToAttackChoice();
            SwitchScene.AttackChoiceToSeaAreaChoice();
            ChoiceSeaArea();
            ChoicePoint();
            ChoiceTeam(1);
            CheckTeam();
            Battle();
            Process.attackCount--;
            Form1.form1.attackCount.Text = Process.attackCount.ToString();
            Process.ResetProcess();
            return true;
        }

        private static void ChoiceSeaArea()
        {
            Outputs.Log("选择海域中");
            int seaArea = Process.seaArea;
            string seaAreaBmp = seaArea.ToString() + "图";
            string seaAreaHoverBmp = seaArea.ToString() + "图_hover";
            if (!Operation.FindPic(160, 600, 810, 680, seaAreaHoverBmp, 0.8))
            {
                int x, y;
                if (Operation.FindPic(160, 600, 810, 680, seaAreaBmp, 0.8, out x, out y))
                {
                    Operation.Click(x, 50, y, 50, 250);
                    if (!Operation.FindPic(160, 600, 810, 680, seaAreaHoverBmp, 0.8))
                    {
                        Process.End("选择海域失败");
                    }
                }
                else
                {
                    Process.End("选择海域失败");
                }
            }
            Utils.Delay(250);
        }

        private static void ChoicePoint()
        {
            Outputs.Log("选择关卡中");
            int seaArea = Process.seaArea;
            int point = Process.point;
            int x, y;
            if (point > 0 && point <= 4)
            {
                Operation.Click(200 + (point + 1) % 2 * 500, 200, 228 + Convert.ToInt32(Math.Floor(Convert.ToDouble(point / 3))) * 200, 0, 0);
            }
            else
            {
                if (Operation.FindPic(960, 320, 1100, 470, "前往扩展海域", 0.8, out x, out y))
                {
                    Operation.Click(x, 50, y, 60, 0);
                    Utils.Delay(500);
                    Operation.Click(300, 700, (point - 5) * 140 + 228, 80, 0);
                }
                else
                {
                    Process.End("没有扩展海域");
                }
            }

            Wating.AttackInfo();
            string pointBmp = "图" + seaArea.ToString() + "-" + point.ToString();
            if (!Operation.FindPic(800, 210, 1100, 270, pointBmp, 0.8))
            {
                Process.End("选择关卡错误");
            }
            if (!Operation.FindPic(820, 600, 1120, 680, "出击决定", 0.8, out x , out y))
            {
                Process.End("当前无法出击");
            }
            Operation.Click(x, 250, y, 30, 0);
            Outputs.Log("选择关卡" + seaArea + "-" + point);
            Utils.Delay(500);
        }

        private static void ChoiceTeam(int team)
        {
            Outputs.Log("选择队伍中");
            string teamBmp = "team" + team.ToString();
            string teamHoverBmp = "team" + team.ToString() + "_hover";
            if (!Operation.FindPic(490, 140, 670, 180, teamHoverBmp, 0.8))
            {
                int x, y;
                if (Operation.FindPic(490, 140, 670, 180, teamBmp, 0.8, out x, out y))
                {
                    Operation.Click(x, 20, y, 20, 250);
                    Utils.Delay(250);
                    if (!Operation.FindPic(490, 140, 670, 180, teamHoverBmp, 0.8))
                    {
                        Process.End("选择队伍失败");
                    }
                }
                else
                {
                    Process.End("选择队伍失败");
                }
            }
            Utils.Delay(250);
        }

        private static void CheckTeam()
        {
            int resourcesIndex = Process.resourcesIndex;
            int resources = Process.resources;
            int fatigueIndex = Process.fatigueIndex;
            int fatigue = Process.fatigue;
            int breakageIndex = Process.breakageIndex;
            int breakage = Process.breakage;
            int attackX;
            int attackY;
            Outputs.Log("队伍检查中");
            if (!Operation.FindPic(730, 580, 1030, 680, "出击开始", 0.8, out attackX, out attackY))
            {
                if (!Operation.FindPic(730, 580, 1030, 680, "出击开始_hover", 0.8, out attackX, out attackY))
                {
                    Process.End("无法出击！");
                }
            }

            // 大破检查
            if (Operation.FindPic(500, 188, 750, 618, "大破", 0.7) || Operation.FindPic(500, 188, 750, 618, "黄脸大破", 0.7) || Operation.FindPic(500, 188, 750, 618, "红脸大破", 0.7))
            {
                Process.End("舰娘大破，无法出击");
            }

            int x1, y1, x2, y2;

            // 资源检查
            if (resourcesIndex == 0)
            {
                x1 = 500;
                y1 = 188;
                x2 = 750;
                y2 = 618;
            }
            else
            {
                x1 = 500;
                y1 = 188 + (resourcesIndex - 1) * 72;
                x2 = 750;
                y2 = 618 + (resourcesIndex - 1) * 72;
            }
            if (resources > 0)
            {
                if (resources == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, "油_黄色警告", 0.7))
                    {
                        Process.End("资源未补给！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, "油_红色警告", 0.7))
                {
                    Process.End("资源未补给！");
                }
            }

            // 疲劳检查
            if (fatigueIndex == 0)
            {
                x1 = 500;
                y1 = 188;
                x2 = 750;
                y2 = 618;
            }
            else
            {
                x1 = 500;
                y1 = 188 + (fatigueIndex - 1) * 72;
                x2 = 750;
                y2 = 618 + (fatigueIndex - 1) * 72;
            }
            if (fatigue > 0)
            {
                if (fatigue == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, "黄脸", 0.7))
                    {
                        Process.End("舰娘疲劳！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, "红脸", 0.7))
                {
                    Process.End("舰娘疲劳！");
                }
            }

            // 破损检查
            if (breakageIndex == 0)
            {
                x1 = 500;
                y1 = 188;
                x2 = 750;
                y2 = 618;
            }
            else
            {
                x1 = 500;
                y1 = 188 + (breakageIndex - 1) * 72;
                x2 = 750;
                y2 = 618 + (breakageIndex - 1) * 72;
            }
            if (breakage > 0)
            {
                if (breakage == 1)
                {
                    if (Operation.FindPic(x1, y1, x2, y2, "小破", 0.7))
                    {
                        Process.End("舰娘未修复！");
                    }
                }
                if (Operation.FindPic(x1, y1, x2, y2, "中破", 0.7))
                {
                    Process.End("舰娘未修复！");
                }
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

            Process.supplyTeam1 = true;

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
                if (Operation.FindPic(350, 560, 750, 630, "请选择阵型", 0.8))
                {
                    Outputs.Log("选择阵型中");
                    if (!Operation.FindPic(500, 50, 1150, 540, formation, 0.8, out x, out y))
                    {
                        Outputs.Log("无所选阵型，即将选择单纵阵并撤退");
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

                        
                        if (Operation.FindPic(1000, 540, 1153, 692, "次", 0.8, out x , out y))
                        {
                            Outputs.Log("战斗结束");
                            Operation.Click(x, 40, y, 40, 250);
                            Utils.Delay(500);
                            w2 = false;
                            bool w3 = true;
                            while (w3)
                            {
                                if (Operation.FindPic(1000, 540, 1153, 692, "次", 0.8, out x, out y))
                                {
                                    Outputs.Log("战斗结算");
                                    // 战损检查
                                    if (Operation.FindPic(270, 248, 520, 668, "战斗大破", 0.8))
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
                        else if (Operation.FindPic(250, 220, 850, 450, "逃跑或夜战", 0.8, out x, out y))
                        {
                            w2 = false;
                            if (isNightFighting)
                            {
                                Outputs.Log("进入夜战");
                                Operation.Click(x + 345, 120, y + 35, 70, 250);
                            }
                            else
                            {
                                Outputs.Log("脱离战斗");
                                Operation.Click(x + 40, 80, y + 35, 70, 250);
                            }
                        }
                        Utils.Delay(1000);
                    }
                }

                // 等待罗盘
                if (Operation.FindPic(350, 560, 750, 630, "往哪走", 0.8))
                {
                    Outputs.Log("旋转罗盘");
                    Operation.Click(350, 600, 560, 40, 250);
                    Utils.Delay(5000);// 罗盘旋转需要时间
                }

                // 等待新船归队
                if (Operation.FindPic(1000, 540, 1153, 692, "归", 0.8, out x, out y))
                {
                    Outputs.Log("新船归队");
                    Operation.Click(x, 40, y, 40, 250);
                }

                // 等待进击或撤退
                if (Operation.FindPic(250, 220, 850, 450, "进击或撤退", 0.8, out x, out y))
                {
                    if (isAttack)
                    {
                        Outputs.Log("进击");
                        attackNum++;
                        Operation.Click(x + 25, 140, y + 50, 50, 250);
                    }
                    else
                    {
                        Outputs.Log("撤退");
                        Operation.Click(x + 340, 140, y + 50, 50, 250);
                    }
                }

                // 旗舰大破
                if (Operation.FindPic(800, 50, 1100, 250, "旗舰大破", 0.8))
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
    }
}
