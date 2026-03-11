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
            btnAllAnimals = new Button();
            btnZoneAnimals = new Button();
            btnFeed = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAllAnimals
            // 
            btnAllAnimals.Location = new Point(54, 59);
            btnAllAnimals.Name = "btnAllAnimals";
            btnAllAnimals.Size = new Size(205, 101);
            btnAllAnimals.TabIndex = 0;
            btnAllAnimals.Text = "รายงานสัตว์ทั้งหมด";
            btnAllAnimals.UseVisualStyleBackColor = true;
            btnAllAnimals.Click += btnAllAnimals_Click;
            // 
            // btnZoneAnimals
            // 
            btnZoneAnimals.Location = new Point(54, 209);
            btnZoneAnimals.Name = "btnZoneAnimals";
            btnZoneAnimals.Size = new Size(205, 101);
            btnZoneAnimals.TabIndex = 1;
            btnZoneAnimals.Text = "รายงานสัตว์แยกตามโซน";
            btnZoneAnimals.UseVisualStyleBackColor = true;
            btnZoneAnimals.Click += btnZoneAnimals_Click;
            // 
            // btnFeed
            // 
            btnFeed.Location = new Point(54, 366);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new Size(205, 101);
            btnFeed.TabIndex = 2;
            btnFeed.Text = "รายงานการให้อาหารรายวัน";
            btnFeed.UseVisualStyleBackColor = true;
            btnFeed.Click += btnFeed_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(336, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(871, 408);
            dataGridView1.TabIndex = 3;
            // 
            // SpeciesInfoEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 702);
            Controls.Add(dataGridView1);
            Controls.Add(btnFeed);
            Controls.Add(btnZoneAnimals);
            Controls.Add(btnAllAnimals);
            Name = "SpeciesInfoEditForm";
            Text = "SpeciesInfoEditForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAllAnimals;
        private Button btnZoneAnimals;
        private Button btnFeed;
        private DataGridView dataGridView1;
    }
}
