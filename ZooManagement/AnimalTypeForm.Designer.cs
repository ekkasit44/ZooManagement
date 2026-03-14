namespace ZooManagement
{
    partial class AnimalTypeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvAnimalType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

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
            dgvAnimalType = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvAnimalList = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalList).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimalType
            // 
            dgvAnimalType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimalType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalType.Location = new Point(12, 89);
            dgvAnimalType.Name = "dgvAnimalType";
            dgvAnimalType.RowHeadersWidth = 51;
            dgvAnimalType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimalType.Size = new Size(933, 320);
            dgvAnimalType.TabIndex = 0;
            dgvAnimalType.SelectionChanged += dgvAnimalType_SelectionChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "เพิ่ม";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(122, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 35);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "แก้ไข";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(232, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 35);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvAnimalList
            // 
            dgvAnimalList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimalList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalList.Location = new Point(32, 478);
            dgvAnimalList.Name = "dgvAnimalList";
            dgvAnimalList.RowHeadersWidth = 51;
            dgvAnimalList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimalList.Size = new Size(913, 320);
            dgvAnimalList.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(385, 27);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 5;
            label1.Text = "ค้นหา";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(471, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(271, 27);
            txtSearch.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(790, 27);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "ตกลง";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AnimalTypeForm
            // 
            ClientSize = new Size(1166, 865);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvAnimalList);
            Controls.Add(dgvAnimalType);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "AnimalTypeForm";
            Text = "Animal Type Management";
            Load += AnimalTypeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimalType).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvAnimalList;
        private Label label1;
        private TextBox txtSearch;
        private Button button1;
    }
}