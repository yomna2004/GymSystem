using GymSystem.Properties;
using GymSystem_Business;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem.People
{
    public partial class FrmAddUpdateTrainer : Form
    {
        public delegate void DataBackEventHandler(object sender, int TrainerID);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _TrainerID = -1;
        private clsTrainers _trainer;

        // Constructor for Add New
        public FrmAddUpdateTrainer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        // Constructor for Update
        public FrmAddUpdateTrainer(int TrainerID)
        {
            InitializeComponent();
            _TrainerID = TrainerID;
            _Mode = enMode.Update;
        }

        private void _FillSpecializationsComboBox()
        {
            DataTable dtSpecializations = clsSpecialization.GetAllSpecializations();

            comboBox1.DataSource = dtSpecializations;
            comboBox1.DisplayMember = "SpecializationName";
            comboBox1.ValueMember = "SpecializationID";

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void _ResetDefaultValues()
        {
            _FillSpecializationsComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Trainer";
                _trainer = new clsTrainers(); 
            }
            else
            {
                lblTitle.Text = "Update Trainer";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
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

        private void _LoadData()
        {
            _trainer = clsTrainers.FindByTrainerID(_TrainerID);

            if (_trainer == null)
            {
                MessageBox.Show("No Trainer with ID = " + _TrainerID, "Trainer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblTrainerID.Text = _trainer.TrainerID.ToString();
            txtFirstName.Text = _trainer.PersonInfo.FirstName;
            txtSecondName.Text = _trainer.PersonInfo.SecondName;
            txtThirdName.Text = _trainer.PersonInfo.ThirdName;
            txtLastName.Text = _trainer.PersonInfo.LastName;
            txtNationalNo.Text = _trainer.PersonInfo.NationalNo;
            txtEmail.Text = _trainer.PersonInfo.Email;
            txtAddress.Text = _trainer.PersonInfo.Address;
            dtpDateOfBirth.Value = _trainer.PersonInfo.DateOfBirth;
            txtPhone.Text = _trainer.PersonInfo.Phone;

            if (_trainer.PersonInfo.Gender == (short)enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

         
            if (_trainer.SpecializationID != -1)
            {
                comboBox1.SelectedValue = _trainer.SpecializationID;
            }

            if (!string.IsNullOrEmpty(_trainer.PersonInfo.ImagePath))
            {
                pbPersonImage.ImageLocation = _trainer.PersonInfo.ImagePath;
            }

            llRemoveImage.Visible = !string.IsNullOrEmpty(_trainer.PersonInfo.ImagePath);
        }

        private void FrmAddUpdateTrainer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private bool _HandlePersonImage()
        {
            if (_trainer.PersonInfo != null && _trainer.PersonInfo.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_trainer.PersonInfo.ImagePath))
                {
                    try
                    {
                        File.Delete(_trainer.PersonInfo.ImagePath);
                    }
                    catch { }
                }
            }

            if (pbPersonImage.ImageLocation != null)
            {
                string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
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

            
            if (!_HandlePersonImage())
            {
                return;
            }

           
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (_trainer.PersonInfo == null)
            {
                _trainer.PersonInfo = new clsPerson();
            }

           
            _trainer.PersonInfo.FirstName = txtFirstName.Text.Trim();
            _trainer.PersonInfo.SecondName = txtSecondName.Text.Trim();
            _trainer.PersonInfo.ThirdName = txtThirdName.Text.Trim();
            _trainer.PersonInfo.LastName = txtLastName.Text.Trim();
            _trainer.PersonInfo.NationalNo = txtNationalNo.Text.Trim();
            _trainer.PersonInfo.Gender = rbMale.Checked ? (short)enGender.Male : (short)enGender.Female;
            _trainer.PersonInfo.Address = txtAddress.Text.Trim();
            _trainer.PersonInfo.DateOfBirth = dtpDateOfBirth.Value;
            _trainer.PersonInfo.Phone = txtPhone.Text.Trim();
            _trainer.PersonInfo.Email = txtEmail.Text.Trim();

            _trainer.PersonInfo.ImagePath = !string.IsNullOrEmpty(pbPersonImage.ImageLocation) ? pbPersonImage.ImageLocation : "";

           
            if (!_trainer.PersonInfo.Save())
            {
                MessageBox.Show("Error: Person Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            _trainer.PersonID = _trainer.PersonInfo.PersonID;
            _trainer.SpecializationID = Convert.ToInt32(comboBox1.SelectedValue);
            
            
            if (_trainer.Save())
            {
                lblTrainerID.Text = _trainer.TrainerID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Trainer";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _trainer.TrainerID);
            }
            else
            {
                MessageBox.Show("Error: Trainer Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
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
