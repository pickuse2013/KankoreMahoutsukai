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
            Wating.HomePort();
            int x, y;
            if (Operation.FindPic(680, 0, 800, 90, "远征归来", 0.8, out x, out y))
            {
                Outputs.Log("远征归来");
                Operation.Click(x, 100, y + 20, 80, 250);
                bool w1 = true;
                while (w1)
                {
                    if (Operation.FindPic(1002, 542, 1153, 692, "次", 0.5, out x, out y))
                    {
                        Outputs.Log("远征结算");
                        Operation.Click(x, 40, y, 40, 250);
                        w1 = false;
                        bool w2 = true;
                        while (w2)
                        {
                            if (Operation.FindPic(1002, 542, 1153, 692, "次", 0.5, out x, out y))
                            {
                                if (Operation.FindPic(140, 150, 250, 190, "远征归来2队", 0.8, out x, out y))
                                {
                                    Process.supplyTeam2 = true;
                                    Process.expeditionTeam2 = true;
                                    Outputs.Log("远征2队归来");
                                }
                                if (Operation.FindPic(140, 150, 250, 190, "远征归来3队", 0.8, out x, out y))
                                {
                                    Process.supplyTeam3 = true;
                                    Process.expeditionTeam3 = true;
                                    Outputs.Log("远征3队归来");
                                }
                                if (Operation.FindPic(140, 150, 250, 190, "远征归来4队", 0.8, out x, out y))
                                {
                                    Process.supplyTeam4 = true;
                                    Process.expeditionTeam4 = true;
                                    Outputs.Log("远征4队归来");
                                }
                                Operation.Click(x, 40, y, 40, 250);
                                w2 = false;
                            }
                            Utils.Delay(1000);
                        }
                    }
                    Utils.Delay(1000);
                }
                Process.ResetProcess();
            }
            else
            {
                Outputs.Log("没有远征");
            }
            return true;
        }
    }
}
