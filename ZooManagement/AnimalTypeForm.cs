using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class AnimalTypeForm : Form
    {
        public AnimalTypeForm()
        {
            InitializeComponent();
            this.Load += AnimalTypeForm_Load;
        }
        DataTable dtAnimalType = new DataTable();

        private void AnimalTypeForm_Load(object sender, EventArgs e)
        {
            LoadAnimalType();

            if (dgvAnimalType.Rows.Count > 0)
            {
                int typeID = Convert.ToInt32(
                    dgvAnimalType.Rows[0].Cells["รหัสประเภท"].Value
                );

                LoadAnimalByType(typeID);
            }
        }

        // โหลดข้อมูลจากฐานข้อมูล
        public void LoadAnimalType()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"
            SELECT 
                at.animal_type_id AS รหัสประเภท,
                at.type_name AS ประเภทสัตว์,
                at.description AS รายละเอียด,
                COUNT(a.animal_id) AS จำนวนสัตว์
            FROM AnimalType at
            LEFT JOIN Animal a ON at.animal_type_id = a.animal_type_id
            GROUP BY at.animal_type_id, at.type_name, at.description";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAnimalType.DataSource = dt;
            }
        }



        public void LoadAnimalByType(int typeId)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"
            SELECT 
                a.name AS ชื่อสัตว์,
                s.common_name AS ชนิด,
                e.name AS กรง
            FROM Animal a
            LEFT JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id
            LEFT JOIN Enclosure e ON a.enclosure_id = e.enclosure_id
            WHERE a.animal_type_id = @tid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tid", typeId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAnimalList.DataSource = dt;
            }
        }


        private void dgvAnimalType_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAnimalType.SelectedRows.Count == 0)
                return;

            int typeID = Convert.ToInt32(
                dgvAnimalType.SelectedRows[0].Cells["รหัสประเภท"].Value
            );

            LoadAnimalByType(typeID);
        }

        // ปุ่มเพิ่ม
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnimalTypeEditForm frm = new AnimalTypeEditForm();
            frm.ShowDialog();

            LoadAnimalType();
        }

        // ปุ่มแก้ไข
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAnimalType.CurrentRow == null)
            {
                MessageBox.Show("Please select a row");
                return;
            }

            AnimalTypeEditForm frm = new AnimalTypeEditForm();

            frm.TypeID = dgvAnimalType.CurrentRow.Cells["รหัสประเภท"].Value.ToString();
            frm.TypeName = dgvAnimalType.CurrentRow.Cells["ประเภทสัตว์"].Value.ToString();
            frm.Description = dgvAnimalType.CurrentRow.Cells["รายละเอียด"].Value.ToString();

            frm.ShowDialog();

            LoadAnimalType();
        }

        // ปุ่มลบ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimalType.CurrentRow == null)
            {
                MessageBox.Show("Please select a row");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete this record?",
                "Confirm",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.No)
                return;

            string id = dgvAnimalType.CurrentRow.Cells["animal_type_id"].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM AnimalType WHERE TypeID=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }

            LoadAnimalType();
        }
        private void SearchAnimalType()
        {
            string keyword = txtSearch.Text.Trim();

            DataView dv = new DataView(dtAnimalType);

            dv.RowFilter =
    $"CONVERT([รหัสประเภท], 'System.String') LIKE '%{keyword}%' OR " +
    $"CONVERT([จำนวนสัตว์], 'System.String') LIKE '%{keyword}%' OR " +
    $"[ประเภทสัตว์] LIKE '%{keyword}%' OR " +
    $"[รายละเอียด] LIKE '%{keyword}%'";


            dgvAnimalType.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SearchAnimalType();
    
        }
    }

    
}