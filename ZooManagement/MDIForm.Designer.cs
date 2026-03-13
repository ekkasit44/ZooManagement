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
            mnuAnimalform = new ToolStripMenuItem();
            mnuAnimal = new ToolStripMenuItem();
            mnuFood = new ToolStripMenuItem();
            mnuAnimalType = new ToolStripMenuItem();
            mnuSpeciesInfo = new ToolStripMenuItem();
            mnuEfrm = new ToolStripMenuItem();
            nmuEnclosure = new ToolStripMenuItem();
            nmuKeeper = new ToolStripMenuItem();
            mnuArrangeF = new ToolStripMenuItem();
            mnuVertical = new ToolStripMenuItem();
            mnuHorizontal = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuF, mnuAnimalform, mnuEfrm, mnuArrangeF });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(776, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // mnuF
            // 
            mnuF.BackColor = Color.FromArgb(224, 224, 224);
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
            // mnuAnimalform
            // 
            mnuAnimalform.BackColor = Color.FromArgb(224, 224, 224);
            mnuAnimalform.DropDownItems.AddRange(new ToolStripItem[] { mnuAnimal, mnuFood, mnuAnimalType, mnuSpeciesInfo });
            mnuAnimalform.Name = "mnuAnimalform";
            mnuAnimalform.Size = new Size(119, 24);
            mnuAnimalform.Text = "จัดการข้อมูลสัตว์";
            mnuAnimalform.Click += mnuAnimalform_Click;
            // 
            // mnuAnimal
            // 
            mnuAnimal.Name = "mnuAnimal";
            mnuAnimal.Size = new Size(224, 26);
            mnuAnimal.Text = "ข้อมูลสัตว์";
            mnuAnimal.Click += mnuAnimal_Click;
            // 
            // mnuFood
            // 
            mnuFood.Name = "mnuFood";
            mnuFood.Size = new Size(224, 26);
            mnuFood.Text = "ข้อมูลอาหาร";
            mnuFood.Click += mnuFood_Click;
            // 
            // mnuAnimalType
            // 
            mnuAnimalType.Name = "mnuAnimalType";
            mnuAnimalType.Size = new Size(224, 26);
            mnuAnimalType.Text = "ข้อมูลประเภทของสัตว์";
            mnuAnimalType.Click += mnuAnimalType_Click;
            // 
            // mnuSpeciesInfo
            // 
            mnuSpeciesInfo.Name = "mnuSpeciesInfo";
            mnuSpeciesInfo.Size = new Size(224, 26);
            mnuSpeciesInfo.Text = "ข้อมูลชนิดพันธุ์";
            mnuSpeciesInfo.Click += mnuSpeciesInfo_Click;
            // 
            // mnuEfrm
            // 
            mnuEfrm.BackColor = Color.FromArgb(224, 224, 224);
            mnuEfrm.DropDownItems.AddRange(new ToolStripItem[] { nmuEnclosure, nmuKeeper });
            mnuEfrm.Name = "mnuEfrm";
            mnuEfrm.Size = new Size(140, 24);
            mnuEfrm.Text = "จัดการข้อมูลกรงสัตว์";
            mnuEfrm.Click += mnuEfrm_Click;
            // 
            // nmuEnclosure
            // 
            nmuEnclosure.Name = "nmuEnclosure";
            nmuEnclosure.Size = new Size(224, 26);
            nmuEnclosure.Text = "ข้อมูลกรงสัตว์";
            nmuEnclosure.Click += mnuEnclosure_Click;
            // 
            // nmuKeeper
            // 
            nmuKeeper.Name = "nmuKeeper";
            nmuKeeper.Size = new Size(224, 26);
            nmuKeeper.Text = "ข้อมูลผู้ดูแลกรงสัตว์";
            nmuKeeper.Click += mnuKeeper_Click;
            // 
            // mnuArrangeF
            // 
            mnuArrangeF.BackColor = Color.FromArgb(224, 224, 224);
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
            // MDIForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 617);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MDIForm";
            Text = "ZooManagement";
            Load += MDIForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
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
        private ToolStripMenuItem mnuAnimalform;
        private ToolStripMenuItem mnuAnimal;
        private ToolStripMenuItem mnuAnimalType;
        private ToolStripMenuItem mnuSpeciesInfo;
        private ToolStripMenuItem mnuEfrm;
        private ToolStripMenuItem nmuEnclosure;
        private ToolStripMenuItem nmuKeeper;
        private ToolStripMenuItem mnuFood;
    }
}