using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ZooManagement
{
    public partial class EnclosureEditForm : Form
    {
        public string EnclosureID = "";
        public string Name = "";
        public string LocationName = "";

        public EnclosureEditForm()
        {
            InitializeComponent();
            this.Load += EnclosureEditForm_Load;
        }

        private void EnclosureEditForm_Load(object sender, EventArgs e)
        {
            txtName.Text = Name;
            txtLocation.Text = LocationName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (EnclosureID == "")
                {
                    string sql = "INSERT INTO Enclosure(name,location) VALUES(@name,@location)";
                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = "UPDATE Enclosure SET name=@name,location=@location WHERE enclosure_id=@id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", EnclosureID);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@location", txtLocation.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}