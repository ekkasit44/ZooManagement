using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using ZooManagement;

namespace ZooManagement
{
    public partial class AnimalForm : Form
    {
        private int selectedAnimalId = 0;

        public AnimalForm()
        {
            InitializeComponent();
            DataEvents.AnimalsChanged += OnAnimalsChanged;
            this.FormClosed += AnimalForm_FormClosed;
        }
        DataTable dtAnimal = new DataTable();
        DataTable dtKeeper = new DataTable();
        private void AnimalForm_Load(object sender, EventArgs e)
        {
            LoadAnimal();
            LoadKeeper();
            dgvAnimal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void OnAnimalsChanged()
        {
            if (this.IsHandleCreated && this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => { LoadAnimal(); dgvAnimal?.Refresh(); }));
            }
            else
            {
                LoadAnimal();
                dgvAnimal?.Refresh();
            }
        }

        private void AnimalForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            try { DataEvents.AnimalsChanged -= OnAnimalsChanged; } catch { }
        }

        // โหลดข้อมูลสัตว์
        public void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                // Use LEFT JOIN so animals without species or enclosure still appear
                // Include gender instead of direct keeper name in this main grid
                string sql = @"SELECT 
        a.animal_id AS รหัสสัตว์,
        a.name AS ชื่อสัตว์,
        a.gender AS เพศ,
        s.common_name AS ชนิด,
        at.type_name AS ประเภท,
        e.name AS กรง,
        birth_date AS วันเกิด

        FROM Animal a
        LEFT JOIN AnimalType at ON a.animal_type_id = at.animal_type_id
        LEFT JOIN SpeciesInfo s 
        ON a.species_info_id = s.species_info_id

        LEFT JOIN Enclosure e 
        ON a.enclosure_id = e.enclosure_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtAnimal.Clear();
                da.Fill(dtAnimal);

                dgvAnimal.DataSource = dtAnimal;
            }
        }



        private void LoadKeeper()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
        a.name AS ชื่อสัตว์,
        k.name AS ผู้ดูแล,
        k.phone AS เบอร์โทร
        FROM Animal a
        JOIN Enclosure e ON a.enclosure_id = e.enclosure_id
        JOIN EnclosureKeeper ek ON e.enclosure_id = ek.enclosure_id
        JOIN Keeper k ON ek.keeper_id = k.keeper_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtKeeper.Clear();
                da.Fill(dtKeeper);

                dgvKeeper.DataSource = dtKeeper;
            }
        }





        // Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnimalEditForm f = new AnimalEditForm();
            f.ShowDialog();

            LoadAnimal();
        }

        // Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // สมมติว่าดึง ID จากตารางมาไว้ในตัวแปร selectedAnimalId
            if (selectedAnimalId == 0)
            {
                MessageBox.Show("กรุณาเลือกสัตว์ที่ต้องการแก้ไขก่อน");
                return;
            }

            // ต้องเปิดฟอร์มโดยส่งค่า ID เข้าไปในวงเล็บด้วย! (ดึงคอนสตรัคเตอร์ตัวที่สองมาใช้)
            int idToEdit = Convert.ToInt32(selectedAnimalId);
            AnimalEditForm frm = new AnimalEditForm(idToEdit);

            // หรือถ้าจะใช้วิธี LoadFor ก็ให้เขียนแบบนี้:
            // AnimalEditForm frm = new AnimalEditForm();
            // frm.LoadFor(idToEdit);

            frm.ShowDialog();

            // โหลดตารางใหม่หลังแก้ไขเสร็จ...
        }

        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimal.CurrentRow == null) return;

            int id = Convert.ToInt32(
                dgvAnimal.CurrentRow.Cells["รหัสสัตว์"].Value);

            DialogResult result = MessageBox.Show(
                "Delete this animal?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "DELETE FROM Animal WHERE animal_id=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                LoadAnimal();
            }
        }

        private void btnSearchAnimal_Click(object sender, EventArgs e)
        {
            SearchData(); 
        }

        private void dgvAnimal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                selectedAnimalId = Convert.ToInt32(dgvAnimal.Rows[e.RowIndex].Cells["รหัสสัตว์"].Value);
                LoadKeeperForAnimal(selectedAnimalId);
            }
            catch { }
        }

        private void LoadKeeperForAnimal(int animalId)
        {
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = @"SELECT k.keeper_id AS รหัสผู้ดูแล, k.name AS ผู้ดูแล, k.phone AS เบอร์โทร
                                   FROM EnclosureKeeper ek
                                   JOIN Keeper k ON ek.keeper_id = k.keeper_id
                                   JOIN Animal a ON a.enclosure_id = ek.enclosure_id
                                   WHERE a.animal_id = @aid";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", animalId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKeeper.DataSource = dt;
                    }
                }
            }
            catch { }
        }

        private void SearchData()
        {
            string keyword = txtSearchAnimal.Text.Trim();

            DataView dvAnimal = new DataView(dtAnimal);
            dvAnimal.RowFilter = $"ชื่อสัตว์ LIKE '%{keyword}%' OR ชนิด LIKE '%{keyword}%' OR กรง LIKE '%{keyword}%' OR เพศ LIKE '%{keyword}%'";

            dgvAnimal.DataSource = dvAnimal;

            DataView dvKeeper = new DataView(dtKeeper);
            dvKeeper.RowFilter = $"ชื่อสัตว์ LIKE '%{keyword}%'" +
                                 $" OR ผู้ดูแล LIKE '%{keyword}%'" +
                                 $" OR เบอร์โทร LIKE '%{keyword}%'";
            dgvKeeper.DataSource = dvKeeper;
        }
    }
}