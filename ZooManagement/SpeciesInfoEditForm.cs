using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class SpeciesInfoEditForm : Form
    {
        public SpeciesInfoEditForm()
        {
            InitializeComponent();
            this.Load += SpeciesInfoEditForm_Load;
        }

        private void SpeciesInfoEditForm_Load(object sender, EventArgs e)
        {
            // ตอนเปิดฟอร์ม (ถ้ายังไม่ต้องทำอะไร ปล่อยว่างได้)
        }

        private void btnAllAnimals_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
                                a.name AS AnimalName,
                                s.common_name AS Species,
                                e.name AS Enclosure
                               FROM Animal a
                               JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id
                               JOIN Enclosure e ON a.enclosure_id = e.enclosure_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnZoneAnimals_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
                                e.name AS Enclosure,
                                COUNT(a.animal_id) AS TotalAnimals
                               FROM Enclosure e
                               LEFT JOIN Animal a 
                               ON e.enclosure_id = a.enclosure_id
                               GROUP BY e.name";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = @"SELECT 
                                a.name AS AnimalName,
                                f.name AS FoodName,
                                fs.amount,
                                fs.feeding_date,
                                fs.feeding_time
                               FROM FeedingSchedule fs
                               JOIN Animal a ON fs.animal_id = a.animal_id
                               JOIN Food f ON fs.food_id = f.food_id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}