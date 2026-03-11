using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class FeedingScheduleForm : Form
    {
        public FeedingScheduleForm()
        {
            InitializeComponent();
            this.Load += FeedingScheduleForm_Load;
        }

        private void FeedingScheduleForm_Load(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            dgvSchedule.Rows.Clear();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT feeding_id,
                              animal_id,
                              food_id,
                              amount,
                              feeding_date,
                              feeding_time,
                              keeper_id
                       FROM FeedingSchedule";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvSchedule.Rows.Add(
                        reader["feeding_id"].ToString(),
                        reader["animal_id"].ToString(),
                        reader["food_id"].ToString(),
                        reader["amount"].ToString(),
                        reader["feeding_date"].ToString(),
                        reader["feeding_time"].ToString(),
                        reader["keeper_id"].ToString()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FeedingScheduleEditForm frm = new FeedingScheduleEditForm();
            frm.ShowDialog();
            LoadSchedule();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            FeedingScheduleEditForm frm = new FeedingScheduleEditForm();

            frm.ScheduleID = dgvSchedule.SelectedRows[0].Cells[0].Value.ToString();
            frm.AnimalID = dgvSchedule.SelectedRows[0].Cells[1].Value.ToString();
            frm.FoodID = dgvSchedule.SelectedRows[0].Cells[2].Value.ToString();
            frm.FeedingTime = dgvSchedule.SelectedRows[0].Cells[3].Value.ToString();
            frm.Quantity = dgvSchedule.SelectedRows[0].Cells[4].Value.ToString();

            frm.ShowDialog();
            LoadSchedule();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
                return;

            string id = dgvSchedule.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM FeedingSchedule WHERE schedule_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadSchedule();
        }
    }
}
