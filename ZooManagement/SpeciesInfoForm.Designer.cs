namespace ZooManagement
{
    partial class SpeciesInfoForm
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
            comboSpecies = new ComboBox();
            comboType = new ComboBox();
            btnApply = new Button();
            btnClear = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(86, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1056, 458);
            dataGridView1.TabIndex = 0;
            // 
            // comboSpecies
            // 
            comboSpecies.FormattingEnabled = true;
            comboSpecies.Location = new Point(86, 536);
            comboSpecies.Name = "comboSpecies";
            comboSpecies.Size = new Size(197, 28);
            comboSpecies.TabIndex = 1;
            // 
            // comboType
            // 
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(341, 536);
            comboType.Name = "comboType";
            comboType.Size = new Size(198, 28);
            comboType.TabIndex = 2;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(596, 536);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(94, 29);
            btnApply.TabIndex = 3;
            btnApply.Text = "ค้นหา";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(741, 536);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(103, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "เคลียร์";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // button1
            // 
            button1.Location = new Point(873, 535);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "เเก้ไข";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SpeciesInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 684);
            Controls.Add(button1);
            Controls.Add(btnClear);
            Controls.Add(btnApply);
            Controls.Add(comboType);
            Controls.Add(comboSpecies);
            Controls.Add(dataGridView1);
            Name = "SpeciesInfoForm";
            Text = "SpeciesInfoForm";
            Load += SpeciesInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboSpecies;
        private ComboBox comboType;
        private Button btnApply;
        private Button btnClear;
        private Button button1;
    }
}
