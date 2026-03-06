using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using ZooManagement;

namespace ZooManagement
{
    public partial class AnimalEditForm : Form
    {
        int animalId = 0;

        public AnimalEditForm()
        {
            InitializeComponent();
        }

        public AnimalEditForm(int id)
        {
            InitializeComponent();
            animalId = id;
        }

        private void AnimalEditForm_Load(object sender, EventArgs e)
        {
            if (animalId != 0)
            {
                LoadAnimal();
            }
        }

        void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT * FROM Animal WHERE animal_id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", animalId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["name"].ToString();
                    cbGender.Text = reader["gender"].ToString();
                    dtBirth.Value = Convert.ToDateTime(reader["birth_date"]);
                }

                reader.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (animalId == 0)
                {
                    string sql = "INSERT INTO Animal(name,gender,birth_date) VALUES(@name,@gender,@birth)";

                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = "UPDATE Animal SET name=@name,gender=@gender,birth_date=@birth WHERE animal_id=@id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", animalId);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.Parameters.AddWithValue("@birth", dtBirth.Value);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved Successfully");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}