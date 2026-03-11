namespace ZooManagement
{
    partial class KeeperEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            txtName = new TextBox();
            txtPhone = new TextBox();
            numericCapacity = new NumericUpDown();
            comboPosition = new ComboBox();
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnOK = new Button();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // txtName
            // 
            txtName.Location = new Point(109, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(245, 27);
            txtName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(109, 132);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(245, 27);
            txtPhone.TabIndex = 1;
            // 
            // numericCapacity
            // 
            numericCapacity.Location = new Point(955, 55);
            numericCapacity.Name = "numericCapacity";
            numericCapacity.Size = new Size(211, 27);
            numericCapacity.TabIndex = 2;
            // 
            // comboPosition
            // 
            comboPosition.FormattingEnabled = true;
            comboPosition.Location = new Point(508, 55);
            comboPosition.Name = "comboPosition";
            comboPosition.Size = new Size(151, 28);
            comboPosition.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(63, 243);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(773, 410);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1081, 290);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "เพิ่ม";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1081, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1081, 461);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "เเกไข้";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(1081, 547);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 8;
            btnOK.Text = "ตกลง";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(109, 188);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(245, 27);
            txtEmail.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 54);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 10;
            label1.Text = "ชื่อเจ้าหน้าที่";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 139);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 11;
            label2.Text = "เบอร์โทรศัพท์";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 191);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 12;
            label3.Text = "อีเมล์";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(445, 58);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 13;
            label4.Text = "ตำเเหน่ง";
            // 
            // KeeperEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 706);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(btnOK);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(comboPosition);
            Controls.Add(numericCapacity);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Name = "KeeperEditForm";
            Text = "KeeperEditForm";
            Load += KeeperEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private TextBox txtName;
        private TextBox txtPhone;
        private NumericUpDown numericCapacity;
        private ComboBox comboPosition;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnOK;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
