namespace ZooManagement
{
    partial class FeedingScheduleForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvFeeding;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            dgvFeeding = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvAnimal = new DataGridView();
            dgvFood = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblS = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFeeding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFood).BeginInit();
            SuspendLayout();
            // 
            // dgvFeeding
            // 
            dgvFeeding.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFeeding.ColumnHeadersHeight = 29;
            dgvFeeding.Location = new Point(48, 80);
            dgvFeeding.Name = "dgvFeeding";
            dgvFeeding.RowHeadersWidth = 51;
            dgvFeeding.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeeding.Size = new Size(1271, 319);
            dgvFeeding.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "เพิ่ม";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(131, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(115, 36);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "แก้ไข";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(247, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "ลบ";
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvAnimal
            // 
            dgvAnimal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimal.ColumnHeadersHeight = 29;
            dgvAnimal.Location = new Point(149, 432);
            dgvAnimal.Name = "dgvAnimal";
            dgvAnimal.RowHeadersWidth = 51;
            dgvAnimal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimal.Size = new Size(438, 319);
            dgvAnimal.TabIndex = 4;
            // 
            // dgvFood
            // 
            dgvFood.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFood.ColumnHeadersHeight = 29;
            dgvFood.Location = new Point(747, 432);
            dgvFood.Name = "dgvFood";
            dgvFood.RowHeadersWidth = 51;
            dgvFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFood.Size = new Size(436, 319);
            dgvFood.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(511, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(305, 27);
            txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(864, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "ตกลง";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblS
            // 
            lblS.AutoSize = true;
            lblS.Location = new Point(455, 24);
            lblS.Name = "lblS";
            lblS.Size = new Size(43, 20);
            lblS.TabIndex = 8;
            lblS.Text = "ค้นหา";
            // 
            // FeedingScheduleForm
            // 
            ClientSize = new Size(1361, 817);
            Controls.Add(lblS);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvFood);
            Controls.Add(dgvAnimal);
            Controls.Add(dgvFeeding);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "FeedingScheduleForm";
            Text = "Feeding Schedule Management";
            Load += FeedingScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFeeding).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFood).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridView dgvAnimal;
        private DataGridView dgvFood;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblS;
    }
}