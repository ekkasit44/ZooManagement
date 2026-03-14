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
        DataTable dtAnimal = new DataTable();
        DataTable dtKeeper = new DataTable();
        private void AnimalForm_Load(object sender, EventArgs e)
        {
            LoadAnimal();
            LoadKeeper();
            dgvAnimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        // โหลดข้อมูลสัตว์
        private void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
        a.animal_id AS รหัสสัตว์,
        a.name AS ชื่อสัตว์,
        s.common_name AS ชนิด,
        e.name AS กรง,
        k.name AS ผู้ดูแล,
        birth_date AS วันเกิด

        FROM Animal a

        JOIN SpeciesInfo s 
        ON a.species_info_id = s.species_info_id

        JOIN Enclosure e 
        ON a.enclosure_id = e.enclosure_id

        LEFT JOIN EnclosureKeeper ek
        ON e.enclosure_id = ek.enclosure_id

        LEFT JOIN Keeper k
        ON ek.keeper_id = k.keeper_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtAnimal.Clear();
                da.Fill(dtAnimal);

                dgvAnimal.DataSource = dtAnimal;
            }
        }



        private void LoadKeeper()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
        a.name AS ชื่อสัตว์,
        k.name AS ผู้ดูแล,
        k.phone AS เบอร์โทร
        FROM Animal a
        JOIN Enclosure e ON a.enclosure_id = e.enclosure_id
        JOIN EnclosureKeeper ek ON e.enclosure_id = ek.enclosure_id
        JOIN Keeper k ON ek.keeper_id = k.keeper_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtKeeper.Clear();
                da.Fill(dtKeeper);

                dgvKeeper.DataSource = dtKeeper;
            }
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
                dgvAnimal.CurrentRow.Cells["รหัสสัตว์"].Value);

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

        private void btnSearchAnimal_Click(object sender, EventArgs e)
        {
            SearchData(); 
        }

        private void SearchData()
        {
            string keyword = txtSearchAnimal.Text.Trim();

            DataView dvAnimal = new DataView(dtAnimal);
            dvAnimal.RowFilter = $"ชื่อสัตว์ LIKE '%{keyword}%' " +
                                 $"OR ชนิด LIKE '%{keyword}%'" +
                                 $"OR กรง LIKE '%{keyword}%'" +
                                 $"OR ผู้ดูแล LIKE '%{keyword}%'";
            dgvAnimal.DataSource = dvAnimal;

            DataView dvKeeper = new DataView(dtKeeper);
            dvKeeper.RowFilter = $"ชื่อสัตว์ LIKE '%{keyword}%'" +
                                 $"OR ผู้ดูแล LIKE '%{keyword}%'" +
                                 $"OR เบอร์โทร LIKE '%{keyword}%'";
            dgvKeeper.DataSource = dvKeeper;
        }
    }
}