namespace ZooManagement
{
    partial class AnimalForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvAnimal;
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
            dgvAnimal = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label1 = new Label();
            txtSearchAnimal = new TextBox();
            label2 = new Label();
            btnSearchAnimal = new Button();
            dgvKeeper = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeeper).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimal
            // 
            dgvAnimal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimal.Location = new Point(20, 84);
            dgvAnimal.Name = "dgvAnimal";
            dgvAnimal.RowHeadersWidth = 51;
            dgvAnimal.Size = new Size(914, 321);
            dgvAnimal.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "เพิ่ม";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(120, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 30);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "แก้ไข";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(220, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(355, 25);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 4;
            label1.Text = "ค้นหา";
            // 
            // txtSearchAnimal
            // 
            txtSearchAnimal.Location = new Point(404, 23);
            txtSearchAnimal.Name = "txtSearchAnimal";
            txtSearchAnimal.Size = new Size(183, 27);
            txtSearchAnimal.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 215);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 6;
            // 
            // btnSearchAnimal
            // 
            btnSearchAnimal.Location = new Point(623, 22);
            btnSearchAnimal.Name = "btnSearchAnimal";
            btnSearchAnimal.Size = new Size(94, 29);
            btnSearchAnimal.TabIndex = 7;
            btnSearchAnimal.Text = "ตกลง";
            btnSearchAnimal.UseVisualStyleBackColor = true;
            btnSearchAnimal.Click += btnSearchAnimal_Click;
            // 
            // dgvKeeper
            // 
            dgvKeeper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeeper.Location = new Point(30, 482);
            dgvKeeper.Name = "dgvKeeper";
            dgvKeeper.RowHeadersWidth = 51;
            dgvKeeper.Size = new Size(914, 332);
            dgvKeeper.TabIndex = 8;
            // 
            // AnimalForm
            // 
            ClientSize = new Size(1045, 850);
            Controls.Add(dgvKeeper);
            Controls.Add(btnSearchAnimal);
            Controls.Add(label2);
            Controls.Add(txtSearchAnimal);
            Controls.Add(label1);
            Controls.Add(dgvAnimal);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "AnimalForm";
            Text = "Animal Management";
            Load += AnimalForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeeper).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtSearchAnimal;
        private Label label2;
        private Button btnSearchAnimal;
        private DataGridView dgvKeeper;
    }
}