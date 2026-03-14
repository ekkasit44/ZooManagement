using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ZooManagement
{
    public partial class FeedingScheduleForm : Form
    {
        public FeedingScheduleForm()
        {
            InitializeComponent();
            this.Load += FeedingScheduleForm_Load;
        }
        DataTable dtFeeding = new DataTable();

        private void FeedingScheduleForm_Load(object sender, EventArgs e)
        {
            LoadFeeding();
            LoadAnimal();
            LoadFood();
        }

        private void LoadFeeding()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT
        fs.feeding_id AS รหัสการให้อาหาร,
        a.name AS ชื่อสัตว์,
        f.name AS อาหาร,
        fs.feeding_time AS เวลาให้อาหาร,
        fs.amount AS ปริมาณ,
        k.name AS ผู้ให้อาหาร

        FROM FeedingSchedule fs

        JOIN Animal a
        ON fs.animal_id = a.animal_id

        JOIN Food f
        ON fs.food_id = f.food_id

        LEFT JOIN keeper k
        ON fs.keeper_id = k.keeper_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtFeeding.Clear();
                da.Fill(dtFeeding);

                dgvFeeding.DataSource = dtFeeding;
            }
        }

        private void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT
        animal_id AS รหัสสัตว์,
        name AS ชื่อสัตว์
        FROM Animal";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAnimal.DataSource = dt;
            }
        }

        private void LoadFood()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT
        food_id AS รหัสอาหาร,
        name AS อาหาร
        FROM Food";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFood.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FeedingScheduleEditForm frm = new FeedingScheduleEditForm();
            frm.ShowDialog();
            LoadFeeding();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFeeding.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกข้อมูล");
                return;
            }

            int id = Convert.ToInt32(
                dgvFeeding.CurrentRow.Cells["รหัสการให้อาหาร"].Value
            );

            FeedingScheduleEditForm frm = new FeedingScheduleEditForm();
            frm.FeedingID = id;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFeeding();   // รีโหลดตาราง
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFeeding.SelectedRows.Count == 0)
                return;

            string id = dgvFeeding.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM FeedingSchedule WHERE feeding_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadFeeding();
        }

        private void SearchFeeding()
        {
            string keyword = txtSearch.Text.Trim();

            DataView dv = new DataView(dtFeeding);

            dv.RowFilter =
            $"CONVERT([รหัสการให้อาหาร],'System.String') LIKE '%{keyword}%' OR " +
            $"[ชื่อสัตว์] LIKE '%{keyword}%' OR " +
            $"[อาหาร] LIKE '%{keyword}%'";

            dgvFeeding.DataSource = dv;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchFeeding();
        }
    }
}
