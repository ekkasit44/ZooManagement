using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class SpeciesInfoForm : Form
    {
        public SpeciesInfoForm()
        {
            InitializeComponent();
        }

        private void SpeciesInfoForm_Load(object sender, EventArgs e)
        {
            dgvSpecies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadSpecies();
        }

        private void LoadSpecies()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
                               species_info_id AS ID,
                               common_name AS ชื่อทั่วไป,
                               scientific_name AS ชื่อวิทยาศาสตร์,
                               habitat AS ถิ่นที่อยู่,
                               diet AS อาหาร,
                               conservation_status AS สถานะอนุรักษ์
                               FROM SpeciesInfo";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSpecies.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
                               species_info_id AS ID,
                               common_name AS ชื่อทั่วไป,
                               scientific_name AS ชื่อวิทยาศาสตร์,
                               habitat AS ถิ่นที่อยู่,
                               diet AS อาหาร,
                               conservation_status AS สถานะอนุรักษ์
                               FROM SpeciesInfo
                               WHERE common_name LIKE @name";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSpecies.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SpeciesInfoEditForm frm = new SpeciesInfoEditForm();
            frm.ShowDialog();
            LoadSpecies();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSpecies.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกรายการ");
                return;
            }

            SpeciesInfoEditForm frm = new SpeciesInfoEditForm();

            frm.SpeciesID = dgvSpecies.SelectedRows[0].Cells[0].Value.ToString();
            frm.CommonName = dgvSpecies.SelectedRows[0].Cells[1].Value.ToString();
            frm.ScientificName = dgvSpecies.SelectedRows[0].Cells[2].Value.ToString();
            frm.Habitat = dgvSpecies.SelectedRows[0].Cells[3].Value.ToString();
            frm.Diet = dgvSpecies.SelectedRows[0].Cells[4].Value.ToString();
            frm.Status = dgvSpecies.SelectedRows[0].Cells[5].Value.ToString();

            frm.ShowDialog();
            LoadSpecies();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSpecies.SelectedRows.Count == 0)
                return;

            string id = dgvSpecies.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM SpeciesInfo WHERE species_info_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadSpecies();
        }
    }
}