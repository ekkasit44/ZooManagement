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
            ((System.ComponentModel.ISupportInitialize)dgvAnimalType).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimalType
            // 
            dgvAnimalType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimalType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalType.Location = new Point(12, 83);
            dgvAnimalType.Name = "dgvAnimalType";
            dgvAnimalType.RowHeadersWidth = 51;
            dgvAnimalType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimalType.Size = new Size(576, 361);
            dgvAnimalType.TabIndex = 0;
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
            // AnimalTypeForm
            // 
            ClientSize = new Size(600, 456);
            Controls.Add(dgvAnimalType);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "AnimalTypeForm";
            Text = "Animal Type Management";
            Load += AnimalTypeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimalType).EndInit();
            ResumeLayout(false);
        }
    }
}