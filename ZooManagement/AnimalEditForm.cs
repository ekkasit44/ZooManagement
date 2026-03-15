using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using ZooManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZooManagement
{
    public partial class AnimalEditForm : Form
    {
        int animalId = 0;

        public AnimalEditForm()
        {
            InitializeComponent();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedValue == null) return;
                LoadSpecies(cmbType.SelectedValue);
            }
            catch { }
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

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Read values into locals while reader is open
                        var name = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
                        var gender = reader["gender"] == DBNull.Value ? string.Empty : reader["gender"].ToString();
                        DateTime birth = reader["birth_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["birth_date"]);
                        string eid = reader["enclosure_id"] == DBNull.Value ? null : reader["enclosure_id"].ToString();
                        string typeId = reader["animal_type_id"] == DBNull.Value ? null : reader["animal_type_id"].ToString();
                        string speciesId = reader["species_info_id"] == DBNull.Value ? null : reader["species_info_id"].ToString();

                        // set basic controls
                        txtName.Text = name;
                        cbGender.Text = gender;
                        if (birth != DateTime.MinValue) dtBirth.Value = birth;

                        // set enclosure if available
                        if (!string.IsNullOrEmpty(eid) && cmbEnclosure.DataSource != null)
                        {
                            try { cmbEnclosure.SelectedValue = eid; } catch { }
                        }

                        // set keeper from EnclosureKeeper (if enclosure present)
                        if (!string.IsNullOrEmpty(eid) && cmbKeeper.DataSource != null)
                        {
                            try
                            {
                                using (SqlCommand cmd2 = new SqlCommand("SELECT keeper_id FROM EnclosureKeeper WHERE enclosure_id=@eid", conn))
                                {
                                    cmd2.Parameters.AddWithValue("@eid", eid);
                                    var val = cmd2.ExecuteScalar();
                                    if (val != null && val != DBNull.Value)
                                    {
                                        try { cmbKeeper.SelectedValue = val.ToString(); } catch { }
                                    }
                                }
                            }
                            catch { }
                        }

                        // Set type and species
                        if (!string.IsNullOrEmpty(typeId) && cmbType.DataSource != null)
                        {
                            try { cmbType.SelectedValue = typeId; } catch { }
                            // load species for that type
                            try { LoadSpecies(typeId); } catch { }
                        }

                        if (!string.IsNullOrEmpty(speciesId) && cmbSpecies.DataSource != null)
                        {
                            try { cmbSpecies.SelectedValue = speciesId; } catch { }
                        }
                    }
                }
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
            try
            {
                // 1. หาค่าต่างๆ เตรียมไว้ก่อน
                int newTypeID = GetTypeID(cmbType.Text);

                // ถ้า GetTypeID ส่งคืน 0 (ไม่ได้พิมพ์อะไร) ให้เซ็ตเป็น DBNull ถ้ามี ID ให้ใช้ค่านั้น
                object typeVal = newTypeID == 0 ? DBNull.Value : (object)newTypeID;

                // เติมบรรทัดนี้กลับเข้าไปครับ! 👇
                object enclosureVal = cmbEnclosure.SelectedValue ?? DBNull.Value;

                // ส่ง typeVal เข้าไปใน GetSpeciesID ด้วย เพื่อให้อัปเดตตาราง SpeciesInfo
                int speciesID = GetSpeciesID(cmbSpecies.Text);

                using (SqlConnection conn = connectDB.ConnectZooDB())
                {
                    SqlCommand cmd;

                    // 2. แยกระหว่าง Insert (เพิ่ม) และ Update (แก้ไข) รวบคำสั่งทีเดียวจบ!
                    if (animalId == 0)
                    {
                        // โหมดเพิ่มข้อมูลใหม่
                        string sql = @"INSERT INTO Animal(name, gender, birth_date, enclosure_id, species_info_id, animal_type_id) 
                               VALUES(@name, @gender, @birth, @enclosure, @species, @type); 
                               SELECT SCOPE_IDENTITY();";
                        cmd = new SqlCommand(sql, conn);
                    }
                    else
                    {
                        // โหมดแก้ไขข้อมูล
                        string sql = @"UPDATE Animal 
                               SET name=@name, gender=@gender, birth_date=@birth, 
                                   enclosure_id=@enclosure, species_info_id=@species, animal_type_id=@type 
                               WHERE animal_id=@id";
                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", animalId);
                    }

                    // 3. แนบค่าตัวแปรทั้งหมด (ใช้ชุดเดียวกันได้เลย)
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@gender", cbGender.Text);
                    cmd.Parameters.AddWithValue("@birth", dtBirth.Value);
                    cmd.Parameters.AddWithValue("@enclosure", enclosureVal);
                    cmd.Parameters.AddWithValue("@species", speciesID);
                    cmd.Parameters.AddWithValue("@type", typeVal);

                    // 4. สั่งรันคำสั่ง SQL
                    if (animalId == 0)
                    {
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

                    // 5. อัปเดตข้อมูลผู้ดูแล (EnclosureKeeper) ยังคงใช้ลอจิกเดิมของคุณครับ
                    if (enclosureVal != DBNull.Value)
                    {
                        var enclId = enclosureVal.ToString();
                        object keeperVal = cmbKeeper.SelectedValue ?? DBNull.Value;

                        using (SqlCommand cmdChk = new SqlCommand("SELECT COUNT(*) FROM EnclosureKeeper WHERE enclosure_id=@eid", conn))
                        {
                            cmdChk.Parameters.AddWithValue("@eid", enclId);
                            int cnt = Convert.ToInt32(cmdChk.ExecuteScalar());
                            if (cnt > 0)
                            {
                                using (SqlCommand cmdUpd = new SqlCommand("UPDATE EnclosureKeeper SET keeper_id=@kid WHERE enclosure_id=@eid", conn))
                                {
                                    cmdUpd.Parameters.AddWithValue("@kid", keeperVal);
                                    cmdUpd.Parameters.AddWithValue("@eid", enclId);
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                using (SqlCommand cmdIns = new SqlCommand("INSERT INTO EnclosureKeeper(enclosure_id, keeper_id) VALUES(@eid,@kid)", conn))
                                {
                                    cmdIns.Parameters.AddWithValue("@eid", enclId);
                                    cmdIns.Parameters.AddWithValue("@kid", keeperVal);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("บันทึกข้อมูลสำเร็จ!");
                try { DataEvents.RaiseAnimalsChanged(); } catch { }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        // เปลี่ยนให้รับค่า typeId เข้ามาด้วย
        private int GetSpeciesID(string speciesName)
        {
            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                string checkSQL = "SELECT species_info_id FROM SpeciesInfo WHERE common_name=@name";

                SqlCommand checkCmd = new SqlCommand(checkSQL, conn);
                checkCmd.Parameters.AddWithValue("@name", speciesName);

                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                string insertSQL = @"INSERT INTO SpeciesInfo(common_name) OUTPUT INSERTED.species_info_id VALUES(@name)";

                SqlCommand insertCmd = new SqlCommand(insertSQL, conn);
                insertCmd.Parameters.AddWithValue("@name", speciesName);

                return (int)insertCmd.ExecuteScalar();
            }
        }

        private int GetTypeID(string typeName)
        {
            // ถ้าไม่ได้พิมพ์อะไรเลย ให้ส่งค่า 0 กลับไป
            if (string.IsNullOrWhiteSpace(typeName)) return 0;

            using (SqlConnection conn = connectDB.ConnectZooDB())
            {
                // 1. เช็คว่ามีประเภทสัตว์ชื่อนี้ในตาราง AnimalType หรือยัง
                string checkSQL = "SELECT animal_type_id FROM AnimalType WHERE type_name=@name";
                SqlCommand checkCmd = new SqlCommand(checkSQL, conn);
                checkCmd.Parameters.AddWithValue("@name", typeName.Trim());

                object result = checkCmd.ExecuteScalar();

                // ถ้ามีแล้ว ให้เอา ID เดิมมาใช้
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                // 2. ถ้ายังไม่มี ให้ Insert เข้าไปใหม่ แล้วดึง ID ใหม่กลับมา
                string insertSQL = @"INSERT INTO AnimalType(type_name) 
                             OUTPUT INSERTED.animal_type_id 
                             VALUES(@name)";
                SqlCommand insertCmd = new SqlCommand(insertSQL, conn);
                insertCmd.Parameters.AddWithValue("@name", typeName.Trim());

                return (int)insertCmd.ExecuteScalar();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}