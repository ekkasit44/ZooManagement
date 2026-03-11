using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    public partial class KeeperEditForm : Form
    {
        SqlConnection conn;

        public KeeperEditForm()
        {
            InitializeComponent();
            conn = connectDB.ConnectZooDB();
        }

        private void KeeperEditForm_Load(object sender, EventArgs e)
        {
            LoadData();

            comboPosition.Items.Add("Manager");
            comboPosition.Items.Add("Senior Keeper");
            comboPosition.Items.Add("Junior Keeper");
        }


        void LoadData()
        {
            string sql = "SELECT * FROM Keeper";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
			string sql = "INSERT INTO keeper(name,phone,email) VALUES(@name,@phone,@email)";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("@name", txtName.Text);
			cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
			cmd.Parameters.AddWithValue("@email", txtEmail.Text);

			cmd.ExecuteNonQuery();
			LoadData();
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
			int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["keeper_id"].Value);

			string sql = "DELETE FROM keeper WHERE keeper_id=@id";

			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@id", id);

			cmd.ExecuteNonQuery();

			LoadData();
		}

        private void btnEdit_Click(object sender, EventArgs e)
        {
			int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["keeper_id"].Value);

			string sql = @"UPDATE keeper 
               SET name=@name,
                   phone=@phone,
                   email=@email
               WHERE keeper_id=@id";

			SqlCommand cmd = new SqlCommand(sql, conn);

			cmd.Parameters.AddWithValue("@name", txtName.Text);
			cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
			cmd.Parameters.AddWithValue("@email", txtEmail.Text);
			cmd.Parameters.AddWithValue("@id", id);

			cmd.ExecuteNonQuery();
			LoadData();
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (dataGridView1.CurrentRow == null) return;

			if (dataGridView1.CurrentRow == null) return;

			txtName.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
			txtPhone.Text = dataGridView1.CurrentRow.Cells["phone"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();

		}


	}

    }
