namespace ZooManagement
{
    partial class AnimalTypeEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.ComboBox cmbTypeName;
        private System.Windows.Forms.TextBox txtDescription;

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
            lblName = new Label();
            lblDescription = new Label();
            cmbTypeName = new ComboBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            cmbAnimal = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(68, 20);
            lblName.TabIndex = 0;
            lblName.Text = "ชื่อประเภท";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 80);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(65, 20);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "คำอธิบาย";
            // 
            // cmbTypeName
            // 
            cmbTypeName.Location = new Point(150, 30);
            cmbTypeName.Name = "cmbTypeName";
            cmbTypeName.Size = new Size(220, 28);
            cmbTypeName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(150, 80);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(220, 27);
            txtDescription.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(92, 249);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 4;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(232, 249);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "ยกเลิก";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbAnimal
            // 
            cmbAnimal.FormattingEnabled = true;
            cmbAnimal.Location = new Point(150, 132);
            cmbAnimal.Name = "cmbAnimal";
            cmbAnimal.Size = new Size(220, 28);
            cmbAnimal.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 140);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 7;
            label1.Text = "เลือกสัตว์";
            // 
            // AnimalTypeEditForm
            // 
            ClientSize = new Size(457, 311);
            Controls.Add(label1);
            Controls.Add(cmbAnimal);
            Controls.Add(lblName);
            Controls.Add(cmbTypeName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AnimalTypeEditForm";
            Text = "Animal Type";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbAnimal;
        private Label label1;
    }
}