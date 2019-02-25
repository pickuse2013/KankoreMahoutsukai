using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KankoreMahoutsukai;

namespace KankoreMahoutsukai.utils
{
    class Outputs
    {
        public static void Log (string msg)
        {
            Form1.form1.status.Text = msg;
            Form1.form1.log.Text = Form1.form1.log.Text + msg + System.Environment.NewLine;
        }

        public static void Msg (string msg)
        {
            Log(msg);
            MessageBox.Show(msg);
        }
    }
}
