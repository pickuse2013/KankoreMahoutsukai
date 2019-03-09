namespace KankoreMahoutsukai
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.attackCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.aimAttackNum = new System.Windows.Forms.TextBox();
            this.isNightFighting = new System.Windows.Forms.ComboBox();
            this.formation = new System.Windows.Forms.ComboBox();
            this.breakage = new System.Windows.Forms.ComboBox();
            this.fatigue = new System.Windows.Forms.ComboBox();
            this.resource = new System.Windows.Forms.ComboBox();
            this.breakageIndex = new System.Windows.Forms.ComboBox();
            this.fatigueIndex = new System.Windows.Forms.ComboBox();
            this.resourceIndex = new System.Windows.Forms.ComboBox();
            this.point = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.expedition3 = new System.Windows.Forms.ComboBox();
            this.expedition2 = new System.Windows.Forms.ComboBox();
            this.expedition1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.smallFastFix = new System.Windows.Forms.ComboBox();
            this.middleFastFix = new System.Windows.Forms.ComboBox();
            this.bigFastFix = new System.Windows.Forms.ComboBox();
            this.fix = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.end = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "运行状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Black;
            this.status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Location = new System.Drawing.Point(120, 30);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(270, 20);
            this.status.TabIndex = 1;
            this.status.Text = "运行状态";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(20, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 274);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.attackCount);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.aimAttackNum);
            this.tabPage1.Controls.Add(this.isNightFighting);
            this.tabPage1.Controls.Add(this.formation);
            this.tabPage1.Controls.Add(this.breakage);
            this.tabPage1.Controls.Add(this.fatigue);
            this.tabPage1.Controls.Add(this.resource);
            this.tabPage1.Controls.Add(this.breakageIndex);
            this.tabPage1.Controls.Add(this.fatigueIndex);
            this.tabPage1.Controls.Add(this.resourceIndex);
            this.tabPage1.Controls.Add(this.point);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(367, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "战斗";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // attackCount
            // 
            this.attackCount.Location = new System.Drawing.Point(70, 220);
            this.attackCount.Name = "attackCount";
            this.attackCount.Size = new System.Drawing.Size(80, 21);
            this.attackCount.TabIndex = 20;
            this.attackCount.Text = "0";
            this.attackCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "出击次数";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aimAttackNum
            // 
            this.aimAttackNum.Location = new System.Drawing.Point(70, 180);
            this.aimAttackNum.Name = "aimAttackNum";
            this.aimAttackNum.Size = new System.Drawing.Size(80, 21);
            this.aimAttackNum.TabIndex = 18;
            this.aimAttackNum.Text = "999";
            this.aimAttackNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aimAttackNum_KeyPress);
            // 
            // isNightFighting
            // 
            this.isNightFighting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.isNightFighting.FormattingEnabled = true;
            this.isNightFighting.Items.AddRange(new object[] {
            "否",
            "是"});
            this.isNightFighting.Location = new System.Drawing.Point(230, 150);
            this.isNightFighting.Name = "isNightFighting";
            this.isNightFighting.Size = new System.Drawing.Size(80, 20);
            this.isNightFighting.TabIndex = 17;
            // 
            // formation
            // 
            this.formation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formation.FormattingEnabled = true;
            this.formation.Items.AddRange(new object[] {
            "单纵阵",
            "复纵阵",
            "轮形阵",
            "梯形阵",
            "单横阵"});
            this.formation.Location = new System.Drawing.Point(70, 150);
            this.formation.Name = "formation";
            this.formation.Size = new System.Drawing.Size(80, 20);
            this.formation.TabIndex = 16;
            // 
            // breakage
            // 
            this.breakage.DisplayMember = "0";
            this.breakage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.breakage.FormattingEnabled = true;
            this.breakage.Items.AddRange(new object[] {
            "随意出击",
            "小破禁止出击",
            "中破禁止出击"});
            this.breakage.Location = new System.Drawing.Point(180, 110);
            this.breakage.Name = "breakage";
            this.breakage.Size = new System.Drawing.Size(130, 20);
            this.breakage.TabIndex = 15;
            this.breakage.ValueMember = "0";
            // 
            // fatigue
            // 
            this.fatigue.DisplayMember = "0";
            this.fatigue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fatigue.DropDownWidth = 110;
            this.fatigue.FormattingEnabled = true;
            this.fatigue.Items.AddRange(new object[] {
            "随意出击",
            "黄脸禁止出击",
            "红脸禁止出击"});
            this.fatigue.Location = new System.Drawing.Point(180, 80);
            this.fatigue.Name = "fatigue";
            this.fatigue.Size = new System.Drawing.Size(130, 20);
            this.fatigue.TabIndex = 14;
            this.fatigue.ValueMember = "0";
            // 
            // resource
            // 
            this.resource.DisplayMember = "0";
            this.resource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resource.DropDownWidth = 110;
            this.resource.FormattingEnabled = true;
            this.resource.Items.AddRange(new object[] {
            "随意出击",
            "黄油弹禁止出击",
            "红油弹禁止出击"});
            this.resource.Location = new System.Drawing.Point(180, 50);
            this.resource.Name = "resource";
            this.resource.Size = new System.Drawing.Size(130, 20);
            this.resource.TabIndex = 13;
            this.resource.ValueMember = "0";
            // 
            // breakageIndex
            // 
            this.breakageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.breakageIndex.FormattingEnabled = true;
            this.breakageIndex.Items.AddRange(new object[] {
            "所有人",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.breakageIndex.Location = new System.Drawing.Point(80, 110);
            this.breakageIndex.Name = "breakageIndex";
            this.breakageIndex.Size = new System.Drawing.Size(80, 20);
            this.breakageIndex.TabIndex = 12;
            // 
            // fatigueIndex
            // 
            this.fatigueIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fatigueIndex.FormattingEnabled = true;
            this.fatigueIndex.Items.AddRange(new object[] {
            "所有人",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.fatigueIndex.Location = new System.Drawing.Point(80, 80);
            this.fatigueIndex.Name = "fatigueIndex";
            this.fatigueIndex.Size = new System.Drawing.Size(80, 20);
            this.fatigueIndex.TabIndex = 11;
            // 
            // resourceIndex
            // 
            this.resourceIndex.DisplayMember = "0";
            this.resourceIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceIndex.FormattingEnabled = true;
            this.resourceIndex.Items.AddRange(new object[] {
            "所有人",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.resourceIndex.Location = new System.Drawing.Point(80, 50);
            this.resourceIndex.Name = "resourceIndex";
            this.resourceIndex.Size = new System.Drawing.Size(80, 20);
            this.resourceIndex.TabIndex = 10;
            this.resourceIndex.ValueMember = "0";
            // 
            // point
            // 
            this.point.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.point.FormattingEnabled = true;
            this.point.Items.AddRange(new object[] {
            "1-1",
            "1-2",
            "1-3",
            "1-4",
            "1-5",
            "1-6",
            "2-1",
            "2-2",
            "2-3",
            "2-4",
            "2-5",
            "2-6",
            "3-1",
            "3-2",
            "3-3",
            "3-4",
            "3-5",
            "3-6"});
            this.point.Location = new System.Drawing.Point(80, 10);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(100, 20);
            this.point.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "战斗次数";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(170, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "夜战";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "阵型";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "破损检查";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "疲劳检查";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "油弹检查";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "选择关卡";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.expedition3);
            this.tabPage2.Controls.Add(this.expedition2);
            this.tabPage2.Controls.Add(this.expedition1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(367, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "远征";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // expedition3
            // 
            this.expedition3.DisplayMember = "0";
            this.expedition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expedition3.FormattingEnabled = true;
            this.expedition3.Items.AddRange(new object[] {
            "不远征",
            "1 练习航海",
            "2 长距离练习航海",
            "3 警备任务",
            "4 对潜警戒任务",
            "5 海上护卫任务",
            "6 防空射击演习",
            "7 观舰式予行",
            "8 观舰式",
            "9 油轮护卫任务",
            "10 强行侦察任务",
            "11 铝土矿输送任务",
            "12 资源输送任务",
            "13 鼠输送作战",
            "14 包围圈内陆战队撤收作战",
            "15 诱饵机动部队支援作战",
            "16 舰队决战支援作战",
            "17 敌方阵地侦察作战",
            "18 舰载机输送作战",
            "19 北号作战",
            "20 潜水舰哨戒任务",
            "21 北方鼠输送作战",
            "22 舰队演习",
            "23 航空战舰运用演习",
            "24 北方航路海上护卫",
            "25 通商破坏作战",
            "26 敌母港空袭作战",
            "27 潜水舰通商破坏作战",
            "28 西方海域封锁作战",
            "29 潜水舰派遣演习",
            "30 潜水舰派遣作战",
            "31 海外舰的接触",
            "32 远洋练习航海",
            "33 前卫支援任务",
            "34 舰队决战支援任务",
            "35 MO作战",
            "36 水上飞机基地建设",
            "37 东京急行",
            "38 东京急行(二)",
            "39 远洋潜水舰作战",
            "40 水上机前线输送"});
            this.expedition3.Location = new System.Drawing.Point(100, 100);
            this.expedition3.Name = "expedition3";
            this.expedition3.Size = new System.Drawing.Size(200, 20);
            this.expedition3.TabIndex = 13;
            this.expedition3.ValueMember = "0";
            this.expedition3.SelectedIndexChanged += new System.EventHandler(this.expedition3_SelectedIndexChanged);
            // 
            // expedition2
            // 
            this.expedition2.DisplayMember = "0";
            this.expedition2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expedition2.FormattingEnabled = true;
            this.expedition2.Items.AddRange(new object[] {
            "不远征",
            "1 练习航海",
            "2 长距离练习航海",
            "3 警备任务",
            "4 对潜警戒任务",
            "5 海上护卫任务",
            "6 防空射击演习",
            "7 观舰式予行",
            "8 观舰式",
            "9 油轮护卫任务",
            "10 强行侦察任务",
            "11 铝土矿输送任务",
            "12 资源输送任务",
            "13 鼠输送作战",
            "14 包围圈内陆战队撤收作战",
            "15 诱饵机动部队支援作战",
            "16 舰队决战支援作战",
            "17 敌方阵地侦察作战",
            "18 舰载机输送作战",
            "19 北号作战",
            "20 潜水舰哨戒任务",
            "21 北方鼠输送作战",
            "22 舰队演习",
            "23 航空战舰运用演习",
            "24 北方航路海上护卫",
            "25 通商破坏作战",
            "26 敌母港空袭作战",
            "27 潜水舰通商破坏作战",
            "28 西方海域封锁作战",
            "29 潜水舰派遣演习",
            "30 潜水舰派遣作战",
            "31 海外舰的接触",
            "32 远洋练习航海",
            "33 前卫支援任务",
            "34 舰队决战支援任务",
            "35 MO作战",
            "36 水上飞机基地建设",
            "37 东京急行",
            "38 东京急行(二)",
            "39 远洋潜水舰作战",
            "40 水上机前线输送"});
            this.expedition2.Location = new System.Drawing.Point(100, 60);
            this.expedition2.Name = "expedition2";
            this.expedition2.Size = new System.Drawing.Size(200, 20);
            this.expedition2.TabIndex = 12;
            this.expedition2.ValueMember = "0";
            this.expedition2.SelectedIndexChanged += new System.EventHandler(this.expedition2_SelectedIndexChanged);
            // 
            // expedition1
            // 
            this.expedition1.DisplayMember = "0";
            this.expedition1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expedition1.FormattingEnabled = true;
            this.expedition1.Items.AddRange(new object[] {
            "不远征",
            "1 练习航海",
            "2 长距离练习航海",
            "3 警备任务",
            "4 对潜警戒任务",
            "5 海上护卫任务",
            "6 防空射击演习",
            "7 观舰式予行",
            "8 观舰式",
            "9 油轮护卫任务",
            "10 强行侦察任务",
            "11 铝土矿输送任务",
            "12 资源输送任务",
            "13 鼠输送作战",
            "14 包围圈内陆战队撤收作战",
            "15 诱饵机动部队支援作战",
            "16 舰队决战支援作战",
            "17 敌方阵地侦察作战",
            "18 舰载机输送作战",
            "19 北号作战",
            "20 潜水舰哨戒任务",
            "21 北方鼠输送作战",
            "22 舰队演习",
            "23 航空战舰运用演习",
            "24 北方航路海上护卫",
            "25 通商破坏作战",
            "26 敌母港空袭作战",
            "27 潜水舰通商破坏作战",
            "28 西方海域封锁作战",
            "29 潜水舰派遣演习",
            "30 潜水舰派遣作战",
            "31 海外舰的接触",
            "32 远洋练习航海",
            "33 前卫支援任务",
            "34 舰队决战支援任务",
            "35 MO作战",
            "36 水上飞机基地建设",
            "37 东京急行",
            "38 东京急行(二)",
            "39 远洋潜水舰作战",
            "40 水上机前线输送"});
            this.expedition1.Location = new System.Drawing.Point(100, 20);
            this.expedition1.Name = "expedition1";
            this.expedition1.Size = new System.Drawing.Size(200, 20);
            this.expedition1.TabIndex = 11;
            this.expedition1.ValueMember = "0";
            this.expedition1.SelectedIndexChanged += new System.EventHandler(this.expedition1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(20, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "远征4队";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(20, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "远征3队";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "远征2队";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.smallFastFix);
            this.tabPage3.Controls.Add(this.middleFastFix);
            this.tabPage3.Controls.Add(this.bigFastFix);
            this.tabPage3.Controls.Add(this.fix);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(367, 248);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "修复";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(100, 140);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 20);
            this.label18.TabIndex = 16;
            this.label18.Text = "小破";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(100, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 20);
            this.label17.TabIndex = 15;
            this.label17.Text = "中破";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(100, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "大破";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smallFastFix
            // 
            this.smallFastFix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smallFastFix.FormattingEnabled = true;
            this.smallFastFix.Items.AddRange(new object[] {
            "否",
            "是"});
            this.smallFastFix.Location = new System.Drawing.Point(160, 140);
            this.smallFastFix.Name = "smallFastFix";
            this.smallFastFix.Size = new System.Drawing.Size(60, 20);
            this.smallFastFix.TabIndex = 13;
            // 
            // middleFastFix
            // 
            this.middleFastFix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.middleFastFix.FormattingEnabled = true;
            this.middleFastFix.Items.AddRange(new object[] {
            "否",
            "是"});
            this.middleFastFix.Location = new System.Drawing.Point(160, 100);
            this.middleFastFix.Name = "middleFastFix";
            this.middleFastFix.Size = new System.Drawing.Size(60, 20);
            this.middleFastFix.TabIndex = 12;
            // 
            // bigFastFix
            // 
            this.bigFastFix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bigFastFix.FormattingEnabled = true;
            this.bigFastFix.Items.AddRange(new object[] {
            "否",
            "是"});
            this.bigFastFix.Location = new System.Drawing.Point(160, 61);
            this.bigFastFix.Name = "bigFastFix";
            this.bigFastFix.Size = new System.Drawing.Size(60, 20);
            this.bigFastFix.TabIndex = 11;
            // 
            // fix
            // 
            this.fix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fix.FormattingEnabled = true;
            this.fix.Items.AddRange(new object[] {
            "不修理",
            "仅修理大破",
            "修理中破和大破",
            "全部修理"});
            this.fix.Location = new System.Drawing.Point(100, 20);
            this.fix.Name = "fix";
            this.fix.Size = new System.Drawing.Size(120, 20);
            this.fix.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(20, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "快速修复";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(20, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "舰娘修复";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(430, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "战斗日志";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(430, 70);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log.Size = new System.Drawing.Size(200, 280);
            this.log.TabIndex = 4;
            this.log.WordWrap = false;
            this.log.TextChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(20, 366);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(84, 23);
            this.start.TabIndex = 5;
            this.start.Text = "开始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // end
            // 
            this.end.Enabled = false;
            this.end.Location = new System.Drawing.Point(122, 366);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(84, 23);
            this.end.TabIndex = 6;
            this.end.Text = "停止";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(546, 30);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(84, 23);
            this.clear.TabIndex = 7;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 401);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.end);
            this.Controls.Add(this.start);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "艦これ魔法使い";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox log;
        public System.Windows.Forms.Label status;
        public System.Windows.Forms.ComboBox point;
        public System.Windows.Forms.ComboBox breakageIndex;
        public System.Windows.Forms.ComboBox fatigueIndex;
        public System.Windows.Forms.ComboBox resourceIndex;
        public System.Windows.Forms.ComboBox breakage;
        public System.Windows.Forms.ComboBox fatigue;
        public System.Windows.Forms.ComboBox resource;
        public System.Windows.Forms.ComboBox isNightFighting;
        public System.Windows.Forms.ComboBox formation;
        public System.Windows.Forms.TextBox aimAttackNum;
        public System.Windows.Forms.TextBox attackCount;
        public System.Windows.Forms.Button start;
        public System.Windows.Forms.Button end;
        public System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox expedition1;
        public System.Windows.Forms.ComboBox expedition3;
        public System.Windows.Forms.ComboBox expedition2;
        public System.Windows.Forms.ComboBox fix;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox bigFastFix;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox smallFastFix;
        public System.Windows.Forms.ComboBox middleFastFix;
    }
}

