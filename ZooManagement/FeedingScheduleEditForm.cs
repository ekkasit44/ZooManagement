using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class FeedingScheduleEditForm : Form
    {
        public string ScheduleID = "";
        public string AnimalID = "";
        public string FoodID = "";
        public string FeedingTime = "";
        public string Quantity = "";

        public FeedingScheduleEditForm()
        {
            InitializeComponent();
            this.Load += FeedingScheduleEditForm_Load;
        }

        private void FeedingScheduleEditForm_Load(object sender, EventArgs e)
        {
            txtAnimalID.Text = AnimalID;
            txtFoodID.Text = FoodID;
            txtFeedingTime.Text = FeedingTime;
            txtQuantity.Text = Quantity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (ScheduleID == "")
                {
                    string sql = @"INSERT INTO FeedingSchedule
                                  (animal_id,food_id,feeding_time,quantity)
                                  VALUES(@animal,@food,@time,@qty)";
                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = @"UPDATE FeedingSchedule
                                  SET animal_id=@animal,
                                      food_id=@food,
                                      feeding_time=@time,
                                      quantity=@qty
                                  WHERE schedule_id=@id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", ScheduleID);
                }

                cmd.Parameters.AddWithValue("@animal", txtAnimalID.Text);
                cmd.Parameters.AddWithValue("@food", txtFoodID.Text);
                cmd.Parameters.AddWithValue("@time", txtFeedingTime.Text);
                cmd.Parameters.AddWithValue("@qty", txtQuantity.Text);

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