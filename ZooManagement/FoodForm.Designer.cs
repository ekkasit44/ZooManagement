namespace ZooManagement
{
    partial class FoodForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvFood;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            dgvFood = new System.Windows.Forms.DataGridView();
            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();

            dgvFood.Columns.Add("id", "Food ID");
            dgvFood.Columns.Add("name", "Name");
            dgvFood.Columns.Add("type", "Type");
            dgvFood.Columns.Add("unit", "Unit");

            dgvFood.Location = new System.Drawing.Point(20, 20);
            dgvFood.Size = new System.Drawing.Size(500, 250);
            dgvFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            btnAdd.Text = "Add";
            btnAdd.Location = new System.Drawing.Point(20, 290);
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            btnEdit.Text = "Edit";
            btnEdit.Location = new System.Drawing.Point(120, 290);
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(220, 290);
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.Controls.Add(dgvFood);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);

            this.Text = "Food Management";
            this.Size = new System.Drawing.Size(560, 360);
        }
    }
}