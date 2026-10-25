using GymSystem.Global_Classes;
using GymSystem.People.controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace GymSystem.People
{
    public partial class AddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);


        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };
        private enMode _Mode;
        private int _PersonID = -1;

        clsPerson _person;
        public AddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
        }
        public AddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        private void _ResetDefaultValues()
        {
            

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
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
            _person = clsPerson.Find(_PersonID);

            if (_person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblPersonID.Text = _person.PersonID.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;
            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            txtPhone.Text = _person.Phone;

            if (_person.Gender == (short)enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrEmpty(_person.ImagePath))
            {
                pbPersonImage.ImageLocation = _person.ImagePath;
            }

            llRemoveImage.Visible = !string.IsNullOrEmpty(_person.ImagePath);
        }
        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
           _ResetDefaultValues();
            
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        private bool _HandlePersonImage()
        {
            if (_person.ImagePath != null && _person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
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

            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.Gender = rbMale.Checked ? (short)enGender.Male : (short)enGender.Female;
            _person.Address = txtAddress.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = txtPhone.Text.Trim();
            _person.Email = txtEmail.Text.Trim();
            _person.ImagePath = !string.IsNullOrEmpty(pbPersonImage.ImageLocation) ? pbPersonImage.ImageLocation : "";

            if (_person.Save())
            {
                MessageBox.Show("Person Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _person.PersonID); 
                this.Close(); 
            }
            else
            {
               
                MessageBox.Show("Error: Person Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
