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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem.Members
{
    public partial class FrmAddMember : Form
    {
        public enum enGender { Male = 0, Female = 1 };

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

        private void _ResetDefaultValues()
        {

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-5);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtNationalNo.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rbMale.Checked = true;
        }

        

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;



            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        

        private void FrmAddUpdateMember_Load(object sender, EventArgs e)
        {
            _FillSubscriptionPlanComboBox();
            _FillSportsComboBox();
           _ResetDefaultValues();
        }

        private void SportCB_SelectedValueChanged(object sender, EventArgs e)
        {
            _FillTrainersComboBox();
        }

        private void SubscriptionPlanCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SubscriptionPlanCB.SelectedValue == null )
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
        private bool _HandlePersonImage()
        {
            if (_Member.PersonInfo != null && _Member.PersonInfo.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_Member.PersonInfo.ImagePath))
                {
                    try
                    {
                        File.Delete(_Member.PersonInfo.ImagePath);
                    }
                    catch { }
                }
            }

            if (pbPersonImage.ImageLocation != null)
            {
                string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                if (util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonImage.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
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

            if (!_HandlePersonImage())
            {
                return;
            }

            _Member.PersonInfo.FirstName = txtFirstName.Text.Trim();
            _Member.PersonInfo.SecondName = txtSecondName.Text.Trim();
            _Member.PersonInfo.ThirdName = txtThirdName.Text.Trim();
            _Member.PersonInfo.LastName = txtLastName.Text.Trim();
            _Member.PersonInfo.Email = txtEmail.Text.Trim();
            _Member.PersonInfo.NationalNo = txtNationalNo.Text.Trim();
            _Member.PersonInfo.Address = txtAddress.Text.Trim();
            _Member.PersonInfo.Phone = txtPhone.Text.Trim();
            _Member.PersonInfo.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _Member.PersonInfo.DateOfBirth = dtpDateOfBirth.Value;
            _Member.PersonInfo.ImagePath = pbPersonImage.ImageLocation ?? "";

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
                MessageBox.Show("Member and Subscription Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMemberID.Text = _Member.MemberID.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Member was saved successfully, but the Subscription failed to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 
        private void RequiredtxtBoxVaildating(object sender, CancelEventArgs e)
        {
            CustomTextBox temp = ((CustomTextBox)sender);
            if (!temp.IsVaild())
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(temp, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            RequiredtxtBoxVaildating(sender, e);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            RequiredtxtBoxVaildating(sender, e);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            RequiredtxtBoxVaildating(sender, e);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            RequiredtxtBoxVaildating(sender, e);
        }
    }
}
