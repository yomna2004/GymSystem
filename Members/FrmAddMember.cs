using GymSystem.Global_Classes;
using GymSystem.Properties;
using GymSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem.Members
{
    public partial class FrmAddMember : Form
    {
        private clsMember _Member;
        public FrmAddMember()
        {
            InitializeComponent();
        }


        private void _FillSportsComboBox()
        {
            DataTable dtSpecializations = clsSpecialization.GetAllSpecializations();

            SportCB.DataSource = dtSpecializations;
            SportCB.DisplayMember = "SpecializationName";
            SportCB.ValueMember = "SpecializationID";

            if (SportCB.Items.Count > 0)
                SportCB.SelectedIndex = 0;
        }
        private void _FillTrainersComboBox()
        {
            if (SportCB.SelectedValue == null)
            {
                TrainerCB.DataSource = null;
                return;
            }

            int specializationId = -1;

            if (int.TryParse(SportCB.SelectedValue.ToString(), out specializationId))
            {
                DataTable dtNames = clsTrainersAttendanceLog.GetTrainersBySpecialization(specializationId);

                TrainerCB.DataSource = null;

                if (dtNames != null && dtNames.Rows.Count > 0)
                {
                    TrainerCB.DisplayMember = "FullName";
                    TrainerCB.ValueMember = "TrainerID";
                    TrainerCB.DataSource = dtNames;
                    TrainerCB.SelectedIndex = 0;
                }
            }
            else
            {
                clsSpecialization specialization = clsSpecialization.FindBySpecializationName(SportCB.Text.Trim());

                if (specialization != null)
                {
                    DataTable dtNames = clsTrainersAttendanceLog.GetTrainersBySpecialization(specialization.SpecializationID);

                    TrainerCB.DataSource = null;

                    if (dtNames != null && dtNames.Rows.Count > 0)
                    {
                        TrainerCB.DisplayMember = "FullName";
                        TrainerCB.ValueMember = "TrainerID";
                        TrainerCB.DataSource = dtNames;
                        TrainerCB.SelectedIndex = 0;
                    }
                }
                else
                {
                    TrainerCB.DataSource = null;
                }
            }
        }
        private void _FillSubscriptionPlanComboBox()
        {
            DataTable dtSubscribtions = clsSubscriptionPlans.GetAllPlans();
            SubscriptionPlanCB.DataSource = dtSubscribtions;
            SubscriptionPlanCB.DisplayMember = "PlanName";
            SubscriptionPlanCB.ValueMember = "PlanID";

            if (SubscriptionPlanCB.Items.Count > 0)
                SubscriptionPlanCB.SelectedIndex = 0;
        }

        private void FrmAddUpdateMember_Load(object sender, EventArgs e)
        {
            _FillSubscriptionPlanComboBox();
            _FillSportsComboBox();

        }


        private void SportCB_SelectedValueChanged(object sender, EventArgs e)
        {
            _FillTrainersComboBox();
        }

        private void SubscriptionPlanCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SubscriptionPlanCB.SelectedValue == null)
                return;
            string PlanName = SubscriptionPlanCB.Text.Trim();
            clsSubscriptionPlans subscriptionPlan = clsSubscriptionPlans.Find(PlanName);

            if (subscriptionPlan != null)
            {
                lblSubscriptionPrice.Text = subscriptionPlan.Price.ToString();

                if (subscriptionPlan.ClassesCount != null)
                {
                    lblClassesCount.Text = subscriptionPlan.ClassesCount.ToString();
                }
                else
                {
                    lblClassesCount.Text = "Unlimited";
                }
            }
            else
            {
                lblSubscriptionPrice.Text = "N/A";
                lblClassesCount.Text = "N/A";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int personID = ctrlPersonCardWithFilter1.PersonID;

            if (personID == -1)
            {
                MessageBox.Show("Please select or add a person first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Member == null)
            {
                _Member = new clsMember();
            }

            _Member.PersonID = personID;
            _Member.JoinDate = DateTime.Now;
            _Member.IsActive = true;
            _Member.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            int planID = SubscriptionPlanCB.SelectedValue != null ? (int)SubscriptionPlanCB.SelectedValue : -1;
            int trainerID = TrainerCB.SelectedValue != null ? (int)TrainerCB.SelectedValue : -1;
            int sportID = SportCB.SelectedValue != null ? (int)SportCB.SelectedValue : -1;

            clsSubscriptionPlans selectedPlan = clsSubscriptionPlans.Find(planID);
            int amountPaid = (selectedPlan != null) ? (int)selectedPlan.Price : 0; 

            int memberID = _Member.SaveComplete(
                clsGlobal.CurrentUser.UserID,
                planID,
                trainerID,
                sportID,
                amountPaid
            );

            if (memberID != -1)
            {
                MessageBox.Show($"Member, Subscription, and Payment Saved Successfully.\nMember ID: {_Member.MemberID}\nMember Code: {_Member.MemberCode}",
                                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMemberCode.Text = _Member.MemberCode.ToString();
                SportCB.Enabled = false;
                TrainerCB.Enabled = false;
                SubscriptionPlanCB.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Failed to save Member, Subscription or Payment data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

