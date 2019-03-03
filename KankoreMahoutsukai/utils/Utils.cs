using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KankoreMahoutsukai.process;

namespace KankoreMahoutsukai.utils
{
    class Utils
    {
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                // Application.DoEvents();
            }
        }

        public static void TimeOut(Func<bool> func, int time)
        {
            TimeOut(func, time, "超时");
        }

        public static void TimeOut(Func<bool> func, int time, string msg)
        {
            int i = 0;
            while (func())
            {
                if (i >= 10)
                {
                    Process.End(msg);
                    break;
                }
                i++;
                Delay(time);
            }
        }
    }
}
