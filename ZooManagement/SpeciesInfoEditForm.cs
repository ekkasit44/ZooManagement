using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{


    public partial class SpeciesInfoEditForm : Form
    {
        public SpeciesInfoEditForm()
        {
            InitializeComponent();

        }

        private void SpeciesInfoEditForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT * FROM SpeciesInfo";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["species_info_id"].Value.ToString();
                txtCommonName.Text = row.Cells["common_name"].Value.ToString();
                txtScientific.Text = row.Cells["scientific_name"].Value?.ToString();
                txtHabitat.Text = row.Cells["habitat"].Value?.ToString();
                txtDiet.Text = row.Cells["diet"].Value?.ToString();
                txtStatus.Text = row.Cells["conservation_status"].Value?.ToString();
                txtDescription.Text = row.Cells["description"].Value?.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCommonName.Text.Trim() == "")
            {
                MessageBox.Show("Common Name ห้ามว่าง");
                return;
            }

            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                  

                    string sql = @"INSERT INTO SpeciesInfo
                    (common_name, scientific_name, habitat,
                     diet, conservation_status, description)
                    VALUES
                    (@common,@scientific,@habitat,
                     @diet,@status,@desc)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@common", txtCommonName.Text);
                    cmd.Parameters.AddWithValue("@scientific", txtScientific.Text);
                    cmd.Parameters.AddWithValue("@habitat", txtHabitat.Text);
                    cmd.Parameters.AddWithValue("@diet", txtDiet.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                    LoadData();
                    ClearForm();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
                return;
            }

            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                 

                    string sql =
                        "DELETE FROM SpeciesInfo WHERE species_info_id=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ลบสำเร็จ");
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกข้อมูลก่อน");
                return;
            }

            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    

                    string sql = @"UPDATE SpeciesInfo SET
                        common_name=@common,
                        scientific_name=@scientific,
                        habitat=@habitat,
                        diet=@diet,
                        conservation_status=@status,
                        description=@desc
                        WHERE species_info_id=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@common", txtCommonName.Text);
                    cmd.Parameters.AddWithValue("@scientific", txtScientific.Text);
                    cmd.Parameters.AddWithValue("@habitat", txtHabitat.Text);
                    cmd.Parameters.AddWithValue("@diet", txtDiet.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("แก้ไขสำเร็จ");
                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        void ClearForm()
        {
            txtID.Text = "";
            txtCommonName.Text = "";
            txtScientific.Text = "";
            txtHabitat.Text = "";
            txtDiet.Text = "";
            txtStatus.Text = "";
            txtDescription.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
			this.txtCommonName.Text = "กวางเรนเดียร์";
			this.txtScientific.Text = "Rangifer tarandus";
			this.txtHabitat.Text = "ทุ่งหญ้าและป่าในเขตอาร์กติกและซับอาร์กติก";
			this.txtDiet.Text = "พืช เช่น หญ้า มอส และเห็ด";
			this.txtStatus.Text = "Least Concern";
			this.txtDescription.Text = "กวางเรนเดียร์เป็นสัตว์ที่ปรับตัวได้ดีในสภาพอากาศหนาวเย็น มีเขาที่ใช้ในการต่อสู้และขุดหาหญ้าใต้หิมะ";
		}
    }
}
