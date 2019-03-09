using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.scene
{
    class Determine
    {

        public static bool InHome()
        {
            return Operation.FindPic("F", "表示");
        }

        public static bool InSupply()
        {
            return Operation.FindPic("B", "补给资材数");
        }

        public static bool InAttackChoice()
        {
            return Operation.FindPic("A", "出击选择");
        }

        public static bool InSeaAreaChoice()
        {
            return Operation.FindPic("A", "海域选择");
        }

        public static bool InAttackInfo()
        {
            return Operation.FindPic("B", "出击详细");
        }

        public static bool InTeamChoice()
        {
            return Operation.FindPic("E", "舰队选择");
        }

        public static bool InExpeditionChoice()
        {
            return Operation.FindPic("A", "远征选择");
        }

        public static bool InDock()
        {
            return Operation.FindPic("A", "船坞选择");
        }

        public static bool InShipChoice()
        {
            return Operation.FindPic("E", "舰船选择");
        }

        public static bool InShipStatus()
        {
            return Operation.FindPic("B", "舰船状态");
        }

        public static bool InShipFixConfirm()
        {
            return Operation.FindPic("E", "舰船入渠");
        }
    }
}
