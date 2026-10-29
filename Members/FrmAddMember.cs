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

            if (_Member == null)
            {
                _Member = new clsMember();
            }

            if (_Member.PersonInfo == null)
            {
                _Member.PersonInfo = new clsPerson();
            }
            int PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (PersonID != -1)
            {
                _Member.PersonID = PersonID;
            }

            _Member.JoinDate = DateTime.Now;
            _Member.IsActive = true;
            _Member.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_Member.PersonInfo.Save())
            {
                MessageBox.Show("Error: Person Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Member.PersonID = _Member.PersonInfo.PersonID;

            if (!_Member.Save())
            {
                MessageBox.Show("Error: Member Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsSubscriptions subscription = new clsSubscriptions();

            if (SubscriptionPlanCB.SelectedValue != null)
                subscription.PlanID = (int)SubscriptionPlanCB.SelectedValue;

            subscription.MemberID = _Member.MemberID;

            if (TrainerCB.SelectedValue != null)
                subscription.TrainerID = (int)TrainerCB.SelectedValue;
            else
                subscription.TrainerID = -1;

            if (SportCB.SelectedValue != null)
                subscription.SportID = (int)SportCB.SelectedValue;

            subscription.StartDate = DateTime.Now;

            clsSubscriptionPlans selectedPlan = clsSubscriptionPlans.Find(subscription.PlanID);
            if (selectedPlan != null && selectedPlan.DurationInMonths.HasValue)
            {
                subscription.EndDate = DateTime.Now.AddMonths(selectedPlan.DurationInMonths.Value);
            }
            else
            {
                subscription.EndDate = DateTime.Now.AddMonths(1);
            }

            subscription.IsActive = true;

            if (subscription.Save())
            {
                MessageBox.Show($"Member and Subscription Saved Successfully.\nMember ID: {_Member.MemberID}\nMember Code: {_Member.MemberCode}",
                                        "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information); lblMemberID.Text = _Member.MemberID.ToString();
                lblMemberCode.Text = _Member.MemberCode.ToString();
                lblMemberID.Text = _Member.MemberID.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Member was saved successfully, but the Subscription failed to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
