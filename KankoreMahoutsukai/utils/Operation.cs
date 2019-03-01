using System;
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
        private static  int gameX1 = 0;
        private static  int gameY1 = 0;
        private static readonly int gameW = 1200;
        private static readonly int gameH = 720;
        private static int windowW = 0;
        private static int windowH = 0;
        private static int debug = 0;
        private static bool isDebug = false;

        private static dmsoft dm = null;
        private static int hwnd = 0;
        private static dmsoft GetDm()
        {
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

        public static bool GamePosition()
        {
            object w, h;
            int width, height, x, y;
            dmsoft dm = GetDm();
            dm.GetClientSize(hwnd, out w, out h);
            width = Convert.ToInt32(w);
            height = Convert.ToInt32(h);
            windowW = width;
            windowH = height;
            Outputs.Log("定位游戏窗口中，请勿更改poi浏览器大小");
            gameX1 = 0;
            gameY1 = 0;
            if (!FindPic(0, 0, width, height, "position", 0.9, out x, out y))
            {
                Outputs.Log("未找到游戏窗口");
                return false;
            }
            gameX1 = x - 1;
            gameY1 = y + 1;
            DebugBmp(0, 0, gameW - 1, gameH - 1, "t");
            Outputs.Log("游戏窗口已更新：" + "x" + gameX1.ToString() + "y" + gameY1.ToString());
            return true;
        }

        public static bool FindPic(int x1, int y1, int x2, int y2, string bmp, double sim, out int x, out int y)
        {
            dmsoft dm = GetDm();
            object w, h;
            int width, height;
            dm.GetClientSize(hwnd, out w, out h);
            width = Convert.ToInt32(w);
            height = Convert.ToInt32(h);
            if (width != windowW || height != windowH)
            {
                Outputs.Log("poi浏览器大小改变，即将重新定位游戏窗口");
                Utils.Delay(2000);
                GamePosition();
            }
            DebugBmp(x1, y1, x2, y2, bmp);
            bmp = System.AppDomain.CurrentDomain.BaseDirectory + "bmp\\" + bmp + ".bmp";
            if (!System.IO.File.Exists(bmp))
            {
                Outputs.Msg(bmp + "资源图片缺失，请检查bmp文件夹");
                x = -1;
                y = -1;
                return false;
            }
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

            int x, y;
            return FindPic(x1, y1, x2, y2, bmp, sim, out x, out y);
        }

        public static bool FindPic(string bmp, double sim, out int x, out int y)
        {
            int x1 = 0, y1 = 0, x2 = x1 + gameW - 1, y2 = y1 + gameH - 1;
            return FindPic(x1, y1, x2, y2, bmp, sim, out x, out y);
        }

        public static bool FindPic(string bmp, out int x, out int y)
        {
            double sim = 0.8;
            return FindPic(bmp, sim, out x, out y);
        }

        public static bool FindPic(string bmp, double sim)
        {
            int x, y;
            return FindPic(bmp, sim, out x, out y);
        }

        public static bool FindPic(string bmp)
        {
            double sim = 0.8;
            return FindPic(bmp, sim);
        }

        public static bool FindPic(int x1, int y1, int x2, int y2, string[] bmps, out int x, out int y)
        {
            dmsoft dm = GetDm();
            string bmp = "";
            for (int i = 0; i < bmps.Length; i++)
            {
                bmp = bmps[i];
                if (FindPic(x1, y1, x2, y2, bmp, 0.8, out x, out y))
                {
                    return true;
                }
            }
            x = -1;
            y = -1;
            return false;
        }

        public static bool FindPic(string[] bmps, out int x, out int y)
        {
            int x1 = 0, y1 = 0, x2 = x1 + gameW - 1, y2 = y1 + gameH - 1;
            return FindPic(x1, y1, x2, y2, bmps, out x, out y);
        }

        public static bool FindPic(int x1, int y1, int x2, int y2, string[] bmps)
        {
            int x, y;
            return FindPic(x1, y1, x2, y2, bmps, out x, out y);
        }

        public static bool FindPic(string[] bmps)
        {
            int x, y;
            return FindPic(bmps, out x, out y);
        }

        public static bool FindPic(string area, string bmp, double sim, out int x, out int y)
        {

            int x1 = 0, y1 = 0, x2 = x1 + gameW - 1, y2 = y1 + gameH - 1;
            switch (area)
            {
                case "A":
                    x1 = 0; y1 = 0; x2 = x1 + gameW / 2 - 1; y2 = y1 + gameH / 2 - 1;
                    break;
                case "B":
                    x1 = gameW / 2 - 1; y1 = 0; x2 = x1 + gameW / 2; y2 = y1 + gameH / 2 - 1;
                    break;
                case "C":
                    x1 = 0; y1 = gameH / 2 - 1; x2 = x1 + gameW / 2 - 1; y2 = y1 + gameH / 2;
                    break;
                case "D":
                    x1 = gameW / 2 - 1; y1 = gameW / 2 - 1; x2 = x1 + gameW / 2; y2 = y1 + gameH / 2;
                    break;
                case "E":
                    x1 = 0; y1 = 0; x2 = x1 + gameW - 1; y2 = y1 + gameH / 2 - 1;
                    break;
                case "F":
                    x1 = 0; y1 = gameH / 2 - 1; x2 = x1 + gameW - 1; y2 = y1 + gameH / 2;
                    break;
            }
            return FindPic(x1, y1, x2, y2, bmp, sim, out x, out y);
        }

        public static bool FindPic(string area, string bmp, out int x, out int y)
        {
            double sim = 0.8;
            return FindPic(area, bmp, sim, out x, out y);
        }

        public static bool FindPic(string area, string bmp, double sim)
        {
            int x, y;
            return FindPic(area, bmp, sim, out x, out y);
        }

        public static bool FindPic(string area, string bmp)
        {
            double sim = 0.8;
            return FindPic(area, bmp, sim);
        }








        private static void DebugBmp(int x1, int y1, int x2, int y2, string bmp)
        {
            if (isDebug)
            {
                string debugBmp = System.AppDomain.CurrentDomain.BaseDirectory + "bmp\\debug\\" + debug.ToString() + bmp + ".bmp";
                dmsoft dm = GetDm();
                x1 = x1 + gameX1;
                y1 = y1 + gameY1;
                x2 = x2 + gameX1;
                y2 = y2 + gameY1;
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
            Outputs.Log("x" + x.ToString() + " y" + y.ToString());
        }
    }
}
