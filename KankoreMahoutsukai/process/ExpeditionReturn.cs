using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.scene;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.process
{
    class ExpeditionReturn
    {
        public static bool Execution()
        {
            Wating.Home();
            int x, y;
            if (!Operation.FindPic("远征归来",out x, out y))
            {
                Outputs.Log("没有远征");
                return true;
            }
            else
            {
                Outputs.Log("远征归来");
                Operation.Click(x, 100, y + 20, 80, 250);
                bool w1 = true;
                while (w1)
                {
                    if (Operation.FindPic("次", out x, out y))
                    {
                        Outputs.Log("远征结算");
                        Operation.Click(x, 40, y, 40, 250);
                        w1 = false;
                        bool w2 = true;
                        while (w2)
                        {
                            if (Operation.FindPic("次", out x, out y))
                            {
                                if (Operation.FindPic("远征归来2队", out x, out y))
                                {
                                    Process.supplyTeam[1] = true;
                                    Process.expeditionTeam2 = true;
                                    Outputs.Log("远征2队归来");
                                    Operation.Click(x, 40, y, 40, 250);
                                }
                                if (Operation.FindPic("远征归来3队", out x, out y))
                                {
                                    Process.supplyTeam[2] = true;
                                    Process.expeditionTeam3 = true;
                                    Outputs.Log("远征3队归来");
                                    Operation.Click(x, 40, y, 40, 250);
                                }
                                if (Operation.FindPic("远征归来4队", out x, out y))
                                {
                                    Process.supplyTeam[3] = true;
                                    Process.expeditionTeam4 = true;
                                    Outputs.Log("远征4队归来");
                                    Operation.Click(x, 40, y, 40, 250);
                                }
                                w2 = false;
                            }
                            Utils.Delay(1000);
                        }
                    }
                    Utils.Delay(1000);
                }
            }
            Process.ResetProcess();
            return true;
        }
    }
}
