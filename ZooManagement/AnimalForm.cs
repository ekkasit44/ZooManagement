using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using ZooManagement;

namespace ZooManagement
{
    public partial class AnimalForm : Form
    {
        public AnimalForm()
        {
            InitializeComponent();
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            LoadAnimal();
        }

        // โหลดข้อมูลสัตว์
        private void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT * FROM Animal";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAnimal.DataSource = dt;
            }
        }

        // Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnimal();
        }

        // Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnimalEditForm f = new AnimalEditForm();
            f.ShowDialog();

            LoadAnimal();
        }

        // Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAnimal.CurrentRow == null) return;

            int id = Convert.ToInt32(
                dgvAnimal.CurrentRow.Cells["animal_id"].Value);

            AnimalEditForm f = new AnimalEditForm(id);
            f.ShowDialog();

            LoadAnimal();
        }

        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimal.CurrentRow == null) return;

            int id = Convert.ToInt32(
                dgvAnimal.CurrentRow.Cells["animal_id"].Value);

            DialogResult result = MessageBox.Show(
                "Delete this animal?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "DELETE FROM Animal WHERE animal_id=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                LoadAnimal();
            }
        }
    }
}