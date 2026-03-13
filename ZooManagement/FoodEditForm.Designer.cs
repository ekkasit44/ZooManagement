namespace ZooManagement
{
    partial class FoodEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblName;
        private Label lblType;
        private Label lblUnit;

        private TextBox txtName;
        private TextBox txtType;
        private TextBox txtUnit;

        private Button btnSave;
        private Button btnCancel;

        private void InitializeComponent()
        {
            lblName = new Label();
            lblType = new Label();
            lblUnit = new Label();
            txtName = new TextBox();
            txtType = new TextBox();
            txtUnit = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "ชื่ออาหาร";
            // 
            // lblType
            // 
            lblType.Location = new Point(30, 80);
            lblType.Name = "lblType";
            lblType.Size = new Size(100, 23);
            lblType.TabIndex = 2;
            lblType.Text = "ประเภท";
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(30, 130);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(100, 23);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "จำนวน";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 1;
            // 
            // txtType
            // 
            txtType.Location = new Point(130, 80);
            txtType.Name = "txtType";
            txtType.Size = new Size(200, 27);
            txtType.TabIndex = 3;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(130, 130);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(200, 27);
            txtUnit.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(90, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // FoodEditForm
            // 
            ClientSize = new Size(382, 233);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblType);
            Controls.Add(txtType);
            Controls.Add(lblUnit);
            Controls.Add(txtUnit);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FoodEditForm";
            Text = "Food";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}