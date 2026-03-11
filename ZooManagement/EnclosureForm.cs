using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class EnclosureForm : Form
    {
        public EnclosureForm()
        {
            InitializeComponent();
            this.Load += EnclosureForm_Load;
        }

        private void EnclosureForm_Load(object sender, EventArgs e)
        {
            LoadEnclosure();
        }

        private void LoadEnclosure()
        {
            dgvEnclosure.Rows.Clear();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT enclosure_id,name,location FROM Enclosure";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvEnclosure.Rows.Add(
                        reader["enclosure_id"].ToString(),
                        reader["name"].ToString(),
                        reader["location"].ToString()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnclosureEditForm frm = new EnclosureEditForm();
            frm.ShowDialog();
            LoadEnclosure();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEnclosure.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row");
                return;
            }

            EnclosureEditForm frm = new EnclosureEditForm();

            frm.EnclosureID = dgvEnclosure.SelectedRows[0].Cells[0].Value.ToString();
            frm.Name = dgvEnclosure.SelectedRows[0].Cells[1].Value.ToString();
            frm.LocationName = dgvEnclosure.SelectedRows[0].Cells[2].Value.ToString();

            frm.ShowDialog();
            LoadEnclosure();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEnclosure.SelectedRows.Count == 0)
                return;

            string id = dgvEnclosure.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "DELETE FROM Enclosure WHERE enclosure_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadEnclosure();
        }
    }
}