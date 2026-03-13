namespace ZooManagement
{
    partial class SpeciesInfoEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox txtCommonName;
        private System.Windows.Forms.TextBox txtScientificName;
        private System.Windows.Forms.TextBox txtHabitat;
        private System.Windows.Forms.TextBox txtDiet;
        private System.Windows.Forms.TextBox txtStatus;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            this.txtCommonName = new System.Windows.Forms.TextBox();
            this.txtScientificName = new System.Windows.Forms.TextBox();
            this.txtHabitat = new System.Windows.Forms.TextBox();
            this.txtDiet = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // label1
            this.label1.Text = "ชื่อทั่วไป";
            this.label1.Location = new System.Drawing.Point(20, 20);

            // txtCommonName
            this.txtCommonName.Location = new System.Drawing.Point(150, 20);
            this.txtCommonName.Size = new System.Drawing.Size(200, 23);

            // label2
            this.label2.Text = "ชื่อวิทยาศาสตร์";
            this.label2.Location = new System.Drawing.Point(20, 60);

            // txtScientificName
            this.txtScientificName.Location = new System.Drawing.Point(150, 60);
            this.txtScientificName.Size = new System.Drawing.Size(200, 23);

            // label3
            this.label3.Text = "ถิ่นที่อยู่";
            this.label3.Location = new System.Drawing.Point(20, 100);

            // txtHabitat
            this.txtHabitat.Location = new System.Drawing.Point(150, 100);
            this.txtHabitat.Size = new System.Drawing.Size(200, 23);

            // label4
            this.label4.Text = "อาหาร";
            this.label4.Location = new System.Drawing.Point(20, 140);

            // txtDiet
            this.txtDiet.Location = new System.Drawing.Point(150, 140);
            this.txtDiet.Size = new System.Drawing.Size(200, 23);

            // label5
            this.label5.Text = "สถานะอนุรักษ์";
            this.label5.Location = new System.Drawing.Point(20, 180);

            // txtStatus
            this.txtStatus.Location = new System.Drawing.Point(150, 180);
            this.txtStatus.Size = new System.Drawing.Size(200, 23);

            // btnSave
            this.btnSave.Text = "บันทึก";
            this.btnSave.Location = new System.Drawing.Point(80, 230);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Location = new System.Drawing.Point(200, 230);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommonName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScientificName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHabitat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.Text = "เพิ่ม / แก้ไข ชนิดสัตว์";
            this.Load += new System.EventHandler(this.SpeciesInfoEditForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}