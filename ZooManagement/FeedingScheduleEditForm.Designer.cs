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
            // btnSave
            // 
            btnSave.Location = new Point(80, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "บันทึก";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "ยกเลิก";
            btnCancel.Click += btnCancel_Click;
            // 
            // FeedingScheduleEditForm
            // 
            ClientSize = new Size(402, 253);
            Controls.Add(lblAnimal);
            Controls.Add(txtAnimalID);
            Controls.Add(lblFood);
            Controls.Add(txtFoodID);
            Controls.Add(lblTime);
            Controls.Add(txtFeedingTime);
            Controls.Add(lblQty);
            Controls.Add(txtQuantity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FeedingScheduleEditForm";
            Text = "Feeding Schedule";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}