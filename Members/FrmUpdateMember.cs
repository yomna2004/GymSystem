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


        public FrmUpdateMember(int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
        }
        private void _LoadData()
        {
            _Member = clsMember.FindByID(_MemberID);
            if( _Member != null )
            {
                ctrlPersonCard1.LoadPersonInfo(_Member.PersonID);
                lblMemberID.Text = _Member.MemberID.ToString();
                lblMemberCode.Text = _Member.MemberCode.ToString();
            }
            else
            {
                MessageBox.Show("Member Was Not Found");
            }
        }
        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Member == null || _Member.PersonInfo == null)
            {
                MessageBox.Show("Error: No member or person data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson updatedPerson = ctrlPersonCard1.SelectedPersonInfo; 

            if (updatedPerson != null)
            {
                _Member.PersonInfo = updatedPerson;
            }

            if (!_Member.PersonInfo.Save())
            {
                MessageBox.Show("Error: Person Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            MessageBox.Show("Person Data Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        } 
    }
}
