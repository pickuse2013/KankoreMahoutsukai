﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dm;

namespace KankoreMahoutsukai.utils
{
    class Operation
    {
        private static readonly int gameX1 = 0;
        private static readonly int gameY1 = 172;
        //private static readonly int gameX2 = 1152;
        //private static readonly int gameY2 = 864;
        private static readonly int gameW = 1153;
        private static readonly int gameH = 692;
        private static int debug = 0;
        private static bool isDebug = false;
        public static bool End = false; // 手动结束脚本

        private static dmsoft dm = null;

        private static dmsoft GetDm()
        {
            if (End)
            {
                KankoreMahoutsukai.process.Process.End();
                End = false;
            }

            if (dm == null)
            {
                dm = new dmsoft();
            }
            return dm;
        }

        public static bool AutoRegCom()
        {
            string strCmd = "regsvr32 " + "\\image\\dm.dll /s";
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + strCmd;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = strCmd + "\r\n" + rInfo;
                // return rInfo;
                return true;
            }
            catch (Exception ex)
            {
                Outputs.Msg("大漠插件调用出问题！" + ex.Message);
                //return ex.Message;
                return false;
            }
        }

        public static bool BindWindow()
        {
            dmsoft dm = GetDm();
            int hwnd = 0;
            hwnd = dm.FindWindow("", "poi");
            if (hwnd == 0)
            {
                Outputs.Log("未找到poi浏览器！");
                return false;
            }
            Outputs.Log("poi窗口句柄为：" + hwnd.ToString());
            int res = dm.BindWindow(hwnd, "normal", "windows", "windows", 0);
            if (res != 1)
            {
                Outputs.Log("窗口绑定失败");
                return false;
            }
            Outputs.Log("窗口绑定成功");
            return true;
        }

        public static bool FindPic(int x1, int y1, int x2, int y2, string bmp, double sim, out int x, out int y)
        {
            dmsoft dm = GetDm();
            DebugBmp(x1, y1, x2, y2, bmp);
            bmp = System.AppDomain.CurrentDomain.BaseDirectory + "bmp\\" + bmp + ".bmp";
            if (!System.IO.File.Exists(bmp))
            {
                Outputs.Msg(bmp + "资源图片缺失，请检查bmp文件夹");
                x = -1;
                y = -1;
                return false;
            }
            x2 = x2 == -1 ? gameW : x2;
            y2 = y2 == -1 ? gameH : y2;
            x1 = x1 + gameX1;
            y1 = y1 + gameY1;
            x2 = x2 + gameX1;
            y2 = y2 + gameY1;
            object dx;
            object dy;
            int res = dm.FindPic(x1, y1, x2, y2, bmp, "000000", sim, 0, out dx, out dy);
            x = Convert.ToInt32(dx);
            y = Convert.ToInt32(dy);
            x -= gameX1;
            y -= gameY1;
            if (res != 0)
            {
                return false;
            }
            if (x < 0 && y < 0)
            {
                return false;
            }
            return true;
        }

        public static bool FindPic(int x1, int y1, int x2, int y2, string bmp, double sim)
        {
            dmsoft dm = GetDm();
            int x, y;
            DebugBmp(x1, y1, x2, y2, bmp);
            bmp = System.AppDomain.CurrentDomain.BaseDirectory + "bmp\\" + bmp + ".bmp";
            if (!System.IO.File.Exists(bmp))
            {
                Outputs.Msg("资源图片缺失，请检查bmp文件夹");
                x = -1;
                y = -1;
                return false;
            }
            x2 = x2 == -1 ? gameW : x2;
            y2 = y2 == -1 ? gameH : y2;
            x1 = x1 + gameX1;
            y1 = y1 + gameY1;
            x2 = x2 + gameX1;
            y2 = y2 + gameY1;
            object dx;
            object dy;
            int res = dm.FindPic(x1, y1, x2, y2, bmp, "000000", sim, 0, out dx, out dy);
            x = Convert.ToInt32(dx);
            y = Convert.ToInt32(dy);
            if (res != 0)
            {
                return false;
            }
            if (x < 0 && y < 0)
            {
                return false;
            }
            return true;
        }

        private static void DebugBmp(int x1, int y1, int x2, int y2, string bmp)
        {
            if (isDebug)
            {
                string debugBmp = System.AppDomain.CurrentDomain.BaseDirectory + "bmp\\debug\\debug" + debug.ToString() + bmp + ".bmp";
                dmsoft dm = GetDm();
                dm.Capture(x1, y1, x2, y2, debugBmp);
                debug++;

            }
        }

        public static void Click(int x, int dx, int y, int dy, int delay)
        {
            dmsoft dm = GetDm();
            Random random = new Random();
            int r = random.Next(1, 11);
            if (r == 10)
            {
                Utils.Delay(random.Next(1000, 3000));
            }
            else
            {
                Utils.Delay(random.Next(250, 750));
            }
            x += gameX1;
            y += gameY1;
            x += random.Next(0, dx);
            y += random.Next(0, dy);
            dm.MoveTo(x, y);
            Utils.Delay(100);
            dm.LeftClick();
            // Outputs.Log("x" + x.ToString() + " y" + y.ToString());
        }
    }
}
