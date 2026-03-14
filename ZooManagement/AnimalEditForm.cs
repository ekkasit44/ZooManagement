using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using ZooManagement;

namespace ZooManagement
{
    public partial class AnimalEditForm : Form
    {
        int animalId = 0;

        public AnimalEditForm()
        {
            InitializeComponent();
        }

        // เรียกก่อนแสดงฟอร์ม เพื่อโหลดข้อมูลสัตว์ที่ต้องการแก้ไข
        public void LoadFor(int id)
        {
            animalId = id;
            LoadAnimal();
        }

        public AnimalEditForm(int id)
        {
            InitializeComponent();
            animalId = id;
        }

        private void AnimalEditForm_Load(object sender, EventArgs e)
        {
            // โหลดรายการกรง ผู้ดูแล ประเภท และชนิด
            LoadEnclosures();
            LoadKeepers();
            LoadAnimalTypes();
            LoadSpecies();

            if (animalId != 0)
            {
                LoadAnimal();
            }

        }

        private void LoadAnimalTypes()
        {
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT animal_type_id, type_name FROM AnimalType";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbType.DisplayMember = "type_name";
                    cmbType.ValueMember = "animal_type_id";
                    cmbType.DataSource = dt;
                }
            }
            catch { }
        }

        private void LoadSpecies(object typeId = null)
        {
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT species_info_id, common_name FROM SpeciesInfo";
                    if (typeId != null)
                    {
                        sql += " WHERE animal_type_id = @tid";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (typeId != null)
                        cmd.Parameters.AddWithValue("@tid", typeId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbSpecies.DisplayMember = "common_name";
                    cmbSpecies.ValueMember = "species_info_id";
                    cmbSpecies.DataSource = dt;
                }
            }
            catch { }
        }

        void LoadAnimal()
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string sql = "SELECT * FROM Animal WHERE animal_id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", animalId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["name"].ToString();
                    cbGender.Text = reader["gender"].ToString();
                    dtBirth.Value = Convert.ToDateTime(reader["birth_date"]);
                    // ตั้งค่า enclosure ถ้ามี
                    if (reader["enclosure_id"] != DBNull.Value)
                    {
                        var eid = reader["enclosure_id"].ToString();
                        if (cmbEnclosure.DataSource != null)
                            cmbEnclosure.SelectedValue = eid;

                        // ตั้งค่า keeper ตาม EnclosureKeeper
                        try
                        {
                            reader.Close();
                            using (SqlCommand cmd2 = new SqlCommand("SELECT keeper_id FROM EnclosureKeeper WHERE enclosure_id=@eid", conn))
                            {
                                cmd2.Parameters.AddWithValue("@eid", eid);
                                var val = cmd2.ExecuteScalar();
                                if (val != null && val != DBNull.Value && cmbKeeper.DataSource != null)
                                {
                                    cmbKeeper.SelectedValue = val.ToString();
                                }
                            }
                            // ตั้งค่าประเภทและชนิดจากข้อมูลสัตว์
                            try
                            {
                                if (reader["animal_type_id"] != DBNull.Value)
                                {
                                    var tid = reader["animal_type_id"].ToString();
                                    if (cmbType.DataSource != null) cmbType.SelectedValue = tid;
                                    // โหลดเฉพาะชนิดของประเภทนี้
                                    LoadSpecies(tid);
                                }

                                if (reader["species_info_id"] != DBNull.Value)
                                {
                                    var sid = reader["species_info_id"].ToString();
                                    if (cmbSpecies.DataSource != null) cmbSpecies.SelectedValue = sid;
                                }
                            }
                            catch { }
                        }
                        catch { }
                    }
                }

                reader.Close();
            }
        }

        private void LoadEnclosures()
        {
            try
            {
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT enclosure_id, name FROM Enclosure";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbEnclosure.DisplayMember = "name";
                    cmbEnclosure.ValueMember = "enclosure_id";
                    cmbEnclosure.DataSource = dt;
                }
            }
            catch { }
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
            catch { }
        }

        private void cmbEnclosure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEnclosure.SelectedValue == null) return;
                var eid = cmbEnclosure.SelectedValue.ToString();
                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    string sql = "SELECT keeper_id FROM EnclosureKeeper WHERE enclosure_id=@eid";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@eid", eid);
                        var val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value && cmbKeeper.DataSource != null)
                        {
                            cmbKeeper.SelectedValue = val.ToString();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                SqlCommand cmd;

                if (animalId == 0)
                {
                    string sql = "INSERT INTO Animal(name,gender,birth_date,enclosure_id) VALUES(@name,@gender,@birth,@enclosure); SELECT SCOPE_IDENTITY();";
                    cmd = new SqlCommand(sql, conn);
                }
                else
                {
                    string sql = "UPDATE Animal SET name=@name,gender=@gender,birth_date=@birth,enclosure_id=@enclosure WHERE animal_id=@id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", animalId);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                cmd.Parameters.AddWithValue("@birth", dtBirth.Value);

                object enclosureVal = DBNull.Value;
                if (cmbEnclosure != null && cmbEnclosure.SelectedValue != null)
                    enclosureVal = cmbEnclosure.SelectedValue;

                cmd.Parameters.AddWithValue("@enclosure", enclosureVal ?? DBNull.Value);

                if (animalId == 0)
                {
                    // INSERT and get new id
                    var res = cmd.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        animalId = Convert.ToInt32(Convert.ToDecimal(res));
                    }
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }

                // Update EnclosureKeeper mapping for selected enclosure
                try
                {
                    if (enclosureVal != DBNull.Value)
                    {
                        var enclId = enclosureVal.ToString();
                        object keeperVal = DBNull.Value;
                        if (cmbKeeper != null && cmbKeeper.SelectedValue != null)
                            keeperVal = cmbKeeper.SelectedValue;

                        // check existing mapping
                        using (SqlCommand cmdChk = new SqlCommand("SELECT COUNT(*) FROM EnclosureKeeper WHERE enclosure_id=@eid", conn))
                        {
                            cmdChk.Parameters.AddWithValue("@eid", enclId);
                            int cnt = Convert.ToInt32(cmdChk.ExecuteScalar());
                            if (cnt > 0)
                            {
                                using (SqlCommand cmdUpd = new SqlCommand("UPDATE EnclosureKeeper SET keeper_id=@kid WHERE enclosure_id=@eid", conn))
                                {
                                    cmdUpd.Parameters.AddWithValue("@kid", keeperVal ?? DBNull.Value);
                                    cmdUpd.Parameters.AddWithValue("@eid", enclId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                using (SqlCommand cmdIns = new SqlCommand("INSERT INTO EnclosureKeeper(enclosure_id, keeper_id) VALUES(@eid,@kid)", conn))
                                {
                                    cmdIns.Parameters.AddWithValue("@eid", enclId);
                                    cmdIns.Parameters.AddWithValue("@kid", keeperVal ?? DBNull.Value);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch { }

                // Update animal's species and type if available
                try
                {
                    if (cmbSpecies != null && cmbSpecies.SelectedValue != null)
                    {
                        using (SqlCommand cmdSp = new SqlCommand("UPDATE Animal SET species_info_id=@sid, animal_type_id=@tid WHERE animal_id=@aid", conn))
                        {
                            cmdSp.Parameters.AddWithValue("@sid", cmbSpecies.SelectedValue);
                            cmdSp.Parameters.AddWithValue("@tid", cmbType != null && cmbType.SelectedValue != null ? cmbType.SelectedValue : (object)DBNull.Value);
                            cmdSp.Parameters.AddWithValue("@aid", animalId);
                            cmdSp.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            }

            MessageBox.Show("Saved Successfully");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}