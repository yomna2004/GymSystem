using GymSystem.Global_Classes;
using GymSystem_Business;
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
    public partial class loginfrm : Form
    {
        public loginfrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text, txtPassword.Text);
            if(user != null )
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text, txtPassword.Text);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain();
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginfrm_Load(object sender, EventArgs e)
        {
            string username = "", password = "";
            if(clsGlobal.GetStoredCredential(ref  username, ref password)) 
            {
                txtUserName.Text = username;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked= false;
            }
        }
    }
}
