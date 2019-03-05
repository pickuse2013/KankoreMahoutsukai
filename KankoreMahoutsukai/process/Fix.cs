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
            if (!Process.isFix)
            {
                Outputs.Log("不需要修理");
                return true;
            }

            SwitchScene.HomeToDock();
            if (!Operation.FindPic(new string[] { "空船坞", "空船坞_hover" }, out int x, out int y))
            {
                Outputs.Log("暂无船位");
                Process.watiFix = true;
            }

            Operation.Click(x, 220, y, 50, 250);
            Wating.ShipChoice();
            return true;
        }

        private static void End()
        {

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
