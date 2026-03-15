using Microsoft.Data.SqlClient;
using System;
using System.Data;
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
        // selected animal for this food (optional)
        public string AnimalID = "";
        public string AnimalName = "";

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

            // Load animals into combo box
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT animal_id, name FROM Animal";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbAnimal.DisplayMember = "name";
                    cmbAnimal.ValueMember = "animal_id";
                    cmbAnimal.DataSource = dt;

                    // set selection if provided
                    if (!string.IsNullOrEmpty(AnimalID))
                    {
                        cmbAnimal.SelectedValue = AnimalID;
                    }
                    else if (!string.IsNullOrEmpty(AnimalName))
                    {
                        for (int i = 0; i < cmbAnimal.Items.Count; i++)
                        {
                            var row = ((DataRowView)cmbAnimal.Items[i]).Row;
                            if (row["name"].ToString() == AnimalName)
                            {
                                cmbAnimal.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                // ignore load errors
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                

                // ถ้าเป็นการเพิ่มอาหารใหม่
                if (string.IsNullOrEmpty(FoodID))
                {
                    string sql = @"INSERT INTO Food(name,type,unit)
                           OUTPUT INSERTED.food_id
                           VALUES(@name,@type,@unit)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@type", txtType.Text);
                        cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
                        FoodID = cmd.ExecuteScalar().ToString();
                    }
                }
                else
                {
                    // ถ้าเป็นการแก้ไขอาหาร → อัปเดตเฉพาะข้อมูลอาหาร
                    string sql = @"UPDATE Food
                           SET name=@name, type=@type, unit=@unit
                           WHERE food_id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", FoodID);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@type", txtType.Text);
                        cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // อัปเดต FeedingSchedule เฉพาะสัตว์ที่เลือก
                if (cmbAnimal != null && cmbAnimal.SelectedValue != null)
                {
                    AnimalID = cmbAnimal.SelectedValue.ToString();
                    AnimalName = cmbAnimal.Text;

                    string sqlFS = @"UPDATE FeedingSchedule
                             SET food_id=@food_id
                             WHERE animal_id=@animal_id";
                    using (SqlCommand cmdFS = new SqlCommand(sqlFS, conn))
                    {
                        cmdFS.Parameters.AddWithValue("@food_id", FoodID);
                        cmdFS.Parameters.AddWithValue("@animal_id", AnimalID);
                        cmdFS.ExecuteNonQuery();
                    }
                }

                // หลังจาก INSERT หรือ UPDATE Food เสร็จแล้ว
                if (cmbAnimal != null && cmbAnimal.SelectedValue != null)
                {
                    AnimalID = cmbAnimal.SelectedValue.ToString();
                    AnimalName = cmbAnimal.Text;

                    // ตรวจสอบว่ามีแถว FeedingSchedule อยู่แล้วหรือไม่
                    string checkSql = @"SELECT COUNT(*) FROM FeedingSchedule 
                        WHERE animal_id=@animal_id AND food_id=@food_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@animal_id", AnimalID);
                        checkCmd.Parameters.AddWithValue("@food_id", FoodID);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // ถ้ามีอยู่แล้ว → UPDATE แก้ไขแถวเดิม
                            string updateSql = @"UPDATE FeedingSchedule
                                 SET feeding_date=GETDATE(), feeding_time=GETDATE()
                                 WHERE animal_id=@animal_id AND food_id=@food_id";
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@animal_id", AnimalID);
                                updateCmd.Parameters.AddWithValue("@food_id", FoodID);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // ถ้าไม่มี → INSERT ใหม่
                            string insertSql = @"INSERT INTO FeedingSchedule(animal_id, food_id, amount, feeding_date, feeding_time, keeper_id)
                                 VALUES(@animal_id, @food_id, 0, GETDATE(), GETDATE(), NULL)";
                            using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@animal_id", AnimalID);
                                insertCmd.Parameters.AddWithValue("@food_id", FoodID);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;  // ให้ FoodForm รีโหลดทันที
                this.Close();


            }

            MessageBox.Show("Saved");
            this.DialogResult = DialogResult.OK;  // ⭐ รีโหลดตารางทันทีใน FoodForm
            this.Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}