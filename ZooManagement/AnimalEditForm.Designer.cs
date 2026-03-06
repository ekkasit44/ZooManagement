namespace ZooManagement
{
    partial class AnimalEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.DateTimePicker dtBirth;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.dtBirth = new System.Windows.Forms.DateTimePicker();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // label1
            this.label1.Text = "Animal Name";
            this.label1.Location = new System.Drawing.Point(30, 30);

            // txtName
            this.txtName.Location = new System.Drawing.Point(150, 30);
            this.txtName.Size = new System.Drawing.Size(200, 22);

            // label2
            this.label2.Text = "Gender";
            this.label2.Location = new System.Drawing.Point(30, 70);

            // cbGender
            this.cbGender.Location = new System.Drawing.Point(150, 70);
            this.cbGender.Items.AddRange(new object[] { "Male", "Female" });

            // label3
            this.label3.Text = "Birth Date";
            this.label3.Location = new System.Drawing.Point(30, 110);

            // dtBirth
            this.dtBirth.Location = new System.Drawing.Point(150, 110);

            // btnSave
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(150, 160);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(250, 160);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AnimalEditForm
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtBirth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.Text = "Edit Animal";
            this.Load += new System.EventHandler(this.AnimalEditForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}