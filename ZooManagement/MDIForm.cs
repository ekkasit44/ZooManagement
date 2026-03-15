namespace ZooManagement
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }
        private void ToolStripSearchButton_Click(object sender, EventArgs e)
        {
            ForwardSearchToActiveChild();
        }

        private void ToolStripSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ForwardSearchToActiveChild();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ForwardSearchToActiveChild()
        {
            try
            {
                var txt = toolStripSearchText.Text.Trim();
                if (string.IsNullOrEmpty(txt)) return;

                if (this.ActiveMdiChild is ISearchable searchable)
                {
                    searchable.Search(txt);
                }
                else
                {
                    // optionally broadcast to all children that support ISearchable
                    foreach (Form child in this.MdiChildren)
                    {
                        if (child is ISearchable s)
                        {
                            s.Search(txt);
                        }
                    }
                }
            }
            catch { }
        }

        private void MDIForm_Resize(object sender, EventArgs e)
        {
            // Make active MDI child fill the client area below the menu/tool strips
            foreach (Form child in this.MdiChildren)
            {
                child.WindowState = FormWindowState.Maximized;
            }
        }
        private void mnuMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void mnuMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }







        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuNomalF_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void mnuCloseF_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {

                this.MdiChildren[0].Close();
            }
        }

        private void mnuCloseAllF_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }














        private void mnuAnimalType_Click(object sender, EventArgs e)
        {
            AnimalTypeForm fE = new AnimalTypeForm();
            fE.MdiParent = this;
            fE.Show();
        }

        // Toolstrip button handlers
        private void toolBtnAnimal_Click(object sender, EventArgs e)
        {
            mnuAnimal_Click(sender, e);
        }
        private void toolBtnAnimalType_Click(object sender, EventArgs e)
        {
            mnuAnimalType_Click(sender, e);
        }
        private void toolBtnSpecies_Click(object sender, EventArgs e)
        {
            mnuSpeciesInfo_Click(sender, e);
        }
        private void toolBtnEnclosure_Click(object sender, EventArgs e)
        {
            mnuEnclosure_Click(sender, e);
        }
        private void toolBtnKeeper_Click(object sender, EventArgs e)
        {
            mnuKeeper_Click(sender, e);
        }
        private void toolBtnFood_Click(object sender, EventArgs e)
        {
            mnuFood_Click(sender, e);
        }
        private void toolBtnFeeding_Click(object sender, EventArgs e)
        {
            mnuFD_Click(sender, e);
        }
        private void toolBtnRefresh_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is Form f)
            {
                // try to invoke a Refresh button if exists
                var mi = f.GetType().GetMethod("btnRefresh_Click", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (mi != null)
                {
                    mi.Invoke(f, new object[] { null, EventArgs.Empty });
                }
            }
        }

        private void mnuSpeciesInfo_Click(object sender, EventArgs e)
        {
            SpeciesInfoForm FC = new SpeciesInfoForm();
            FC.MdiParent = this;
            FC.Show();
        }

        private void mnuEnclosure_Click(object sender, EventArgs e)
        {
            EnclosureForm fPC = new EnclosureForm();
            fPC.MdiParent = this;
            fPC.Show();
        }

        private void mnuKeeper_Click(object sender, EventArgs e)
        {
            KeeperForm fES = new KeeperForm();
            fES.MdiParent = this;
            fES.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ShowMenuStart();
        }








        private void MDIForm_Load(object sender, EventArgs e)
        {
            ShowMenuStart();
        }






        private void mnuFood_Click(object sender, EventArgs e)
        {
            FoodForm fFood = new FoodForm();
            fFood.MdiParent = this;
            fFood.Show();
        }


        private void ShowMenuStart()
        {

            mnuF.Enabled = true;

            mnuArrangeF.Enabled = true;
        }

        private void mnuAnimal_Click(object sender, EventArgs e)
        {
            // เช็คว่ามีฟอร์ม AnimalForm เปิดอยู่หรือยัง
            foreach (Form child in this.MdiChildren)
            {
                if (child is AnimalForm)
                {
                    child.Activate(); // ถ้ามีแล้วให้ดึงขึ้นมาหน้าสุด
                    return;
                }
            }

            AnimalForm fP = new AnimalForm();
            fP.MdiParent = this;
            fP.Show();


        }

        private void mnuFD_Click(object sender, EventArgs e)
        {
            FeedingScheduleForm mnuFD = new FeedingScheduleForm();
            mnuFD.MdiParent = this;
            mnuFD.Show();
        }

        private void ขอมลอาหารToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodForm mnuFood = new FoodForm();
            mnuFood.MdiParent = this;
            mnuFood.Show();
        }

        private void รายงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm mnuReport = new ReportForm();
            mnuReport.MdiParent = this;
            mnuReport.Show();
        }
    }
}

