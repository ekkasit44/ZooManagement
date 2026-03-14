namespace ZooManagement
{
    partial class EnclosureForm
    {
        private System.ComponentModel.IContainer components = null;

        // ประกาศเครื่องมือ
        private System.Windows.Forms.DataGridView dgvEnclosures;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.DataGridView dgvFeeding;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblEnclosures;
        private System.Windows.Forms.Label lblAnimals;
        private System.Windows.Forms.Label lblFeeding;

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
            dgvEnclosures = new DataGridView();
            dgvAnimals = new DataGridView();
            dgvFeeding = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblEnclosures = new Label();
            lblAnimals = new Label();
            lblFeeding = new Label();
            lblAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEnclosures).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFeeding).BeginInit();
            SuspendLayout();
            // 
            // dgvEnclosures
            // 
            dgvEnclosures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnclosures.Location = new Point(30, 100);
            dgvEnclosures.Name = "dgvEnclosures";
            dgvEnclosures.ReadOnly = true;
            dgvEnclosures.RowHeadersWidth = 51;
            dgvEnclosures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnclosures.Size = new Size(833, 277);
            dgvEnclosures.TabIndex = 3;
            dgvEnclosures.CellClick += dgvEnclosures_CellClick;
            // 
            // dgvAnimals
            // 
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Location = new Point(30, 446);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.RowHeadersWidth = 51;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.Size = new Size(833, 272);
            dgvAnimals.TabIndex = 6;
            dgvAnimals.CellClick += dgvAnimals_CellClick;
            // 
            // dgvFeeding
            // 
            dgvFeeding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeeding.Location = new Point(901, 100);
            dgvFeeding.Name = "dgvFeeding";
            dgvFeeding.ReadOnly = true;
            dgvFeeding.RowHeadersWidth = 51;
            dgvFeeding.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeeding.Size = new Size(400, 618);
            dgvFeeding.TabIndex = 7;
            dgvFeeding.CellClick += dgvFeeding_CellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(638, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(329, 27);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1000, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 35);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "ตกลง";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(30, 21);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "เพิ่ม";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(130, 21);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 35);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "แก้ไข";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(230, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "ลบ";
            btnDelete.Click += btnDelete_Click;
            // 
            // lblEnclosures
            // 
            lblEnclosures.AutoSize = true;
            lblEnclosures.Location = new Point(30, 77);
            lblEnclosures.Name = "lblEnclosures";
            lblEnclosures.Size = new Size(74, 20);
            lblEnclosures.TabIndex = 0;
            lblEnclosures.Text = "1. เลือกกรง";
            // 
            // lblAnimals
            // 
            lblAnimals.AutoSize = true;
            lblAnimals.Location = new Point(30, 412);
            lblAnimals.Name = "lblAnimals";
            lblAnimals.Size = new Size(81, 20);
            lblAnimals.TabIndex = 1;
            lblAnimals.Text = "2. เลือกสัตว์ ";
            // 
            // lblFeeding
            // 
            lblFeeding.AutoSize = true;
            lblFeeding.Location = new Point(901, 77);
            lblFeeding.Name = "lblFeeding";
            lblFeeding.Size = new Size(109, 20);
            lblFeeding.TabIndex = 2;
            lblFeeding.Text = "3. ตารางให้อาหาร";
            // 
            // lblAll
            // 
            lblAll.Location = new Point(326, 21);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(88, 35);
            lblAll.TabIndex = 11;
            lblAll.Text = "แสดงทั้งหมด";
            lblAll.UseVisualStyleBackColor = true;
            lblAll.Click += lblAll_Click;
            // 
            // EnclosureForm
            // 
            ClientSize = new Size(1323, 762);
            Controls.Add(lblAll);
            Controls.Add(lblEnclosures);
            Controls.Add(lblAnimals);
            Controls.Add(lblFeeding);
            Controls.Add(dgvEnclosures);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dgvAnimals);
            Controls.Add(dgvFeeding);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "EnclosureForm";
            Text = "จัดการข้อมูลกรงและตารางให้อาหาร";
            Load += EnclosureForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEnclosures).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFeeding).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button lblAll;
    }
}