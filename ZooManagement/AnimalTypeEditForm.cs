using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class AnimalTypeEditForm : Form
    {
        public string TypeID = "";
        public string TypeName = "";
        public string Description = "";

        public AnimalTypeEditForm()
        {
            InitializeComponent();
        }

        private void AnimalTypeEditForm_Load(object sender, EventArgs e)
        {
            txtTypeName.Text = TypeName;
            txtDescription.Text = Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (TypeID == "")
                {
                    string sql = "INSERT INTO AnimalType(type_name,description) VALUES(@name,@desc)";
                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = "UPDATE AnimalType SET type_name=@name,description=@desc WHERE animal_type_id=@id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", TypeID);
                }

                cmd.Parameters.AddWithValue("@name", txtTypeName.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved successfully");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}