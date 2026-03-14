using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace ZooManagement
{
    public partial class FeedingScheduleEditForm : Form
    {
        public string ScheduleID = "";
        public string AnimalID = "";
        public string FoodID = "";
        public string FeedingTime = "";
        public string Quantity = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FeedingID { get; internal set; }

        public FeedingScheduleEditForm()
        {
            InitializeComponent();
            this.Load += FeedingScheduleEditForm_Load;
        }

        private void FeedingScheduleEditForm_Load(object sender, EventArgs e)
        {
            // โหลดรายการผู้ดูแล
            LoadKeepers();

            // ตั้งค่าเริ่มต้นจากค่าที่ส่งมา (ถ้ามี)
            txtAnimalID.Text = AnimalID;
            txtFoodID.Text = FoodID;
            txtFeedingTime.Text = FeedingTime;
            txtQuantity.Text = Quantity;

            // ถ้าเป็นการแก้ไข (FeedingID != 0) ให้โหลดข้อมูลจากฐานข้อมูลและตั้งค่า keeper ที่เกี่ยวข้อง
            if (FeedingID != 0)
            {
                try
                {
                    using (SqlConnection conn = connectDB.ConnectZooDB())
                    {
                        string sql = @"SELECT animal_id, food_id, feeding_time, amount, keeper_id FROM FeedingSchedule WHERE feeding_id=@id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", FeedingID);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    txtAnimalID.Text = r["animal_id"] == DBNull.Value ? "" : r["animal_id"].ToString();
                                    txtFoodID.Text = r["food_id"] == DBNull.Value ? "" : r["food_id"].ToString();
                                    txtFeedingTime.Text = r["feeding_time"] == DBNull.Value ? "" : r["feeding_time"].ToString();
                                    txtQuantity.Text = r["amount"] == DBNull.Value ? "" : r["amount"].ToString();

                                    if (r["keeper_id"] != DBNull.Value)
                                    {
                                        var kid = r["keeper_id"].ToString();
                                        if (cmbKeeper.Items.Count > 0)
                                        {
                                            cmbKeeper.SelectedValue = kid;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // ไม่ต้องทำอะไรถ้าโหลดข้อมูลไม่สำเร็จ
                }
            }
            else
            {
                // หากเป็นการเพิ่มใหม่ และส่ง AnimalID มา ให้พยายามตั้ง Keeper เริ่มต้นจาก EnclosureKeeper ของกรงสัตว์
                if (!string.IsNullOrEmpty(AnimalID))
                {
                    try
                    {
                        using (SqlConnection conn = connectDB.ConnectZooDB())
                        {
                            string sql = @"SELECT ek.keeper_id
                                           FROM EnclosureKeeper ek
                                           JOIN Animal a ON a.enclosure_id = ek.enclosure_id
                                           WHERE a.animal_id = @aid";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@aid", AnimalID);
                                var val = cmd.ExecuteScalar();
                                if (val != null && val != DBNull.Value)
                                {
                                    cmbKeeper.SelectedValue = val.ToString();
                                }
                            }
                        }
                    }
                    catch
                    {
                        // ignore
                    }
                }
            }
        }

        private void LoadKeepers()
        {
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT keeper_id, name FROM keeper";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbKeeper.DisplayMember = "name";
                    cmbKeeper.ValueMember = "keeper_id";
                    cmbKeeper.DataSource = dt;
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
                try
                {

                    // ถ้า FeedingID == 0 ให้ทำการ INSERT (กรณีเพิ่มใหม่)
                    string sql;
                    bool isInsert = FeedingID == 0;

                    if (isInsert)
                    {
                        sql = @"INSERT INTO FeedingSchedule (animal_id, food_id, feeding_time, amount, keeper_id)
                                VALUES(@animal, @food, @time, @amount, @keeper)";
                    }
                    else
                    {
                        sql = @"UPDATE FeedingSchedule
                                 SET animal_id=@animal,
                                     food_id=@food,
                                     feeding_time=@time,
                                     amount=@amount,
                                     keeper_id=@keeper
                                 WHERE feeding_id=@id";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // animal / food จาก TextBox ตาม Designer
                        cmd.Parameters.AddWithValue("@animal", string.IsNullOrEmpty(txtAnimalID.Text) ? (object)DBNull.Value : txtAnimalID.Text);
                        cmd.Parameters.AddWithValue("@food", string.IsNullOrEmpty(txtFoodID.Text) ? (object)DBNull.Value : txtFoodID.Text);

                        // พยายามแปลงเวลาเป็น DateTime ถ้าเป็นไปได้
                        if (DateTime.TryParse(txtFeedingTime.Text, out DateTime parsedTime))
                            cmd.Parameters.AddWithValue("@time", parsedTime);
                        else
                            cmd.Parameters.AddWithValue("@time", DBNull.Value);

                        // ปริมาณ (amount)
                        if (decimal.TryParse(txtQuantity.Text, out decimal parsedQty))
                            cmd.Parameters.AddWithValue("@amount", parsedQty);
                        else
                            cmd.Parameters.AddWithValue("@amount", string.IsNullOrEmpty(txtQuantity.Text) ? (object)DBNull.Value : txtQuantity.Text);

                        // กำหนดค่า keeper ถ้ามีการเลือก
                        object keeperVal = DBNull.Value;
                        if (cmbKeeper != null && cmbKeeper.SelectedValue != null)
                        {
                            keeperVal = cmbKeeper.SelectedValue;
                        }
                        cmd.Parameters.AddWithValue("@keeper", keeperVal ?? DBNull.Value);

                        if (!isInsert)
                        {
                            cmd.Parameters.AddWithValue("@id", FeedingID);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving feeding schedule:\n" + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

