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
            btnSave = new Button();
            btnCancel = new Button();
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
            // btnSave
            // 
            btnSave.Location = new Point(150, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(250, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // AnimalEditForm
            // 
            ClientSize = new Size(400, 230);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(cbGender);
            Controls.Add(label3);
            Controls.Add(dtBirth);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AnimalEditForm";
            Text = "Edit Animal";
            Load += AnimalEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }


    }
}