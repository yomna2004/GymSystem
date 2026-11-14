using GymSystem.People.controls;
using GymSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem.Members
{
    public partial class FrmRenewSubscription : Form
    {
        private int _MemberID;
        private clsMember _Member;
        private clsSubscriptions _Subscription;
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;
        public FrmRenewSubscription(int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
            _Mode = enMode.Update;
        }
        public FrmRenewSubscription()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
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
        private void _LoadData()
        {
            _FillSportsComboBox();
            _FillSubscriptionPlanComboBox();
            _FillTrainersComboBox();
            _Member = clsMember.FindByID(_MemberID);
            if (_Member != null)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_Member.PersonID);
                lblMemberID.Text = _Member.MemberID.ToString();
                lblMemberCode.Text = _Member.MemberCode.ToString();
                
            }
            else
            {
                MessageBox.Show("Member Was Not Found");
            }
        }
        private void _ResetDefaultValues()
        {
            _FillSportsComboBox();
            _FillSubscriptionPlanComboBox();
            _FillTrainersComboBox();
            _Subscription = new clsSubscriptions();
            lblMemberID.Text = "N/A";
            lblMemberCode.Text = "N/A";
            lblClassesCount.Text = "??";
            lblSubscriptionPrice.Text = "??";
        }
        private void FrmRenewSubscription_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
            else
            {
                _ResetDefaultValues();
            }
        }
    }
}
