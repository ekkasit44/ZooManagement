namespace ZooManagement
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        // ประกาศเครื่องมือต่างๆ
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSelectReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.DataGridView dgvReport;

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
            lblHeader = new Label();
            lblSelectReport = new Label();
            cmbReportType = new ComboBox();
            btnLoadReport = new Button();
            dgvReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.Location = new Point(20, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(374, 37);
            lblHeader.TabIndex = 4;
            lblHeader.Text = "รายงานสรุปผล (Zoo Reports)";
            // 
            // lblSelectReport
            // 
            lblSelectReport.AutoSize = true;
            lblSelectReport.Location = new Point(25, 75);
            lblSelectReport.Name = "lblSelectReport";
            lblSelectReport.Size = new Size(126, 20);
            lblSelectReport.TabIndex = 3;
            lblSelectReport.Text = "เลือกประเภทรายงาน:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(150, 72);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(300, 28);
            cmbReportType.TabIndex = 2;
            // 
            // btnLoadReport
            // 
            btnLoadReport.Location = new Point(470, 70);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Size = new Size(100, 28);
            btnLoadReport.TabIndex = 1;
            btnLoadReport.Text = "ดูรายงาน";
            btnLoadReport.Click += btnLoadReport_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(25, 120);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(1326, 662);
            dgvReport.TabIndex = 0;
            // 
            // ReportForm
            // 
            ClientSize = new Size(1363, 839);
            Controls.Add(dgvReport);
            Controls.Add(btnLoadReport);
            Controls.Add(cmbReportType);
            Controls.Add(lblSelectReport);
            Controls.Add(lblHeader);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "รายงานทั้งหมด (Reports)";
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}