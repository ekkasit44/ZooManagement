using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class SpeciesInfoEditForm : Form
    {
        public string SpeciesID = "";
        public string CommonName = "";
        public string ScientificName = "";
        public string Habitat = "";
        public string Diet = "";
        public string Status = "";

        public SpeciesInfoEditForm()
        {
            InitializeComponent();
        }

        private void SpeciesInfoEditForm_Load(object sender, EventArgs e)
        {
            if (SpeciesID != "")
            {
                txtCommonName.Text = CommonName;
                txtScientificName.Text = ScientificName;
                txtHabitat.Text = Habitat;
                txtDiet.Text = Diet;
                txtStatus.Text = Status;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                if (SpeciesID == "")
                {
                    string sql = @"INSERT INTO SpeciesInfo
                                   (common_name, scientific_name, habitat, diet, conservation_status)
                                   VALUES
                                   (@common, @scientific, @habitat, @diet, @status)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@common", txtCommonName.Text);
                    cmd.Parameters.AddWithValue("@scientific", txtScientificName.Text);
                    cmd.Parameters.AddWithValue("@habitat", txtHabitat.Text);
                    cmd.Parameters.AddWithValue("@diet", txtDiet.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql = @"UPDATE SpeciesInfo SET
                                   common_name=@common,
                                   scientific_name=@scientific,
                                   habitat=@habitat,
                                   diet=@diet,
                                   conservation_status=@status
                                   WHERE species_info_id=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@common", txtCommonName.Text);
                    cmd.Parameters.AddWithValue("@scientific", txtScientificName.Text);
                    cmd.Parameters.AddWithValue("@habitat", txtHabitat.Text);
                    cmd.Parameters.AddWithValue("@diet", txtDiet.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@id", SpeciesID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}