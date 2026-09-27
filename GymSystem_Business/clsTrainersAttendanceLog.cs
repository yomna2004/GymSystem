using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_Business
{
    public class clsTrainersAttendanceLog
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enAttendanceStatus { CheckedIn = 1, CheckedOut = 2 }

        public int LogID { get; set; }
        public int TrainerID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int CreatedByUserID { get; set; }
        public byte Status { get; set; }

        public clsTrainersAttendanceLog()
        {
            this.LogID = -1;
            this.TrainerID = -1;
            this.CheckInDate = DateTime.Now;
            this.CheckOutDate = null;
            this.CreatedByUserID = -1;
            this.Status = (byte)enAttendanceStatus.CheckedIn;

            Mode = enMode.AddNew;
        }

        private clsTrainersAttendanceLog(int logID, int trainerID, DateTime checkInDate, DateTime? checkOutDate, int createdByUserID, byte status)
        {
            this.LogID = logID;
            this.TrainerID = trainerID;
            this.CheckInDate = checkInDate;
            this.CheckOutDate = checkOutDate;
            this.CreatedByUserID = createdByUserID;
            this.Status = status;

            Mode = enMode.Update;
        }

        private bool _AddNewLog()
        {
            this.LogID = TrainersAttendanceLogData.AddNewLog(this.TrainerID, this.CheckInDate, this.CheckOutDate, this.CreatedByUserID, this.Status);
            return (this.LogID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLog())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return false;
            }

            return false;
        }

        public static bool CheckOut(int trainerID)
        {
            return TrainersAttendanceLogData.CheckOut(trainerID, DateTime.Now, (byte)enAttendanceStatus.CheckedOut);
        }

        public static bool DeleteLog(int logID)
        {
            return TrainersAttendanceLogData.DeleteLog(logID);
        }

        public static DataTable GetAllTodayAttendanceLogs()
        {
            return TrainersAttendanceLogData.GetAllTodayAttendanceLogs();
        }

        public static DataTable GetTrainersBySpecialization(int specializationID)
        {
            return TrainersAttendanceLogData.GetTrainersBySpecialization(specializationID);
        }
    }
}
