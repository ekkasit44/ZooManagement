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
            LoadCombo();
            LoadSpecies();
            LoadType();



        }
        void LoadData()
        {
            conn = connectDB.ConnectZooDB();

            string sql = @"SELECT 
            species_info_id,
            common_name,
            scientific_name,
            habitat,
            diet,
            conservation_status
           FROM SpeciesInfo";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // 1. นำข้อมูลใส่ตาราง
            dataGridView1.DataSource = dt;

            // 2. เปลี่ยนหัวคอลัมน์เป็นภาษาไทย (อ้างอิงจากชื่อคอลัมน์ใน SQL)
            dataGridView1.Columns["species_info_id"].HeaderText = "รหัสชนิดสัตว์";
            dataGridView1.Columns["common_name"].HeaderText = "ชื่อทั่วไป";
            dataGridView1.Columns["scientific_name"].HeaderText = "ชื่อวิทยาศาสตร์";
            dataGridView1.Columns["habitat"].HeaderText = "ถิ่นที่อยู่อาศัย";
            dataGridView1.Columns["diet"].HeaderText = "ประเภทอาหาร";
            dataGridView1.Columns["conservation_status"].HeaderText = "สถานะการอนุรักษ์";

            // 3. ตั้งค่ารูปแบบการแสดงผลของตาราง (ลบบรรทัดที่ซ้ำซ้อนออกให้แล้วครับ)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Dock = DockStyle.Fill;
        }
        void LoadCombo()
        {
            conn = connectDB.ConnectZooDB();

            string sql = "SELECT species_info_id, common_name FROM SpeciesInfo";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            comboSpecies.DataSource = dt;
            comboSpecies.DisplayMember = "common_name";
            comboSpecies.ValueMember = "species_info_id";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            conn = connectDB.ConnectZooDB();

            string sql = @"SELECT 
                    species_info_id,
                    common_name,
                    scientific_name,
                    habitat,
                    diet,
                    conservation_status
                   FROM SpeciesInfo
                   WHERE species_info_id = @id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", comboSpecies.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadSpecies()
        {
            conn = connectDB.ConnectZooDB();

            string sql = "SELECT species_info_id, common_name FROM SpeciesInfo";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboSpecies.DataSource = dt;
            comboSpecies.DisplayMember = "common_name";
            comboSpecies.ValueMember = "species_info_id";
        }
        void LoadType()
        {
            conn = connectDB.ConnectZooDB();

            string sql = "SELECT animal_type_id, type_name FROM AnimalType";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboType.DataSource = dt;
            comboType.DisplayMember = "type_name";
            comboType.ValueMember = "animal_type_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeciesInfoEditForm form = new SpeciesInfoEditForm();
			 form.ShowDialog();
		}
    }
}
