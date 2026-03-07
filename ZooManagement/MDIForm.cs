namespace ZooManagement
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
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











        private void mnuAnimalform_Click(object sender, EventArgs e)
        {

        }

        

        private void mnuAnimalType_Click(object sender, EventArgs e)
        {
            AnimalTypeForm fE = new AnimalTypeForm();
            fE.MdiParent = this;
            fE.Show();
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
            //ShowMenuManager();
            //ShowMenuSale();
            ShowMenuStart();
        }








        private void MDIForm_Load(object sender, EventArgs e)
        {
            ShowMenuStart();
        }



        private void mnuEfrm_Click(object sender, EventArgs e)
        {

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
            mnuAnimalform.Enabled = true;
            mnuEfrm.Enabled = true;
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
    }
}

