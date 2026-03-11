using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class FoodForm : Form
    {
        public FoodForm()
        {
            InitializeComponent();
            this.Load += FoodForm_Load;
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadFood();
        }

        private void LoadFood()
        {
            dgvFood.Rows.Clear();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT food_id,name,type,unit FROM Food";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvFood.Rows.Add(
                        reader["food_id"].ToString(),
                        reader["name"].ToString(),
                        reader["type"].ToString(),
                        reader["unit"].ToString()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FoodEditForm frm = new FoodEditForm();
            frm.ShowDialog();
            LoadFood();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            FoodEditForm frm = new FoodEditForm();

            frm.FoodID = dgvFood.SelectedRows[0].Cells[0].Value.ToString();
            frm.FoodName = dgvFood.SelectedRows[0].Cells[1].Value.ToString();
            frm.Type = dgvFood.SelectedRows[0].Cells[2].Value.ToString();
            frm.Unit = dgvFood.SelectedRows[0].Cells[3].Value.ToString();

            frm.ShowDialog();
            LoadFood();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0)
                return;

            string id = dgvFood.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM Food WHERE food_id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadFood();
        }
    }
}