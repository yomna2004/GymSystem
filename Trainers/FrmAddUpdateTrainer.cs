using GymSystem.Global_Classes;
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

        
        public FrmAddUpdateTrainer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        
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
            ctrlPersonCardWithFilter1.LoadPersonInfo(_trainer.PersonID);
        }

        private void FrmAddUpdateTrainer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }


        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || !int.TryParse(comboBox1.SelectedValue.ToString(), out int specializationID))
            {
                MessageBox.Show("Please select a valid specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //_trainer.PersonID = ctrlPersonCardWithFilter1.PersonID;
            int PersonID = ctrlPersonCardWithFilter1.PersonID;
            if(PersonID != -1)
            {
                _trainer.PersonID = PersonID;
            }
           
            _trainer.SpecializationID = specializationID;
            if (_Mode == enMode.AddNew)
            {
                _trainer.HireDate = DateTime.Now;

            }
           
            _trainer.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            
            _trainer.IsActive = true;

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
    }

}
