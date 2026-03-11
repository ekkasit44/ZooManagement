using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class SpeciesInfoEditForm : Form
    {
        public SpeciesInfoEditForm()
        {
            InitializeComponent();
        }







        private void btnAllAnimals_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectDB.ConnectZooDB();



            string sql = @"SELECT 
            a.name,
            s.common_name,
            e.name AS enclosure
            FROM Animal a
            JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id
            JOIN Enclosure e ON a.enclosure_id = e.enclosure_id";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnZoneAnimals_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectDB.ConnectZooDB();

            string sql = @"SELECT 
            e.name,
            COUNT(a.animal_id) AS total_animals
            FROM Enclosure e
            LEFT JOIN Animal a ON e.enclosure_id = a.enclosure_id
            GROUP BY e.name";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectDB.ConnectZooDB();

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

        private void SpeciesInfoEditForm_Load(object sender, EventArgs e)
        {
            LoadAllAnimals();
        }
        void LoadAllAnimals()
        {
            SqlConnection conn = connectDB.ConnectZooDB();
            string sql = @"SELECT 
            a.name,
            s.common_name,
            e.name AS enclosure
            FROM Animal a
            JOIN SpeciesInfo s ON a.species_info_id = s.species_info_id
            JOIN Enclosure e ON a.enclosure_id = e.enclosure_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
