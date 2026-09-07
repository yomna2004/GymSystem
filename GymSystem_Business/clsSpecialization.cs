using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GymSystem_Business
{
    public class clsSpecialization
    {
        public int SpecializationID { get; set; }
        public string SpecializationName { get; set; }

        public clsSpecialization()
        {
            this.SpecializationID = -1;
            this.SpecializationName = "";
        }

        private clsSpecialization(int specializationID, string specializationName)
        {
            this.SpecializationID = specializationID;
            this.SpecializationName = specializationName;
        }

        public static clsSpecialization FindBySpecializationID(int specializationID)
        {
            string specializationName = "";

            if (clsSpecializationData.GetSpecializationInfoByID(specializationID, ref specializationName))
            {
                return new clsSpecialization(specializationID, specializationName);
            }
            else
            {
                return null;
            }
        }

        public static clsSpecialization FindBySpecializationName(string specializationName)
        {
            int specializationID = -1;

            if (clsSpecializationData.GetSpecializationInfoByName(specializationName, ref specializationID))
            {
                return new clsSpecialization(specializationID, specializationName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllSpecializations()
        {
            return clsSpecializationData.GetAllSpecializations();
        }
    }
}
