using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem_DataAccess;
namespace GymSystem_Business
{
    public class clsTrainers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TrainerID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int SpecializationID { get; set; }
        public clsSpecialization SpecializationInfo { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public clsTrainers()
        {
            this.TrainerID = -1;
            this.PersonID = -1;
            this.SpecializationID = -1;
            this.HireDate = DateTime.Now;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsTrainers(int TrainerID, int PersonID, int SpecializationID, DateTime HireDate, bool IsActive)
        {
            this.TrainerID = TrainerID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.SpecializationID = SpecializationID;
            this.SpecializationInfo = clsSpecialization.FindBySpecializationID(SpecializationID);
            this.HireDate = HireDate;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewTrainer()
        {
            this.TrainerID = clsTrainersData.AddNewTrainer(this.PersonID, this.SpecializationID, this.HireDate, this.IsActive);
            return (this.TrainerID != -1);
        }

        private bool _UpdateTrainer()
        {
            return clsTrainersData.UpdateTrainer(this.TrainerID, this.PersonID, this.SpecializationID, this.HireDate, this.IsActive);
        }

        public static bool DeleteTrainer(int TrainerID)
        {
            return clsTrainersData.DeleteTrainer(TrainerID);
        }

        public static clsTrainers FindByTrainerID(int TrainerID)
        {
            int PersonID = -1; int SpecializationID = -1; DateTime HireDate = DateTime.Now; bool IsActive = true;

            if (clsTrainersData.GetTrainerInfoByID(TrainerID, ref PersonID, ref SpecializationID, ref HireDate, ref IsActive))
            {
                return new clsTrainers(TrainerID, PersonID, SpecializationID, HireDate, IsActive);
            }
            return null;
        }

        public static clsTrainers FindByPersonID(int PersonID)
        {
            int TrainerID = -1; int SpecializationID = -1; DateTime HireDate = DateTime.Now; bool IsActive = true;

            if (clsTrainersData.GetTrainerInfoByPersonID(PersonID, ref TrainerID, ref SpecializationID, ref HireDate, ref IsActive))
            {
                return new clsTrainers(TrainerID, PersonID, SpecializationID, HireDate, IsActive);
            }
            return null;
        }

        public static DataTable GetAllTrainers()
        {
            return clsTrainersData.GetAllTrainers();
        }

        public static bool IsTrainerExist(int TrainerID)
        {
            return clsTrainersData.IsTrainerExist(TrainerID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTrainer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTrainer();
            }

            return false;
        }
    }
}