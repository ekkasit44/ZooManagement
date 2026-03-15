namespace ZooManagement
{
    partial class KeeperForm
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
            comboKeeper = new ComboBox();
            comboEnclosure = new ComboBox();
            btnApply = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(175, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1029, 417);
            dataGridView1.TabIndex = 0;
            // 
            // comboKeeper
            // 
            comboKeeper.FormattingEnabled = true;
            comboKeeper.Location = new Point(48, 494);
            comboKeeper.Name = "comboKeeper";
            comboKeeper.Size = new Size(270, 28);
            comboKeeper.TabIndex = 1;
            // 
            // comboEnclosure
            // 
            comboEnclosure.FormattingEnabled = true;
            comboEnclosure.Location = new Point(380, 494);
            comboEnclosure.Name = "comboEnclosure";
            comboEnclosure.Size = new Size(244, 28);
            comboEnclosure.TabIndex = 2;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(716, 494);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(94, 29);
            btnApply.TabIndex = 3;
            btnApply.Text = "ค้นหา";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(873, 494);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "เคลียร์";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // KeeperForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 675);
            Controls.Add(btnClear);
            Controls.Add(btnApply);
            Controls.Add(comboEnclosure);
            Controls.Add(comboKeeper);
            Controls.Add(dataGridView1);
            Name = "KeeperForm";
            Text = "KeeperForm";
            Load += KeeperForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboKeeper;
        private ComboBox comboEnclosure;
        private Button btnApply;
        private Button btnClear;
    }
}
