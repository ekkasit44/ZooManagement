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

            lblAnimal.Text = "Animal ID";
            lblAnimal.Location = new System.Drawing.Point(30, 30);

            txtAnimalID.Location = new System.Drawing.Point(150, 30);
            txtAnimalID.Width = 200;

            lblFood.Text = "Food ID";
            lblFood.Location = new System.Drawing.Point(30, 70);

            txtFoodID.Location = new System.Drawing.Point(150, 70);
            txtFoodID.Width = 200;

            lblTime.Text = "Feeding Time";
            lblTime.Location = new System.Drawing.Point(30, 110);

            txtFeedingTime.Location = new System.Drawing.Point(150, 110);
            txtFeedingTime.Width = 200;

            lblQty.Text = "Quantity";
            lblQty.Location = new System.Drawing.Point(30, 150);

            txtQuantity.Location = new System.Drawing.Point(150, 150);
            txtQuantity.Width = 200;

            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(80, 200);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(200, 200);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(lblAnimal);
            this.Controls.Add(txtAnimalID);

            this.Controls.Add(lblFood);
            this.Controls.Add(txtFoodID);

            this.Controls.Add(lblTime);
            this.Controls.Add(txtFeedingTime);

            this.Controls.Add(lblQty);
            this.Controls.Add(txtQuantity);

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.Text = "Feeding Schedule";
            this.Size = new System.Drawing.Size(420, 300);
        }
    }
}