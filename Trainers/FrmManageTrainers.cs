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

namespace GymSystem.People
{
    public partial class FrmManageTrainers : Form
    {
        private DataTable _dtTrainers = clsTrainers.GetAllTrainers();
        public FrmManageTrainers()
        {
            InitializeComponent();
        }
        private void _RefreshTrainersList()
        {
          
            _dtTrainers = clsTrainers.GetAllTrainers();
            dgvTrainers.DataSource = _dtTrainers;

            lblRecordsCount.Text = _dtTrainers.Rows.Count.ToString();
        }
        private void FrmManageStuff_Load(object sender, EventArgs e)
        {
            dgvTrainers.DataSource = _dtTrainers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtTrainers.DefaultView.Count.ToString();
            dgvTrainers.AllowUserToAddRows = false;
            if (dgvTrainers.Rows.Count > 0)
            {
                dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                dgvTrainers.Columns[0].HeaderText = "Full Name";
                dgvTrainers.Columns[0].FillWeight = 200;

                dgvTrainers.Columns[1].HeaderText = "Trainer ID";
                dgvTrainers.Columns[1].FillWeight = 70;

                dgvTrainers.Columns[2].HeaderText = "Person ID";
                dgvTrainers.Columns[2].Width = 70;
                dgvTrainers.Columns[2].FillWeight = 70;

                dgvTrainers.Columns[3].HeaderText = "Specialization Name";
                dgvTrainers.Columns[3].FillWeight = 140;

                dgvTrainers.Columns[4].HeaderText = "Is Active";
                dgvTrainers.Columns[4].FillWeight = 60;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilterBy.Text)
            {
                case "Trainer ID":
                    FilterColumn = "Trainer ID";
                    break;
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "Specialization Name":
                    FilterColumn = "Specialization Name";
                    break;
                case "Full Name":
                    FilterColumn = "Full Name";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtTrainers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtTrainers.DefaultView.Count.ToString();
                return;
            }
            if(FilterColumn != "Specialization Name" && FilterColumn != "Full Name")
            {
                _dtTrainers.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn,txtFilterValue.Text);
            }
            else
            {
                _dtTrainers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text);
            }
            lblRecordsCount.Text = _dtTrainers.DefaultView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
           
            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
                cbIsActive.Visible = false;
            }
            if(cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
            }
            else
                txtFilterValue.Enabled = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Trainer ID" || cbFilterBy.Text == "PersonID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvTrainers.CurrentRow.Cells[2].Value;
            FrmShowTrainerInfo frm = new FrmShowTrainerInfo(PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerID = (int)dgvTrainers.CurrentRow.Cells[1].Value;
            FrmAddUpdateTrainer frm = new FrmAddUpdateTrainer(TrainerID);
            frm.ShowDialog();
            _RefreshTrainersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Trainer [" + dgvTrainers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsTrainers.DeleteTrainer((int)dgvTrainers.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Trainer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTrainersList();
                }
                else
                    MessageBox.Show("Trainer was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTrainerbtn_Click(object sender, EventArgs e)
        {
            FrmAddUpdateTrainer frm = new FrmAddUpdateTrainer();
            frm.ShowDialog();
            _RefreshTrainersList();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbIsActive.Text;
            switch(FilterValue)
            {
                case "All":
                    _dtTrainers.DefaultView.RowFilter = "";
                    break;
                case "Yes":
                    _dtTrainers.DefaultView.RowFilter = "[IsActive] = true";
                    break;
                case "No":
                    _dtTrainers.DefaultView.RowFilter = "[IsActive] = false";
                    break;
            }
            lblRecordsCount.Text = _dtTrainers.DefaultView.Count.ToString(); 
        }

        private void reactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Reactivate that Trainer [" + dgvTrainers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsTrainers.Reactivate((int)dgvTrainers.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Trainer Reactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTrainersList();
                }
                else
                    MessageBox.Show("Trainer did not Reactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Deactivate that Trainer [" + dgvTrainers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsTrainers.Deactivate((int)dgvTrainers.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Trainer Deactivated Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTrainersList();
                }
                else
                    MessageBox.Show("Trainer did not Deactivated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
