using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ZooManagement
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // 1. เพิ่มรายชื่อหัวข้อรายงานเข้าไปใน Dropdown
            cmbReportType.Items.Add("1. สรุปจำนวนสัตว์ในแต่ละกรง (แยกตามสถานที่)");
            cmbReportType.Items.Add("2. สรุปจำนวนสัตว์แบ่งตามประเภทสัตว์");
            cmbReportType.Items.Add("3. รายชื่อสัตว์ทั้งหมด พร้อมข้อมูลกรงและผู้ดูแล");

            // ตั้งค่าเริ่มต้นให้เลือกอันแรกสุดเสมอ
            if (cmbReportType.Items.Count > 0)
                cmbReportType.SelectedIndex = 0;
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            if (cmbReportType.SelectedIndex == -1) return;

            string query = "";

            // 2. เช็คว่าผู้ใช้เลือกรายงานหัวข้อไหน แล้วตั้งค่าคำสั่ง SQL ตามนั้น
            switch (cmbReportType.SelectedIndex)
            {
                case 0: // รายงานที่ 1: สรุปจำนวนสัตว์ในแต่ละกรง
                    query = @"
                        SELECT e.name AS 'ชื่อกรง', 
                               e.location AS 'สถานที่ (โซน)', 
                               COUNT(a.animal_id) AS 'จำนวนสัตว์ (ตัว)'
                        FROM Enclosure e
                        LEFT JOIN Animal a ON e.enclosure_id = a.enclosure_id
                        GROUP BY e.name, e.location
                        ORDER BY COUNT(a.animal_id) DESC";
                    break;

                case 1: // รายงานที่ 2: สรุปจำนวนสัตว์ตามประเภท
                    query = @"
                        SELECT t.type_name AS 'ประเภทสัตว์', 
                               COUNT(a.animal_id) AS 'จำนวน (ตัว)'
                        FROM AnimalType t
                        LEFT JOIN Animal a ON t.animal_type_id = a.animal_type_id
                        GROUP BY t.type_name
                        ORDER BY COUNT(a.animal_id) DESC";
                    break;

                case 2: // รายงานที่ 3: รายชื่อสัตว์ทั้งหมดแบบละเอียด
                    query = @"
                        SELECT a.name AS 'ชื่อสัตว์', 
                               a.gender AS 'เพศ', 
                               s.common_name AS 'ชนิด', 
                               t.type_name AS 'ประเภท', 
                               e.name AS 'กรงที่อยู่', 
                               k.name AS 'ผู้ดูแลหลัก'
                        FROM Animal a
                        LEFT JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id
                        LEFT JOIN AnimalType t ON a.animal_type_id = t.animal_type_id
                        LEFT JOIN Enclosure e ON a.enclosure_id = e.enclosure_id
                        LEFT JOIN EnclosureKeeper ek ON e.enclosure_id = ek.enclosure_id
                        LEFT JOIN Keeper k ON ek.keeper_id = k.keeper_id";
                    break;
            }

            // 3. ดึงข้อมูลจากฐานข้อมูลมาแสดงผล
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดรายงาน: " + ex.Message, "Error");
            }
        }
    }
}