namespace ZooManagement
{
    partial class SpeciesInfoEditForm
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
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            txtID = new TextBox();
            txtCommonName = new TextBox();
            txtScientific = new TextBox();
            txtHabitat = new TextBox();
            txtDiet = new TextBox();
            txtStatus = new TextBox();
            txtDescription = new TextBox();
            btnClear = new Button();
            id = new Label();
            xvx = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(465, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(810, 471);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(516, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "เพิ่ม ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(657, 25);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(794, 25);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "เเก้ไข";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(170, 96);
            txtID.Name = "txtID";
            txtID.Size = new Size(206, 27);
            txtID.TabIndex = 7;
            // 
            // txtCommonName
            // 
            txtCommonName.Location = new Point(170, 150);
            txtCommonName.Name = "txtCommonName";
            txtCommonName.Size = new Size(243, 27);
            txtCommonName.TabIndex = 8;
            // 
            // txtScientific
            // 
            txtScientific.Location = new Point(170, 199);
            txtScientific.Name = "txtScientific";
            txtScientific.Size = new Size(243, 27);
            txtScientific.TabIndex = 9;
            // 
            // txtHabitat
            // 
            txtHabitat.Location = new Point(170, 253);
            txtHabitat.Name = "txtHabitat";
            txtHabitat.Size = new Size(243, 27);
            txtHabitat.TabIndex = 10;
            // 
            // txtDiet
            // 
            txtDiet.Location = new Point(170, 311);
            txtDiet.Name = "txtDiet";
            txtDiet.Size = new Size(243, 27);
            txtDiet.TabIndex = 11;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(170, 365);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(243, 27);
            txtStatus.TabIndex = 12;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(170, 419);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(243, 27);
            txtDescription.TabIndex = 13;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(920, 25);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 14;
            btnClear.Text = "เคลียร์";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(69, 99);
            id.Name = "id";
            id.Size = new Size(32, 20);
            id.TabIndex = 15;
            id.Text = "รหัส";
            // 
            // xvx
            // 
            xvx.AutoSize = true;
            xvx.Location = new Point(51, 150);
            xvx.Name = "xvx";
            xvx.Size = new Size(61, 20);
            xvx.TabIndex = 16;
            xvx.Text = "ชื่อสามัญ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 199);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 17;
            label2.Text = "ชื่อวิทยาศาสตร์";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 260);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 18;
            label3.Text = "ถิ่นอาศัย";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 318);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 19;
            label4.Text = "อาหาร";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 372);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 20;
            label5.Text = "สถานะการอนุรักษ์";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 426);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 21;
            label6.Text = "รายละเอียด";
            // 
            // button1
            // 
            button1.Location = new Point(51, 494);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 22;
            button1.Text = "เทส";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // SpeciesInfoEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 702);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(xvx);
            Controls.Add(id);
            Controls.Add(btnClear);
            Controls.Add(txtDescription);
            Controls.Add(txtStatus);
            Controls.Add(txtDiet);
            Controls.Add(txtHabitat);
            Controls.Add(txtScientific);
            Controls.Add(txtCommonName);
            Controls.Add(txtID);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Name = "SpeciesInfoEditForm";
            Text = "SpeciesInfoEditForm";
            Load += SpeciesInfoEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox txtID;
        private TextBox txtCommonName;
        private TextBox txtScientific;
        private TextBox txtHabitat;
        private TextBox txtDiet;
        private TextBox txtStatus;
        private TextBox txtDescription;
        private Button btnClear;
        private Label id;
        private Label xvx;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}
