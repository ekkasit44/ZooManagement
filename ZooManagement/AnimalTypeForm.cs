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

        private void AnimalTypeForm_Load(object sender, EventArgs e)
        {
            LoadAnimalType();
        }

        // โหลดข้อมูลจากฐานข้อมูล
        private void LoadAnimalType()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT animal_type_id, type_name, description FROM AnimalType";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAnimalType.DataSource = dt;   // ให้ DataGridView สร้าง column เอง
            }
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

            frm.TypeID = dgvAnimalType.CurrentRow.Cells["animal_type_id"].Value.ToString();
            frm.TypeName = dgvAnimalType.CurrentRow.Cells["type_name"].Value.ToString();
            frm.Description = dgvAnimalType.CurrentRow.Cells["description"].Value.ToString();

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
    }
}