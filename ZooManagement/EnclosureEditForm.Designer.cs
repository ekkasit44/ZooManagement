namespace ZooManagement
{
    partial class EnclosureEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblName = new Label();
            lblLocation = new Label();
            txtName = new TextBox();
            txtLocation = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 23);
            lblName.TabIndex = 0;
            lblName.Text = "ชื่อ";
            // 
            // lblLocation
            // 
            lblLocation.Location = new Point(30, 80);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(70, 23);
            lblLocation.TabIndex = 2;
            lblLocation.Text = "โซนที่ตั้ง";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 1;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(120, 80);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(200, 27);
            txtLocation.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(70, 140);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(83, 32);
            btnSave.TabIndex = 4;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(194, 140);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 32);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // EnclosureEditForm
            // 
            ClientSize = new Size(426, 256);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblLocation);
            Controls.Add(txtLocation);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "EnclosureEditForm";
            Text = "Enclosure";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}