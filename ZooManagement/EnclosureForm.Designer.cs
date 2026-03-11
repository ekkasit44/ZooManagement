namespace ZooManagement
{
    partial class EnclosureForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvEnclosure;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            this.dgvEnclosure = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.SuspendLayout();

            dgvEnclosure.Columns.Add("id", "Enclosure ID");
            dgvEnclosure.Columns.Add("name", "Name");
            dgvEnclosure.Columns.Add("location", "Location");

            dgvEnclosure.Location = new System.Drawing.Point(20, 20);
            dgvEnclosure.Size = new System.Drawing.Size(500, 250);
            dgvEnclosure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            btnAdd.Text = "Add";
            btnAdd.Location = new System.Drawing.Point(20, 290);
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            btnEdit.Text = "Edit";
            btnEdit.Location = new System.Drawing.Point(120, 290);
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(220, 290);
            btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.Controls.Add(dgvEnclosure);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);

            this.Text = "Enclosure Management";
            this.Size = new System.Drawing.Size(560, 360);

            this.ResumeLayout(false);
        }
    }
}