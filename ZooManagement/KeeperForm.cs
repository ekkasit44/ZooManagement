using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ZooManagement
{
    public partial class KeeperForm : Form
    {


        SqlConnection conn;

        public KeeperForm()
        {
            InitializeComponent();
        }

        private void KeeperForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            conn = connectDB.ConnectZooDB();

            string sql = "SELECT * FROM keeper";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn = connectDB.ConnectZooDB();

            string sql = "INSERT INTO keeper(name,phone,email) VALUES('New Name','000000000','email@test.com')";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            conn = connectDB.ConnectZooDB();

            DataGridViewRow row = dataGridView1.CurrentRow;

            string sql = @"UPDATE keeper 
                           SET name=@name,
                               phone=@phone,
                               email=@email
                           WHERE keeper_id=@id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", row.Cells["keeper_id"].Value);
            cmd.Parameters.AddWithValue("@name", row.Cells["name"].Value);
            cmd.Parameters.AddWithValue("@phone", row.Cells["phone"].Value);
            cmd.Parameters.AddWithValue("@email", row.Cells["email"].Value);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Edit Success");

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
			conn = connectDB.ConnectZooDB();

			DataGridViewRow row = dataGridView1.CurrentRow;

			string sql = "DELETE FROM keeper WHERE keeper_id=@id";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("@id", row.Cells["keeper_id"].Value);

			cmd.ExecuteNonQuery();

			MessageBox.Show("Delete Success");

			LoadData();
		}
    }
}

