using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;

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
            this.Load += AnimalTypeEditForm_Load;
        }

        private void AnimalTypeEditForm_Load(object sender, EventArgs e)
        {
            // โหลดรายการประเภทเพื่อเลือก
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT animal_type_id, type_name FROM AnimalType";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbTypeName.DisplayMember = "type_name";
                    cmbTypeName.ValueMember = "animal_type_id";
                    cmbTypeName.DataSource = dt;
                }
            }
            catch { }

            if (!string.IsNullOrEmpty(TypeID))
            {
                // เลือกรายการที่แก้ไข
                try { cmbTypeName.SelectedValue = TypeID; } catch { }
            }

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

                // ใช้ค่าจาก ComboBox (อนุญาตให้พิมพ์ชื่อใหม่ด้วย)
                string typeName = cmbTypeName.Text;
                cmd.Parameters.AddWithValue("@name", typeName);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Saved successfully");

            // รีโหลดหน้าที่เกี่ยวข้อง (AnimalTypeForm และ AnimalForm) หากเปิดอยู่
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is AnimalTypeForm atf)
                    {
                        atf.LoadAnimalType();
                    }
                    else if (f is AnimalForm af)
                    {
                        af.LoadAnimal();
                    }
                }
            }
            catch { }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}