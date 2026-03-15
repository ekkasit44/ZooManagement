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
            LoadCombo();
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

        }

        void LoadData()
        {
            conn = connectDB.ConnectZooDB();

            string sql = @"SELECT 
                    k.keeper_id,
                    k.name,
                    k.phone,
                    k.email,
                    e.enclosure_id,
                    e.name AS enclosure_name
                   FROM Keeper k
                   LEFT JOIN EnclosureKeeper ek 
                        ON k.keeper_id = ek.keeper_id
                   LEFT JOIN Enclosure e 
                        ON ek.enclosure_id = e.enclosure_id";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        void LoadCombo()
        {
            conn = connectDB.ConnectZooDB();

            string sql1 = "SELECT keeper_id, name FROM Keeper";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            comboKeeper.DataSource = dt1;
            comboKeeper.DisplayMember = "name";
            comboKeeper.ValueMember = "keeper_id";


            string sql2 = "SELECT enclosure_id, name FROM Enclosure";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            comboEnclosure.DataSource = dt2;
            comboEnclosure.DisplayMember = "name";
            comboEnclosure.ValueMember = "enclosure_id";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            conn = connectDB.ConnectZooDB();

            string sql = @"SELECT 
                    k.keeper_id,
                    k.name AS keeper_name,
                    k.phone,
                    k.email,
                    e.name AS enclosure_name
                   FROM Keeper k
                   LEFT JOIN EnclosureKeeper ek 
                        ON k.keeper_id = ek.keeper_id
                   LEFT JOIN Enclosure e 
                        ON ek.enclosure_id = e.enclosure_id
                   WHERE 1=1 ";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            if (comboKeeper.SelectedIndex != -1)
            {
                sql += " AND k.keeper_id = @kid";
                cmd.Parameters.AddWithValue("@kid", comboKeeper.SelectedValue);
            }

            if (comboEnclosure.SelectedIndex != -1)
            {
                sql += " AND e.enclosure_id = @eid";
                cmd.Parameters.AddWithValue("@eid", comboEnclosure.SelectedValue);
            }

            cmd.CommandText = sql;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
    ;
}
