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
using KankoreMahoutsukai.utils;

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

            IniFiles ini = new IniFiles(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
            if (ini.ExistINIFile())
            {
                this.point.SelectedIndex = ini.IniReadValueInt("Attack", "point");
                this.resourceIndex.SelectedIndex = ini.IniReadValueInt("Attack", "resourceIndex");
                this.fatigueIndex.SelectedIndex = ini.IniReadValueInt("Attack", "fatigueIndex");
                this.breakageIndex.SelectedIndex = ini.IniReadValueInt("Attack", "breakageIndex");
                this.resource.SelectedIndex = ini.IniReadValueInt("Attack", "resource");
                this.fatigue.SelectedIndex = ini.IniReadValueInt("Attack", "fatigue");
                this.breakage.SelectedIndex = ini.IniReadValueInt("Attack", "breakage");
                this.formation.SelectedIndex = ini.IniReadValueInt("Attack", "formation");
                this.isNightFighting.SelectedIndex = ini.IniReadValueInt("Attack", "isNightFighting");
                this.aimAttackNum.Text = ini.IniReadValue("Attack", "aimAttackNum");
                this.attackCount.Text = ini.IniReadValue("Attack", "attackCount");

                this.expedition1.SelectedIndex = ini.IniReadValueInt("Expedition", "expedition1");
                this.expedition2.SelectedIndex = ini.IniReadValueInt("Expedition", "expedition2");
                this.expedition3.SelectedIndex = ini.IniReadValueInt("Expedition", "expedition3");

                this.fix.SelectedIndex = ini.IniReadValueInt("Fix", "fix");
                this.bigFastFix.SelectedIndex = ini.IniReadValueInt("Fix", "bigFastFix");
                this.middleFastFix.SelectedIndex = ini.IniReadValueInt("Fix", "middleFastFix");
                this.smallFastFix.SelectedIndex = ini.IniReadValueInt("Fix", "smallFastFix");
            }
            else
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
            IniFiles ini = new IniFiles(AppDomain.CurrentDomain.BaseDirectory + "config.ini");

            ini.IniWriteValue("Attack", "point", form1.point.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "resourceIndex", form1.resourceIndex.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "fatigueIndex", form1.fatigueIndex.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "breakageIndex", form1.breakageIndex.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "resource", form1.resource.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "fatigue", form1.fatigue.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "breakage", form1.breakage.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "formation", form1.formation.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "isNightFighting", form1.isNightFighting.SelectedIndex.ToString());
            ini.IniWriteValue("Attack", "aimAttackNum", form1.aimAttackNum.Text);
            ini.IniWriteValue("Attack", "attackCount", form1.attackCount.Text);

            ini.IniWriteValue("Expedition", "expedition1", form1.expedition1.SelectedIndex.ToString());
            ini.IniWriteValue("Expedition", "expedition2", form1.expedition2.SelectedIndex.ToString());
            ini.IniWriteValue("Expedition", "expedition3", form1.expedition3.SelectedIndex.ToString());

            ini.IniWriteValue("Fix", "fix", form1.fix.SelectedIndex.ToString());
            ini.IniWriteValue("Fix", "bigFastFix", form1.bigFastFix.SelectedIndex.ToString());
            ini.IniWriteValue("Fix", "middleFastFix", form1.middleFastFix.SelectedIndex.ToString());
            ini.IniWriteValue("Fix", "smallFastFix", form1.smallFastFix.SelectedIndex.ToString());

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
