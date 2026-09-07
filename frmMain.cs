using GymSystem.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public class DarkThemeColors : ProfessionalColorTable
        {
         
            public override Color MenuBorder => Color.FromArgb(45, 45, 60);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(45, 45, 60);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(45, 45, 60);
            public override Color MenuItemPressedGradientMiddle => Color.FromArgb(45, 45, 60);

   
            public override Color MenuItemSelected => Color.FromArgb(59, 130, 246);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(59, 130, 246);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(59, 130, 246);

           
            public override Color ToolStripDropDownBackground => Color.FromArgb(35, 35, 48);
        }
        public class ModernMenuRenderer : ToolStripProfessionalRenderer
        {
            public ModernMenuRenderer() : base(new DarkThemeColors()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
            
                e.TextColor = Color.White;
                base.OnRenderItemText(e);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           
            menuStrip1.Renderer = new ModernMenuRenderer();
            // لإخفاء الهامش الأبيض في القوائم المنسدلة للـ MenuStrip
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.HasDropDownItems)
                {
                    ((ToolStripDropDownMenu)item.DropDown).ShowImageMargin = false;
                }
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblRecordsCount_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timelbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
            Datelbl.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Timelbl_Click(object sender, EventArgs e)
        {

        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void mangeMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddUpdateTrainer frm = new FrmAddUpdateTrainer();
            frm.ShowDialog();
        }
    }
}
