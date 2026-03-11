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
        public KeeperForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectDB.ConnectZooDB();

            string sql = "SELECT * FROM keeper";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
			SqlConnection conn = connectDB.ConnectZooDB();

			string sql = "SELECT * FROM keeper WHERE name LIKE @name";

			SqlDataAdapter da = new SqlDataAdapter(sql, conn);

			da.SelectCommand.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

			DataTable dt = new DataTable();
			da.Fill(dt);

			dataGridView1.DataSource = dt;
		}
    }
}
