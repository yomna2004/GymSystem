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
    public partial class FrmUpdateMember : Form
    {
        private int _MemberID;
        private clsMember _Member;

        public enum enGender { Male = 0, Female = 1 };

        public FrmUpdateMember(int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
        }
        private void _LoadData()
        {
            _Member = clsMember.FindByID(_MemberID);
            if(_Member != null)
            {
                lblMemberID.Text = _Member.MemberID.ToString();
                lblMemberCode.Text = _Member.MemberCode.ToString();
                txtFirstName.Text = _Member.PersonInfo.FirstName;
                txtSecondName.Text = _Member.PersonInfo.SecondName;
                txtThirdName.Text = _Member.PersonInfo.ThirdName;
                txtLastName.Text = _Member.PersonInfo.LastName;
                txtNationalNo.Text = _Member.PersonInfo.NationalNo;
                txtEmail.Text = _Member.PersonInfo.Email;
                txtAddress.Text = _Member.PersonInfo.Address;
                txtPhone.Text = _Member.PersonInfo.Phone;
                lblJoinDate.Text = _Member.JoinDate.ToString();
                dtpDateOfBirth.Value = _Member.PersonInfo.DateOfBirth;
                if(_Member.PersonInfo.Gender == 0)
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
                IsActiveCB.SelectedIndex = _Member.IsActive ? 0 : 1;

            }
        }
        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            _LoadData();
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

            // 2. التأكد من أن كائن العضو موجود (وضع التعديل)
            if (_Member == null)
            {
                MessageBox.Show("Error: No member data loaded for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Member.PersonInfo == null)
            {
                _Member.PersonInfo = new clsPerson();
            }

            // 3. معالجة وتخزين صورة الشخص
            if (!_HandlePersonImage())
            {
                return;
            }

            // 4. تعبئة بيانات الشخص الأساسية من الحقول
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

            _Member.IsActive = (IsActiveCB.SelectedIndex == 0); // 0 تعني Active و 1 تعني Inactive
            _Member.CreatedByUserID = clsGlobal.CurrentUser.UserID; // المستخدم الحالي الذي قام بالتعديل

            // 6. حفظ بيانات الشخص أولاً
            if (!_Member.PersonInfo.Save())
            {
                MessageBox.Show("Error: Person Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 7. حفظ بيانات العضو (سيكون وضع التعديل Update لأن الكائن تم جلبه مسبقاً)
            if (!_Member.Save())
            {
                MessageBox.Show("Error: Member Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
