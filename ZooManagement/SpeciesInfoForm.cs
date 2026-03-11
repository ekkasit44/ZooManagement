using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class SpeciesInfoForm : Form
    {

        SqlConnection conn;



        public SpeciesInfoForm()
        {
            InitializeComponent();
        }

        private void SpeciesInfoForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        void LoadData()
        {
            conn = connectDB.ConnectZooDB();

            string sql = "SELECT * FROM speciesinfo";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
			conn = connectDB.ConnectZooDB();

			string sql = "INSERT INTO speciesinfo(name,scientific_name,conservation_status) VALUES('New Animal','Scientific Name','Status')";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.ExecuteNonQuery();

			LoadData();
		}

        private void btnEdit_Click(object sender, EventArgs e)
        {
			conn = connectDB.ConnectZooDB();

			DataGridViewRow row = dataGridView1.CurrentRow;

			string sql = @"UPDATE speciesinfo 
                           SET name=@name,
                               scientific_name=@scientific,
                               conservation_status=@status
                           WHERE species_id=@id";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("@id", row.Cells["species_id"].Value);
			cmd.Parameters.AddWithValue("@name", row.Cells["name"].Value);
			cmd.Parameters.AddWithValue("@scientific", row.Cells["scientific_name"].Value);
			cmd.Parameters.AddWithValue("@status", row.Cells["conservation_status"].Value);

			cmd.ExecuteNonQuery();

			MessageBox.Show("Edit Success");

			LoadData();
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
			conn = connectDB.ConnectZooDB();

			DataGridViewRow row = dataGridView1.CurrentRow;

			string sql = "DELETE FROM speciesinfo WHERE species_id=@id";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("@id", row.Cells["species_id"].Value);

			cmd.ExecuteNonQuery();

			MessageBox.Show("Delete Success");

			LoadData();
		}
    }
}
