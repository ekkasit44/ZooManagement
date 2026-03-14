namespace ZooManagement
{
    partial class FeedingScheduleEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblAnimal;
        private Label lblFood;
        private Label lblTime;
        private Label lblQty;

        private TextBox txtAnimalID;
        private TextBox txtFoodID;
        private TextBox txtFeedingTime;
        private TextBox txtQuantity;
        private Label lblKeeper;
        private ComboBox cmbKeeper;

        private Button btnSave;
        private Button btnCancel;

        private void InitializeComponent()
        {
            lblAnimal = new Label();
            lblFood = new Label();
            lblTime = new Label();
            lblQty = new Label();
            txtAnimalID = new TextBox();
            txtFoodID = new TextBox();
            txtFeedingTime = new TextBox();
            txtQuantity = new TextBox();
            lblKeeper = new Label();
            cmbKeeper = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblAnimal
            // 
            lblAnimal.Location = new Point(30, 30);
            lblAnimal.Name = "lblAnimal";
            lblAnimal.Size = new Size(100, 23);
            lblAnimal.TabIndex = 0;
            lblAnimal.Text = "รหัสสัตว์";
            // 
            // lblFood
            // 
            lblFood.Location = new Point(30, 70);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(100, 23);
            lblFood.TabIndex = 2;
            lblFood.Text = "รหัสอาหาร";
            // 
            // lblTime
            // 
            lblTime.Location = new Point(30, 110);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(100, 23);
            lblTime.TabIndex = 4;
            lblTime.Text = "เวลาให้อาหาร";
            // 
            // lblQty
            // 
            lblQty.Location = new Point(30, 150);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(100, 23);
            lblQty.TabIndex = 6;
            lblQty.Text = "ปริมาณ";
            // 
            // txtAnimalID
            // 
            txtAnimalID.Location = new Point(150, 30);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(200, 27);
            txtAnimalID.TabIndex = 1;
            // 
            // txtFoodID
            // 
            txtFoodID.Location = new Point(150, 70);
            txtFoodID.Name = "txtFoodID";
            txtFoodID.Size = new Size(200, 27);
            txtFoodID.TabIndex = 3;
            // 
            // txtFeedingTime
            // 
            txtFeedingTime.Location = new Point(150, 110);
            txtFeedingTime.Name = "txtFeedingTime";
            txtFeedingTime.Size = new Size(200, 27);
            txtFeedingTime.TabIndex = 5;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(150, 150);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 27);
            txtQuantity.TabIndex = 7;
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
            cmbKeeper.Size = new Size(200, 28);
            cmbKeeper.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(111, 262);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 37);
            btnSave.TabIndex = 8;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(229, 262);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(92, 37);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // FeedingScheduleEditForm
            // 
            ClientSize = new Size(445, 318);
            Controls.Add(lblAnimal);
            Controls.Add(txtAnimalID);
            Controls.Add(lblFood);
            Controls.Add(txtFoodID);
            Controls.Add(lblTime);
            Controls.Add(txtFeedingTime);
            Controls.Add(lblQty);
            Controls.Add(txtQuantity);
            Controls.Add(lblKeeper);
            Controls.Add(cmbKeeper);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FeedingScheduleEditForm";
            Text = "Feeding Schedule";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}