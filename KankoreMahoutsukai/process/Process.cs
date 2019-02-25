using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KankoreMahoutsukai.utils;

namespace KankoreMahoutsukai.process
{
    class Process
    {
        private static int step = 0;
        private static bool key = false;

        // 关卡
        public static int seaArea = 1;
        public static int point = 1;

        // 舰队检查
        public static int resourcesIndex = 0;
        public static int resources = 0;
        public static int fatigueIndex = 0;
        public static int fatigue = 0;
        public static int breakageIndex = 0;
        public static int breakage = 0;

        // 战斗配置
        public static string formation = "单纵阵";
        public static bool isNightFighting = false;
        public static int aimAttackNum = 999;

        // 出击次数
        public static int attackCount = 0;

        // 是否需要补给
        public static bool supplyTeam1 = false;
        public static bool supplyTeam2 = false;
        public static bool supplyTeam3 = false;
        public static bool supplyTeam4 = false;

        // 是否需要远征
        public static bool expeditionTeam2 = false;
        public static bool expeditionTeam3 = false;
        public static bool expeditionTeam4 = false;

        public static bool Start ()
        {
            if (!Operation.BindWindow())
            {
                return false;
            }
            if (!Config())
            {
                return false;
            }

            try
            {
                step = 0;
                key = true;
                while (true)
                {
                    processControl();
                    step = step + 1;
                }
            } catch (Exception e)
            {

            }
            Outputs.Log("脚本已停止");
            return true;
        }

        public static void End()
        {
            if (key)
            {
                key = false;
                throw new Exception("停止运行脚本");
            }
        }

        public static void End(string s)
        {
            Outputs.Log(s);
            if (key)
            {
                key = false;
                throw new Exception("停止运行脚本");
            }
        }

        private static bool processControl()
        {
            Utils.Delay(1000);
            switch (step)
            {
                case 0 :
                    return ExpeditionReturn.Execution();
                case 1:
                    return Supply.Execution();
                case 2:
                    return Attack.Execution();
            }
            ResetProcess();
            return true;
        }

        // 流程归0
        public static void ResetProcess() => step = -1;

        private static bool Config()
        {
            string config = "==========" + System.Environment.NewLine;

            // 关卡
            string[] sArray = Regex.Split(Form1.form1.point.Text, "-", RegexOptions.IgnoreCase);
            seaArea = Convert.ToInt32(sArray[0]);
            point = Convert.ToInt32(sArray[1]);
            config += "关卡 " + Form1.form1.point.Text + System.Environment.NewLine;


            // 舰队检查
            resourcesIndex = Form1.form1.resourcesIndex.SelectedIndex;
            resources = Form1.form1.resources.SelectedIndex;
            fatigueIndex = Form1.form1.fatigueIndex.SelectedIndex;
            fatigue = Form1.form1.fatigue.SelectedIndex;
            breakageIndex = Form1.form1.breakageIndex.SelectedIndex;
            breakage = Form1.form1.breakage.SelectedIndex;
            config += Form1.form1.resourcesIndex.Text + " " + Form1.form1.resources.Text + System.Environment.NewLine;
            config += Form1.form1.fatigueIndex.Text + " " + Form1.form1.fatigue.Text + System.Environment.NewLine;
            config += Form1.form1.breakageIndex.Text + " " + Form1.form1.breakage.Text + System.Environment.NewLine;

            // 战斗配置
            formation = Form1.form1.formation.Text;
            isNightFighting = Form1.form1.isNightFighting.Text == "是" ? true : false;
            if (Form1.form1.aimAttackNum.Text == "")
            {
                Outputs.Msg("请输入战斗次数");
                return false;
            }
            int a = Convert.ToInt32(Form1.form1.aimAttackNum.Text);
            if (a < 1)
            {
                Outputs.Msg("战斗次数必须大于等于1");
                return false;
            }
            aimAttackNum = a;
            config += "阵型 " + Form1.form1.formation.Text + System.Environment.NewLine;
            config += "夜战 " + Form1.form1.isNightFighting.Text + System.Environment.NewLine;
            config += "战斗次数 " + Form1.form1.aimAttackNum.Text + System.Environment.NewLine;

            // 出击次数
            if (Form1.form1.attackCount.Text == "")
            {
                Outputs.Msg("请输入出击次数");
                return false;
            }
            attackCount = Convert.ToInt32(Form1.form1.attackCount.Text);
            config += "出击次数 " + Form1.form1.attackCount.Text + System.Environment.NewLine;

            config += "==========" + System.Environment.NewLine;
            Outputs.Log(config);
            return true;
        }
    }
}
