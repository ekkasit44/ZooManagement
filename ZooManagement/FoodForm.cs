using System;
using System.Data;
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
            // reload when animals change elsewhere
            DataEvents.AnimalsChanged += OnAnimalsChanged;
            this.FormClosed += FoodForm_FormClosed;
        }

        private void OnAnimalsChanged()
        {
            if (this.IsHandleCreated && this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => LoadFoods()));
            }
            else
            {
                LoadFoods();
            }
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void FoodForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try { DataEvents.AnimalsChanged -= OnAnimalsChanged; } catch { }
        }

        private void LoadFoods(string keyword = "")
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                // Select food info. Return one row per food-animal pair so each animal appears on its own row.
                // Include animal_id and animal type name to show and allow editing selection.
                string sql = @"
SELECT 
    f.food_id,
    f.name AS ชื่ออาหาร,
    f.type AS ประเภท,
    f.unit AS หน่วย,
    a.animal_id,
    a.name AS ชื่อสัตว์ที่ให้,
    s.common_name AS ชนิดของสัตว์
FROM Food f
LEFT JOIN FeedingSchedule fs ON f.food_id = fs.food_id
LEFT JOIN Animal a ON fs.animal_id = a.animal_id
LEFT JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id";






                if (!string.IsNullOrEmpty(keyword))
                {
                    sql += " WHERE f.name LIKE @kw OR f.type LIKE @kw OR a.name LIKE @kw OR at.type_name LIKE @kw";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvFood.DataSource = dt;
                }
            }

            // set headers and hide id. Show columns: ชื่ออาหาร, ประเภท, หน่วย, ชื่อสัตว์ที่ให้
            if (dgvFood.Columns != null)
            {
                if (dgvFood.Columns.Contains("food_id")) dgvFood.Columns["food_id"].Visible = false;
                if (dgvFood.Columns.Contains("name")) dgvFood.Columns["name"].HeaderText = "ชื่ออาหาร";
                if (dgvFood.Columns.Contains("type")) dgvFood.Columns["type"].HeaderText = "ประเภท";
                // hide stock column and show unit as หน่วย
                if (dgvFood.Columns.Contains("stock")) dgvFood.Columns["stock"].Visible = false;
                if (dgvFood.Columns.Contains("animal_name")) dgvFood.Columns["animal_name"].HeaderText = "ชื่อสัตว์ที่ให้";
                if (dgvFood.Columns.Contains("animal_type")) dgvFood.Columns["animal_type"].HeaderText = "ชนิดของสัตว์";
                if (dgvFood.Columns.Contains("animal_id")) dgvFood.Columns["animal_id"].Visible = false;
                if (dgvFood.Columns.Contains("unit")) { dgvFood.Columns["unit"].Visible = true; dgvFood.Columns["unit"].HeaderText = "หน่วย"; }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FoodEditForm frm = new FoodEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFoods();   // ⭐ รีโหลดตาราง
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกแถวที่ต้องการแก้ไข");
                return;
            }

            FoodEditForm frm = new FoodEditForm();

            // อ่านค่าจากคอลัมน์ตามชื่อภาษาไทย
            var row = dgvFood.SelectedRows[0];
            frm.FoodID = row.Cells["food_id"].Value?.ToString() ?? "";
            frm.FoodName = row.Cells["ชื่ออาหาร"].Value?.ToString() ?? "";
            frm.Type = row.Cells["ประเภท"].Value?.ToString() ?? "";
            frm.Unit = row.Cells["หน่วย"].Value?.ToString() ?? "";

            // ถ้ามีข้อมูลสัตว์ที่เชื่อมกับอาหารนี้
            if (dgvFood.Columns.Contains("animal_id"))
            {
                frm.AnimalID = row.Cells["animal_id"].Value?.ToString() ?? "";
                frm.AnimalName = row.Cells["ชื่อสัตว์ที่ให้"].Value?.ToString() ?? "";
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFoods();   // รีโหลดตารางทันทีหลังแก้ไข
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0)
                return;

            string id = dgvFood.SelectedRows[0].Cells["food_id"].Value.ToString();

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                

                using (SqlCommand cmdFS = new SqlCommand("DELETE FROM FeedingSchedule WHERE food_id=@id", conn))
                {
                    cmdFS.Parameters.AddWithValue("@id", id);
                    cmdFS.ExecuteNonQuery();
                }

                using (SqlCommand cmdFood = new SqlCommand("DELETE FROM Food WHERE food_id=@id", conn))
                {
                    cmdFood.Parameters.AddWithValue("@id", id);
                    cmdFood.ExecuteNonQuery();
                }
            }


            // รีโหลดตารางทันที
            LoadFoods();
        }

    }
}