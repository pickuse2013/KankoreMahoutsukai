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
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.point.SelectedIndex = 0;
            this.resourcesIndex.SelectedIndex = 0;
            this.fatigueIndex.SelectedIndex = 0;
            this.breakageIndex.SelectedIndex = 0;
            this.resources.SelectedIndex = 0;
            this.fatigue.SelectedIndex = 0;
            this.breakage.SelectedIndex = 0;
            this.formation.SelectedIndex = 0;
            this.isNightFighting.SelectedIndex = 0;
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
            Process.End();
        }
    }
}
