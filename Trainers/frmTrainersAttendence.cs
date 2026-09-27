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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymSystem.People
{
    public partial class frmTrainersAttendence : Form
    {
        private DataTable _dtTodayAttendanceLogs = clsTrainersAttendanceLog.GetAllTodayAttendanceLogs();

        clsTrainersAttendanceLog log;
        public frmTrainersAttendence()
        {
            InitializeComponent();
        }
        private void _FillSpecializationsComboBox()
        {
            DataTable dtSpecializations = clsSpecialization.GetAllSpecializations();

            SpecializationsCb.DataSource = dtSpecializations;
            SpecializationsCb.DisplayMember = "SpecializationName";
            SpecializationsCb.ValueMember = "SpecializationID";

            if (SpecializationsCb.Items.Count > 0)
                SpecializationsCb.SelectedIndex = 0;
        }
        private void _FillNamesComboBox()
        {
            if (SpecializationsCb.SelectedValue == null)
            {
                NamesCB.DataSource = null;
                return;
            }

            int specializationId = -1;

            if (int.TryParse(SpecializationsCb.SelectedValue.ToString(), out specializationId))
            {
                DataTable dtNames = clsTrainersAttendanceLog.GetTrainersBySpecialization(specializationId);

                NamesCB.DataSource = null;

                if (dtNames != null && dtNames.Rows.Count > 0)
                {
                    NamesCB.DisplayMember = "FullName";
                    NamesCB.ValueMember = "TrainerID";
                    NamesCB.DataSource = dtNames;
                    NamesCB.SelectedIndex = 0;
                }
            }
            else
            {
                clsSpecialization specialization = clsSpecialization.FindBySpecializationName(SpecializationsCb.Text.Trim());

                if (specialization != null)
                {
                    DataTable dtNames = clsTrainersAttendanceLog.GetTrainersBySpecialization(specialization.SpecializationID);

                    NamesCB.DataSource = null;

                    if (dtNames != null && dtNames.Rows.Count > 0)
                    {
                        NamesCB.DisplayMember = "FullName";
                        NamesCB.ValueMember = "TrainerID";
                        NamesCB.DataSource = dtNames;
                        NamesCB.SelectedIndex = 0;
                    }
                }
                else
                {
                    NamesCB.DataSource = null;
                }
            }
        }

        private void _UpdateRecordsCount()
        {
            lblRecordsCount.Text = _dtTodayAttendanceLogs.DefaultView.Count.ToString();
        }
        private void frmTrainersAttendence_Load(object sender, EventArgs e)
        {
            dgvTrainers.DataSource = _dtTodayAttendanceLogs;
            cbSearchBy.SelectedIndex = 0;
            lblRecordsCount.Text = _dtTodayAttendanceLogs.DefaultView.Count.ToString();
            dgvTrainers.AllowUserToAddRows = false;
            if (dgvTrainers.Rows.Count > 0)
            {
                dgvTrainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvTrainers.Columns.Contains("CheckInDate"))
                    dgvTrainers.Columns["CheckInDate"].HeaderText = "Check-In Time";

                if (dgvTrainers.Columns.Contains("CheckOutDate"))
                    dgvTrainers.Columns["CheckOutDate"].HeaderText = "Check-Out Time";

                if (dgvTrainers.Columns.Contains("Status"))
                    dgvTrainers.Columns["Status"].HeaderText = "Status";

                if (dgvTrainers.Columns.Contains("CreatedByUserID"))
                    dgvTrainers.Columns["CreatedByUserID"].Visible = false;
            }

        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Clear();

            txtSearchValue.Visible = false;
            SpecializationsCb.Visible = false;
            Namelbl.Visible = false;
            NamesCB.Visible = false;
            switch (cbSearchBy.Text)
            {
                case "None":
                    
                    break;
                case "Trainer ID":
                    txtSearchValue.Visible = true;
                   
                    break;
                case "Full Name":
                    txtSearchValue.Visible = true;
                    txtSearchValue.Focus();
                    break;
                case "Specialization":
                    SpecializationsCb.Visible = true;
                    _FillSpecializationsComboBox();
                    Namelbl.Visible = true;
                    NamesCB.Visible = true;
                    break;
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (cbSearchBy.Text == "None")
            {
                MessageBox.Show("Please select a search method first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsTrainers trainer = null;
            int trainerId = -1;

            switch (cbSearchBy.Text)
            {
                case "Trainer ID":
                    if (int.TryParse(txtSearchValue.Text.Trim(), out trainerId))
                    {
                        trainer = clsTrainers.FindByTrainerID(trainerId);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric Trainer ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSearchValue.Focus();
                        return;
                    }
                    break;

                case "Full Name":
                    if (!string.IsNullOrWhiteSpace(txtSearchValue.Text))
                    {
                        trainer = clsTrainers.FindByFullName(txtSearchValue.Text.Trim());
                        if (trainer != null)
                        {
                            trainerId = trainer.TrainerID;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a Trainer Full Name to search.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSearchValue.Focus();
                        return;
                    }
                    break;

                case "Specialization":
                    if (NamesCB.SelectedValue != null && int.TryParse(NamesCB.SelectedValue.ToString(), out trainerId))
                    {
                        trainer = clsTrainers.FindByTrainerID(trainerId);
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid trainer from the names list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }
            clsTrainersAttendanceLog log = new clsTrainersAttendanceLog();
            log.TrainerID = trainerId;
            log.CheckInDate = DateTime.Now;
            log.CheckOutDate = null;
            log.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            log.Status = (byte)clsTrainersAttendanceLog.enAttendanceStatus.CheckedIn;

            if (log.Save())
            {
                MessageBox.Show($"Check-In successful for trainer: {trainer.PersonInfo.FullName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _dtTodayAttendanceLogs = clsTrainersAttendanceLog.GetAllTodayAttendanceLogs();

                dgvTrainers.DataSource = null;
                dgvTrainers.DataSource = _dtTodayAttendanceLogs;

                _UpdateRecordsCount();
            }
            else
            {
                MessageBox.Show("Failed to save Check-In record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpecializationsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FillNamesComboBox();
        }
    }
}
