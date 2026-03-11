using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ZooManagement
{
    public partial class FoodEditForm : Form
    {
        public string FoodID = "";
        public string FoodName = "";
        public string Type = "";
        public string Unit = "";

        public FoodEditForm()
        {
            InitializeComponent();
            this.Load += FoodEditForm_Load;
        }

        private void FoodEditForm_Load(object sender, EventArgs e)
        {
            txtName.Text = FoodName;
            txtType.Text = Type;
            txtUnit.Text = Unit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (FoodID == "")
                {
                    string sql = @"INSERT INTO Food(name,type,unit)
                                   VALUES(@name,@type,@unit)";
                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = @"UPDATE Food
                                   SET name=@name,
                                       type=@type,
                                       unit=@unit
                                   WHERE food_id=@id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", FoodID);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@type", txtType.Text);
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text);

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