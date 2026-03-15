namespace ZooManagement
{
    partial class AnimalEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.DateTimePicker dtBirth;
        private System.Windows.Forms.Label lblEnclosure;
        private System.Windows.Forms.ComboBox cmbEnclosure;
        private System.Windows.Forms.Label lblKeeper;
        private System.Windows.Forms.ComboBox cmbKeeper;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.ComboBox cmbSpecies;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            cbGender = new ComboBox();
            dtBirth = new DateTimePicker();
            lblEnclosure = new Label();
            cmbEnclosure = new ComboBox();
            lblKeeper = new Label();
            cmbKeeper = new ComboBox();
            lblType = new Label();
            cmbType = new ComboBox();
            lblSpecies = new Label();
            cmbSpecies = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "ชื่อสัตว์";
            // 
            // label2
            // 
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "เพศ";
            // 
            // label3
            // 
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "วันเกิด";
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(223, 27);
            txtName.TabIndex = 1;
            // 
            // cbGender
            // 
            cbGender.Items.AddRange(new object[] { "ผู้", "เมีย" });
            cbGender.Location = new Point(150, 70);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 28);
            cbGender.TabIndex = 3;
            // 
            // dtBirth
            // 
            dtBirth.Location = new Point(150, 110);
            dtBirth.Name = "dtBirth";
            dtBirth.Size = new Size(200, 27);
            dtBirth.TabIndex = 5;
            // 
            // lblEnclosure
            // 
            lblEnclosure.Location = new Point(30, 150);
            lblEnclosure.Name = "lblEnclosure";
            lblEnclosure.Size = new Size(100, 23);
            lblEnclosure.TabIndex = 8;
            lblEnclosure.Text = "กรง";
            // 
            // cmbEnclosure
            // 
            cmbEnclosure.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnclosure.Location = new Point(150, 150);
            cmbEnclosure.Name = "cmbEnclosure";
            cmbEnclosure.Size = new Size(223, 28);
            cmbEnclosure.TabIndex = 9;
            cmbEnclosure.SelectedIndexChanged += cmbEnclosure_SelectedIndexChanged;
            // 
            // lblKeeper
            // 
            lblKeeper.Location = new Point(30, 190);
            lblKeeper.Name = "lblKeeper";
            lblKeeper.Size = new Size(100, 23);
            lblKeeper.TabIndex = 10;
            lblKeeper.Text = "ผู้ดูแล";
            // 
            // cmbKeeper
            // 
            cmbKeeper.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKeeper.Location = new Point(150, 190);
            cmbKeeper.Name = "cmbKeeper";
            cmbKeeper.Size = new Size(223, 28);
            cmbKeeper.TabIndex = 11;
            // 
            // lblType
            // 
            lblType.Location = new Point(30, 291);
            lblType.Name = "lblType";
            lblType.Size = new Size(55, 23);
            lblType.TabIndex = 12;
            lblType.Text = "ชนิด";
            // 
            // cmbType
            // 
            cmbType.Location = new Point(150, 236);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 28);
            cmbType.TabIndex = 13;
            // 
            // lblSpecies
            // 
            lblSpecies.Location = new Point(12, 319);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(100, 23);
            lblSpecies.TabIndex = 14;
            // 
            // cmbSpecies
            // 
            cmbSpecies.Location = new Point(150, 291);
            cmbSpecies.Name = "cmbSpecies";
            cmbSpecies.Size = new Size(223, 28);
            cmbSpecies.TabIndex = 15;
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDown; // allow typing new species name
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 471);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(250, 471);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.Location = new Point(30, 241);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 16;
            label4.Text = "ประเภท";
            // 
            // AnimalEditForm
            // 
            ClientSize = new Size(590, 554);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(cbGender);
            Controls.Add(label3);
            Controls.Add(dtBirth);
            Controls.Add(lblEnclosure);
            Controls.Add(cmbEnclosure);
            Controls.Add(lblKeeper);
            Controls.Add(cmbKeeper);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(lblSpecies);
            Controls.Add(cmbSpecies);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AnimalEditForm";
            Text = "Edit Animal";
            Load += AnimalEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label4;
    }
}