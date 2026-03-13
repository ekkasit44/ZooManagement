namespace ZooManagement
{
    partial class SpeciesInfoForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvSpecies;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private void InitializeComponent()
        {
            dgvSpecies = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSpecies).BeginInit();
            SuspendLayout();
            // 
            // dgvSpecies
            // 
            dgvSpecies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSpecies.ColumnHeadersHeight = 29;
            dgvSpecies.Location = new Point(12, 100);
            dgvSpecies.Name = "dgvSpecies";
            dgvSpecies.RowHeadersWidth = 51;
            dgvSpecies.Size = new Size(776, 308);
            dgvSpecies.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(23, 50);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "เพิ่ม";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(111, 50);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 30);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "แก้ไข";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(201, 50);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "ลบ";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(231, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "ค้นหา";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(23, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 1;
            // 
            // SpeciesInfoForm
            // 
            ClientSize = new Size(800, 420);
            Controls.Add(dgvSpecies);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "SpeciesInfoForm";
            Text = "จัดการข้อมูลชนิดสัตว์";
            Load += SpeciesInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSpecies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}