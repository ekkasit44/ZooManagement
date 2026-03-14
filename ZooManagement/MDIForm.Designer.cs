namespace ZooManagement
{
    partial class MDIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuF = new ToolStripMenuItem();
            mnuMax = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuMin = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            mnuNomalF = new ToolStripMenuItem();
            mnuCloseF = new ToolStripMenuItem();
            mnuCloseAllF = new ToolStripMenuItem();
            mnuArrangeF = new ToolStripMenuItem();
            mnuVertical = new ToolStripMenuItem();
            mnuHorizontal = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolBtnAnimal = new ToolStripButton();
            toolBtnAnimalType = new ToolStripButton();
            toolBtnSpecies = new ToolStripButton();
            toolBtnEnclosure = new ToolStripButton();
            toolBtnKeeper = new ToolStripButton();
            toolBtnFood = new ToolStripButton();
            toolBtnFeeding = new ToolStripButton();
            toolBtnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSearchText = new ToolStripTextBox();
            toolStripSearchButton = new ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuF, mnuArrangeF });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(755, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // mnuF
            // 
            mnuF.BackColor = SystemColors.Control;
            mnuF.DropDownItems.AddRange(new ToolStripItem[] { mnuMax, toolStripMenuItem1, mnuMin, toolStripMenuItem2, mnuExit, toolStripMenuItem3, mnuNomalF, mnuCloseF, mnuCloseAllF });
            mnuF.Name = "mnuF";
            mnuF.Size = new Size(55, 24);
            mnuF.Text = "ฟอร์ม";
            // 
            // mnuMax
            // 
            mnuMax.Name = "mnuMax";
            mnuMax.Size = new Size(224, 26);
            mnuMax.Text = "ขยาย ";
            mnuMax.Click += mnuMax_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(221, 6);
            // 
            // mnuMin
            // 
            mnuMin.Name = "mnuMin";
            mnuMin.Size = new Size(224, 26);
            mnuMin.Text = "ย่อ  ";
            mnuMin.Click += mnuMin_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(221, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(224, 26);
            mnuExit.Text = "ปิดโปรแกรม ";
            mnuExit.Click += mnuExit_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(221, 6);
            // 
            // mnuNomalF
            // 
            mnuNomalF.Name = "mnuNomalF";
            mnuNomalF.Size = new Size(224, 26);
            mnuNomalF.Text = "ปกติ";
            mnuNomalF.Click += mnuNomalF_Click;
            // 
            // mnuCloseF
            // 
            mnuCloseF.Name = "mnuCloseF";
            mnuCloseF.Size = new Size(224, 26);
            mnuCloseF.Text = "ปิดฟอร์ม";
            mnuCloseF.Click += mnuCloseF_Click;
            // 
            // mnuCloseAllF
            // 
            mnuCloseAllF.Name = "mnuCloseAllF";
            mnuCloseAllF.Size = new Size(224, 26);
            mnuCloseAllF.Text = "ปิดฟอร์มทั้งหมด";
            mnuCloseAllF.Click += mnuCloseAllF_Click;
            // 
            // mnuArrangeF
            // 
            mnuArrangeF.BackColor = SystemColors.ButtonFace;
            mnuArrangeF.DropDownItems.AddRange(new ToolStripItem[] { mnuVertical, mnuHorizontal });
            mnuArrangeF.Name = "mnuArrangeF";
            mnuArrangeF.Size = new Size(96, 24);
            mnuArrangeF.Text = "จัดเรียงฟอร์ม";
            // 
            // mnuVertical
            // 
            mnuVertical.Name = "mnuVertical";
            mnuVertical.Size = new Size(224, 26);
            mnuVertical.Text = "แนวตั้ง";
            mnuVertical.Click += mnuVertical_Click;
            // 
            // mnuHorizontal
            // 
            mnuHorizontal.Name = "mnuHorizontal";
            mnuHorizontal.Size = new Size(224, 26);
            mnuHorizontal.Text = "แนวนอน";
            mnuHorizontal.Click += mnuHorizontal_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(240, 240, 255);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolBtnAnimal, toolBtnAnimalType, toolBtnSpecies, toolBtnEnclosure, toolBtnKeeper, toolBtnFood, toolBtnFeeding, toolBtnRefresh, toolStripSeparator1, toolStripSearchText, toolStripSearchButton });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(755, 29);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnAnimal
            // 
            toolBtnAnimal.Name = "toolBtnAnimal";
            toolBtnAnimal.Size = new Size(37, 26);
            toolBtnAnimal.Text = "สัตว์";
            toolBtnAnimal.ToolTipText = "เปิดหน้าข้อมูลสัตว์";
            toolBtnAnimal.Click += toolBtnAnimal_Click;
            // 
            // toolBtnAnimalType
            // 
            toolBtnAnimalType.Name = "toolBtnAnimalType";
            toolBtnAnimalType.Size = new Size(55, 26);
            toolBtnAnimalType.Text = "ประเภท";
            toolBtnAnimalType.ToolTipText = "เปิดหน้าประเภทสัตว์";
            toolBtnAnimalType.Click += toolBtnAnimalType_Click;
            // 
            // toolBtnSpecies
            // 
            toolBtnSpecies.Name = "toolBtnSpecies";
            toolBtnSpecies.Size = new Size(67, 26);
            toolBtnSpecies.Text = "ชนิดพันธุ์";
            toolBtnSpecies.ToolTipText = "เปิดหน้าชนิดพันธุ์";
            toolBtnSpecies.Click += toolBtnSpecies_Click;
            // 
            // toolBtnEnclosure
            // 
            toolBtnEnclosure.Name = "toolBtnEnclosure";
            toolBtnEnclosure.Size = new Size(34, 26);
            toolBtnEnclosure.Text = "กรง";
            toolBtnEnclosure.ToolTipText = "เปิดหน้ากรงสัตว์";
            toolBtnEnclosure.Click += toolBtnEnclosure_Click;
            // 
            // toolBtnKeeper
            // 
            toolBtnKeeper.Name = "toolBtnKeeper";
            toolBtnKeeper.Size = new Size(46, 26);
            toolBtnKeeper.Text = "ผู้ดูแล";
            toolBtnKeeper.ToolTipText = "เปิดหน้าผู้ดูแล";
            toolBtnKeeper.Click += toolBtnKeeper_Click;
            // 
            // toolBtnFood
            // 
            toolBtnFood.Name = "toolBtnFood";
            toolBtnFood.Size = new Size(50, 26);
            toolBtnFood.Text = "อาหาร";
            toolBtnFood.ToolTipText = "เปิดหน้าข้อมูลอาหาร";
            toolBtnFood.Click += toolBtnFood_Click;
            // 
            // toolBtnFeeding
            // 
            toolBtnFeeding.Name = "toolBtnFeeding";
            toolBtnFeeding.Size = new Size(91, 26);
            toolBtnFeeding.Text = "เวลาให้อาหาร";
            toolBtnFeeding.ToolTipText = "เปิดหน้าตารางเวลาให้อาหาร";
            toolBtnFeeding.Click += toolBtnFeeding_Click;
            // 
            // toolBtnRefresh
            // 
            toolBtnRefresh.Name = "toolBtnRefresh";
            toolBtnRefresh.Size = new Size(48, 26);
            toolBtnRefresh.Text = "รีเฟรช";
            toolBtnRefresh.ToolTipText = "รีเฟรชข้อมูลของฟอร์มที่เปิดอยู่";
            toolBtnRefresh.Click += toolBtnRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 29);
            // 
            // toolStripSearchText
            // 
            toolStripSearchText.Name = "toolStripSearchText";
            toolStripSearchText.Size = new Size(300, 27);
            toolStripSearchText.ToolTipText = "ค้นหา (ค้นหาคำในแถวเดียวกัน)";
            toolStripSearchText.KeyDown += ToolStripSearchText_KeyDown;
            // 
            // toolStripSearchButton
            // 
            toolStripSearchButton.Name = "toolStripSearchButton";
            toolStripSearchButton.Size = new Size(47, 24);
            toolStripSearchButton.Text = "ค้นหา";
            toolStripSearchButton.Click += ToolStripSearchButton_Click;
            // 
            // MDIForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 493);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MDIForm";
            Text = "ระบบจัดการสวนสัตว์";
            Load += MDIForm_Load;
            Resize += MDIForm_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripSearchText;
        private ToolStripButton toolStripSearchButton;
        private ToolStripButton toolBtnAnimal;
        private ToolStripButton toolBtnAnimalType;
        private ToolStripButton toolBtnSpecies;
        private ToolStripButton toolBtnEnclosure;
        private ToolStripButton toolBtnKeeper;
        private ToolStripButton toolBtnFood;
        private ToolStripButton toolBtnFeeding;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolBtnRefresh;
        private ToolStripMenuItem mnuF;
        private ToolStripMenuItem mnuMax;
        private ToolStripMenuItem mnuMin;
        private ToolStripMenuItem mnuExit;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem mnuArrangeF;
        private ToolStripMenuItem mnuVertical;
        private ToolStripMenuItem mnuHorizontal;
        private ToolStripMenuItem mnuNomalF;
        private ToolStripMenuItem mnuCloseF;
        private ToolStripMenuItem mnuCloseAllF;
    }
}
