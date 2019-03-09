using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;
using KankoreMahoutsukai.scene;

namespace KankoreMahoutsukai.process
{
    class Fix
    {
        public static bool Execution()
        {
            int fixing = 0;
            bool fastFix = false;
            bool hasFixed = false;

            if (!Process.isFix)
            {
                Outputs.Log("不需要修理");
                return false;
            }

            SwitchScene.HomeToDock();

            try
            {

                while (Operation.FindPic(new string[] { "空船坞", "空船坞_hover" }, out int x, out int y))
                {
                    Operation.Click(x, 220, y, 50, 250);
                    Wating.ShipChoice();

                    if (Process.fix == 1)
                    {
                        Operation.FindPic("修理大破", 0.6, out x, out y);
                        fixing = 1;// 修理大破
                    }
                    if (Process.fix == 2)
                    {
                        if (Operation.FindPic("修理大破", 0.6, out x, out y))
                        {
                            fixing = 1;// 修理大破
                        }
                        else if (Operation.FindPic("修理中破", 0.6, out x, out y))
                        {
                            fixing = 2;// 修理中破
                        }
                        
                    }
                    if (Process.fix == 3)
                    {
                        if (Operation.FindPic("修理大破", 0.6, out x, out y))
                        {
                            fixing = 1;// 修理大破
                        }
                        else if (Operation.FindPic("修理中破", 0.6, out x, out y))
                        {
                            fixing = 2;// 修理中破
                        }
                        else if (Operation.FindPic("修理小破", 0.6, out x, out y))
                        {
                            fixing = 3;// 修理小破
                        }
                    }

                    if (x < 0 && y < 0)
                    {
                        Process.isFix = false;
                        End("没有需要修理的舰娘", 1);
                    }

                    Operation.Click(x - 400, 450, y, 35, 250);
                    Wating.ShipStatus();

                    if (fixing == 1 && Process.bigFastFix || fixing == 2 && Process.middleFastFix || fixing == 3 && Process.smallFastFix)
                    {
                        fastFix = true;
                    }

                    if (fastFix)
                    {
                        if (!Operation.FindPic("高速修复", out x, out y))
                        {
                            End("高速修复失败", 2);
                        }
                        Operation.Click(x, 100, y, 25, 0);
                        Utils.Delay(500);
                        if (!Operation.FindPic("高速修复_hover"))
                        {
                            End("高速修复失败", 2);
                        }
                    }

                    if (!Operation.FindPic("D", "入渠开始", out x, out y))
                    {
                        End("入渠失败", 2);
                    }
                    Operation.Click(x, 200, y, 60, 250);

                    Wating.ShipFixConfirm();

                    Operation.FindPic("F", "入渠确定", out x, out y);
                    Operation.Click(x, 140, y, 30, 250);

                    Wating.Dock();

                    hasFixed = true;
                    Process.watiFix = false;

                    if (fastFix)
                    {
                        Utils.Delay(5000);// 等待快速修复的动画
                    }

                    Utils.Delay(1000);
                }

                if (!hasFixed)
                {
                    Process.watiFix = true;
                    End("暂无船位");
                }
                Process.isFix = false;
            }
            catch (FixException)
            {

            }

            SwitchScene.DockToHome();
            return true;
        }

        private static void End(string msg)
        {
            Outputs.Log(msg);
            throw new FixException(msg);
        }

        private static void End(string msg, int back)
        {
            while (back > 0)
            {
                Operation.Click(180, 280, 110, 120, 250);
                back--;
                Utils.Delay(500);
            }
            End(msg);
        }
    }

    class FixException : Exception
    {
        private string error;

        public FixException(string msg) : base(msg)
        {
            error = msg;
        }
    }
}
