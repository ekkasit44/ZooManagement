namespace ZooManagement
{
    partial class AnimalTypeEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtTypeName;
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
            txtTypeName = new TextBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            // txtTypeName
            // 
            txtTypeName.Location = new Point(150, 30);
            txtTypeName.Name = "txtTypeName";
            txtTypeName.Size = new Size(220, 27);
            txtTypeName.TabIndex = 1;
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
            btnSave.Location = new Point(80, 140);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 4;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(220, 140);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "ยกเลิก";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AnimalTypeEditForm
            // 
            ClientSize = new Size(420, 220);
            Controls.Add(lblName);
            Controls.Add(txtTypeName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "AnimalTypeEditForm";
            Text = "Animal Type";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}