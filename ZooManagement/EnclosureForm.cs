using Microsoft.Data.SqlClient; // ใช้ Namespace ตามโค้ดของคุณ
using System;
using System.Data;
using System.Windows.Forms;

namespace ZooManagement
{
    public partial class EnclosureForm : Form
    {
        // ตัวแปรเก็บข้อมูลกรงที่ถูกเลือก
        private string selectedEnclosureId = "";
        private string selectedEnclosureName = "";
        private string selectedEnclosureLocation = "";

        // ตัวแปรเก็บ ID อื่นๆ
        private string selectedAnimalId = "";


        public EnclosureForm()
        {
            InitializeComponent();
        }

        private void EnclosureForm_Load(object sender, EventArgs e)
        {
            LoadEnclosures();
        }

        // --- 1. โหลดข้อมูลกรงทั้งหมด ---
        private void LoadEnclosures()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                // ดึงข้อมูลกรงพร้อมจำนวนสัตว์ในแต่ละกรง
                string query = @"SELECT e.enclosure_id, e.name, e.location, COUNT(a.animal_id) AS animal_count
                                 FROM Enclosure e
                                 LEFT JOIN Animal a ON e.enclosure_id = a.enclosure_id
                                 GROUP BY e.enclosure_id, e.name, e.location";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEnclosures.DataSource = dt;
                SetEnclosureGridHeaders();
            }
        }

        // --- 2. คลิกกรง -> เก็บข้อมูลกรงเพื่อรอส่งไปหน้า Edit และแสดงสัตว์ ---
        private void dgvEnclosures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEnclosures.Rows[e.RowIndex];

                // เก็บข้อมูลกรงไว้ใช้ตอนกดปุ่มแก้ไข
                selectedEnclosureId = row.Cells["enclosure_id"].Value.ToString();
                selectedEnclosureName = row.Cells["name"].Value.ToString();
                selectedEnclosureLocation = row.Cells["location"].Value.ToString();

                // โหลดสัตว์ และล้างตารางอาหารเพราะเพิ่งเปลี่ยนกรง
                LoadAnimalsByEnclosure(selectedEnclosureId);
                selectedAnimalId = "";

            }
        }

        private void LoadAnimalsByEnclosure(string enclosureId, string searchTerm = "")
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string query = "SELECT animal_id, name, gender FROM Animal WHERE enclosure_id = @enclosureId";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND name LIKE @searchTerm";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@enclosureId", enclosureId);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAnimals.DataSource = dt;
                SetAnimalGridHeaders();
            }
        }

        // --- 3. คลิกสัตว์ -> แสดงตารางให้อาหาร ---
        private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedAnimalId = dgvAnimals.Rows[e.RowIndex].Cells["animal_id"].Value.ToString();
            }
        }

        // --- 4. ปุ่มค้นหาสัตว์ ---
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedEnclosureId))
            {
                MessageBox.Show("กรุณาเลือกกรงก่อนทำการค้นหาสัตว์", "แจ้งเตือน");
                return;
            }
            LoadAnimalsByEnclosure(selectedEnclosureId, txtSearch.Text);
        }

        // --- 5. ปุ่ม เพิ่ม/แก้ไข/ลบ ข้อมูล "กรง (Enclosure)" ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // สร้างออบเจกต์ฟอร์มของคุณ
            EnclosureEditForm frm = new EnclosureEditForm();

            // ไม่ต้องใส่ ID เพราะเป็นการเพิ่มใหม่ (ID ปล่อยเป็นค่าว่างตามเงื่อนไข if ของคุณ)
            frm.EnclosureID = "";
            frm.Name = "";
            frm.LocationName = "";

            // เปิดหน้าต่าง
            frm.ShowDialog();

            // โหลดตารางกรงใหม่หลังจากปิดหน้าต่างแก้ไข
            LoadEnclosures();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedEnclosureId))
            {
                MessageBox.Show("กรุณาเลือกกรงที่ต้องการแก้ไขจากตารางฝั่งซ้าย", "แจ้งเตือน");
                return;
            }

            EnclosureEditForm frm = new EnclosureEditForm();

            // ส่งค่า ID, ชื่อ, สถานที่ ของกรงที่เลือกลงไปในตัวแปรของฟอร์ม
            frm.EnclosureID = selectedEnclosureId;
            frm.Name = selectedEnclosureName;
            frm.LocationName = selectedEnclosureLocation;

            frm.ShowDialog();
            LoadEnclosures(); // อัปเดตตาราง
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedEnclosureId))
            {
                MessageBox.Show("กรุณาเลือกกรงที่ต้องการลบ", "แจ้งเตือน");
                return;
            }

            if (MessageBox.Show("คุณแน่ใจหรือไม่ที่จะลบกรงนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    // ลบข้อมูลกรงจากฐานข้อมูล
                    string query = "DELETE FROM Enclosure WHERE enclosure_id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedEnclosureId);

                    cmd.ExecuteNonQuery();
                }

                LoadEnclosures(); // อัปเดตตารางกรง
                dgvAnimals.DataSource = null; // ล้างตารางสัตว์
                selectedEnclosureId = "";
            }
        }

        // --- 6. ปุ่ม แสดงทั้งหมด (lblAll) ---
        private void lblAll_Click(object sender, EventArgs e)
        {
            // โหลดข้อมูลทั้งหมดในทั้ง 3 ตาราง
            LoadEnclosures();
            LoadAllAnimals();

            // เคลียร์ตัวแปรเลือกไว้เพื่อหลีกเลี่ยงการกระทำผิดพลาด
            selectedEnclosureId = "";
            selectedEnclosureName = "";
            selectedEnclosureLocation = "";
            selectedAnimalId = "";
        }

        private void LoadAllAnimals(string searchTerm = "")
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string query = "SELECT animal_id, name, gender, enclosure_id FROM Animal";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE name LIKE @searchTerm";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAnimals.DataSource = dt;
                SetAnimalGridHeaders();
            }
        }

        private void LoadAllFeeding(string searchTerm = "")
        {
            // dgvFeeding removed - no implementation
        }

        // --- Helpers: ตั้งหัวคอลัมน์เป็นภาษาไทย ---
        private void SetEnclosureGridHeaders()
        {
            if (dgvEnclosures.Columns == null) return;
            if (dgvEnclosures.Columns.Contains("enclosure_id")) dgvEnclosures.Columns["enclosure_id"].HeaderText = "รหัสกรง";
            if (dgvEnclosures.Columns.Contains("name")) dgvEnclosures.Columns["name"].HeaderText = "ชื่อกรง";
            if (dgvEnclosures.Columns.Contains("location")) dgvEnclosures.Columns["location"].HeaderText = "สถานที่";
            if (dgvEnclosures.Columns.Contains("animal_count")) dgvEnclosures.Columns["animal_count"].HeaderText = "จำนวนสัตว์";
        }

        private void SetAnimalGridHeaders()
        {
            if (dgvAnimals.Columns == null) return;
            if (dgvAnimals.Columns.Contains("animal_id")) dgvAnimals.Columns["animal_id"].HeaderText = "รหัสสัตว์";
            if (dgvAnimals.Columns.Contains("name")) dgvAnimals.Columns["name"].HeaderText = "ชื่อสัตว์";
            if (dgvAnimals.Columns.Contains("gender")) dgvAnimals.Columns["gender"].HeaderText = "เพศ";
            if (dgvAnimals.Columns.Contains("enclosure_id")) dgvAnimals.Columns["enclosure_id"].HeaderText = "รหัสกรง";
        }

        // Feeding grid removed - no header helper
    }
}