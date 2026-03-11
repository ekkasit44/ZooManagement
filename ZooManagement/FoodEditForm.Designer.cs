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

            lblName.Text = "Food Name";
            lblName.Location = new System.Drawing.Point(30, 30);

            txtName.Location = new System.Drawing.Point(130, 30);
            txtName.Width = 200;

            lblType.Text = "Type";
            lblType.Location = new System.Drawing.Point(30, 80);

            txtType.Location = new System.Drawing.Point(130, 80);
            txtType.Width = 200;

            lblUnit.Text = "Unit";
            lblUnit.Location = new System.Drawing.Point(30, 130);

            txtUnit.Location = new System.Drawing.Point(130, 130);
            txtUnit.Width = 200;

            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(90, 190);
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(200, 190);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);

            this.Controls.Add(lblType);
            this.Controls.Add(txtType);

            this.Controls.Add(lblUnit);
            this.Controls.Add(txtUnit);

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            this.Text = "Food";
            this.Size = new System.Drawing.Size(400, 280);
        }
    }
}