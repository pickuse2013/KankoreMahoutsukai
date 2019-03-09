using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KankoreMahoutsukai.process;

namespace KankoreMahoutsukai
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.point.SelectedIndex = 0;
            this.resourceIndex.SelectedIndex = 0;
            this.fatigueIndex.SelectedIndex = 0;
            this.breakageIndex.SelectedIndex = 0;
            this.resource.SelectedIndex = 0;
            this.fatigue.SelectedIndex = 0;
            this.breakage.SelectedIndex = 0;
            this.formation.SelectedIndex = 0;
            this.isNightFighting.SelectedIndex = 0;
            this.expedition1.SelectedIndex = 0;
            this.expedition2.SelectedIndex = 0;
            this.expedition3.SelectedIndex = 0;
            this.fix.SelectedIndex = 0;
            this.bigFastFix.SelectedIndex = 0;
            this.middleFastFix.SelectedIndex = 0;
            this.smallFastFix.SelectedIndex = 0;
        }

        private void start_Click(object sender, EventArgs e)
        {
            Process.Start();
        }

        private void aimAttackNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void end_Click(object sender, EventArgs e)
        {
            // Process.End(); 调试正常，打包后会无法捕捉异常

            Process.End();

        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.log.Text = "";
        }

        private void log_TextChanged(object sender, EventArgs e)
        {
            form1.log.SelectionStart = form1.log.TextLength;
            form1.log.ScrollToCaret();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Process.GetStatus())
            {
                DialogResult dr = MessageBox.Show("脚本正在执行中，确定要退出吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.OK)   //如果单击“是”按钮
                {
                    Process.End();
                    e.Cancel = false;                 //关闭窗体
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;                  //不执行操作
                }
            }
        }

        private void expedition1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var expedition = expedition1;
            int i1 = expedition2.SelectedIndex;
            int i2 = expedition3.SelectedIndex;
            int index = expedition.SelectedIndex;

            if (i1 != 0 && i1 == index || i2 != 0 && i2 == index)
            {
                MessageBox.Show("远征不能重复！");
                expedition.SelectedIndex = 0;
            }
        }

        private void expedition2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var expedition = expedition2;
            int i1 = expedition1.SelectedIndex;
            int i2 = expedition3.SelectedIndex;
            int index = expedition.SelectedIndex;

            if (i1 != 0 && i1 == index || i2 != 0 && i2 == index)
            {
                MessageBox.Show("远征不能重复！");
                expedition.SelectedIndex = 0;
            }
        }

        private void expedition3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var expedition = expedition3;
            int i1 = expedition1.SelectedIndex;
            int i2 = expedition2.SelectedIndex;
            int index = expedition.SelectedIndex;

            if (i1 != 0 && i1 == index || i2 != 0 && i2 == index)
            {
                MessageBox.Show("远征不能重复！");
                expedition.SelectedIndex = 0;
            }
        }
    }
}
