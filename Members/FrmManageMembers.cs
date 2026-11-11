using GymSystem.Trainers;
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

namespace GymSystem.Members
{
    public partial class FrmManageMembers : Form
    {
        private DataTable _dtMembers = clsMember.GetAllMembers();
        public FrmManageMembers()
        {
            InitializeComponent();
        }
        private void _RefreshMemberList()
        {
            _dtMembers = clsMember.GetAllMembers(); 

            dgvMembers.DataSource = _dtMembers;

            lblRecordsCount.Text = dgvMembers.Rows.Count.ToString();
        }
        private void FrmManageMembers_Load(object sender, EventArgs e)
        {
            dgvMembers.DataSource = _dtMembers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtMembers.DefaultView.Count.ToString();
            dgvMembers.AllowUserToAddRows = false;
            if (dgvMembers.Rows.Count > 0)
            {
                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvMembers.Columns[0].HeaderText = "Member ID";
                dgvMembers.Columns[0].FillWeight = 70;

                dgvMembers.Columns[1].HeaderText = "Member Code";
                dgvMembers.Columns[1].FillWeight = 120;

                dgvMembers.Columns[2].HeaderText = "Full Name";
                dgvMembers.Columns[2].FillWeight = 200;
                dgvMembers.Columns[3].HeaderText = "Phone";
                dgvMembers.Columns[3].FillWeight = 100;

                dgvMembers.Columns[4].HeaderText = "Join Date";
                dgvMembers.Columns[4].FillWeight = 110;

                dgvMembers.Columns[5].HeaderText = "Is Active";
                dgvMembers.Columns[5].FillWeight = 60;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Member Code":
                    FilterColumn = "MemberCode";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtMembers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtMembers.DefaultView.Count.ToString();
                return;
            }
            else
            {
                _dtMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);

            }
            lblRecordsCount.Text = _dtMembers.DefaultView.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    _dtMembers.DefaultView.RowFilter = "";
                    break;
                case "Yes":
                    _dtMembers.DefaultView.RowFilter = "[IsActive] = true";
                    break;
                case "No":
                    _dtMembers.DefaultView.RowFilter = "[IsActive] = false";
                    break;
            }
            lblRecordsCount.Text = _dtMembers.DefaultView.Count.ToString();
        }

        private void dgvMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMembers.Rows.Count)
            {


                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];


                if (row.Cells[5].Value != null)
                {
                    bool isActive = Convert.ToBoolean(row.Cells[5].Value);

                    if (!isActive)
                    {

                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 225, 225);


                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {

                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void AddMemberbtn_Click(object sender, EventArgs e)
        {
            FrmAddMember frm = new FrmAddMember();
            frm.ShowDialog();
            _RefreshMemberList();
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)dgvMembers.CurrentRow.Cells[0].Value;
            FrmUpdateMember frm = new FrmUpdateMember(MemberID);
            frm.ShowDialog();
        }

       
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsMember.FindByID((int)dgvMembers.CurrentRow.Cells[0].Value).PersonID;
            FrmShowTrainerInfo frm = new FrmShowTrainerInfo(PersonID);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
                cbIsActive.Visible = false;
            }
            if (cbFilterBy.Text == "IsActive")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
            }
            else
                txtFilterValue.Enabled = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Deactivate that Member [" + dgvMembers.CurrentRow.Cells[0].Value + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsMember.FindByID((int)dgvMembers.CurrentRow.Cells[0].Value).IsActive == false)
                {
                    MessageBox.Show("Member is Already Deactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (clsMember.DeactivateMember((int)dgvMembers.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Member Deactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshMemberList();
                    }
                    else
                        MessageBox.Show("Member did not Deactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
        }

        private void reactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Reactivate that Member [" + dgvMembers.CurrentRow.Cells[0].Value + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsMember.FindByID((int)dgvMembers.CurrentRow.Cells[0].Value).IsActive == true)
                {
                    MessageBox.Show("Member is Already Activated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (clsMember.ReactivateMember((int)dgvMembers.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Member Reactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshMemberList();
                    }
                    else
                        MessageBox.Show("Member did not Reactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }
    }
}