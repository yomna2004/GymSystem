using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class TrainersAttendanceLogData
    {
        public static int AddNewLog(int TrainerID, DateTime CheckInDate, DateTime? CheckOutDate, int CreatedByUserID, byte Status)
        {
            int LogID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO TrainersAttendanceLog (TrainerID, CheckInDate, CheckOutDate, CreatedByUserID, Status)
                                 VALUES (@TrainerID, @CheckInDate, @CheckOutDate, @CreatedByUserID, @Status);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@TrainerID", TrainerID);
                    command.Parameters.AddWithValue("@CheckInDate", CheckInDate);

                    if (CheckOutDate.HasValue && CheckOutDate.Value != DateTime.MinValue)
                        command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate.Value);
                    else
                        command.Parameters.AddWithValue("@CheckOutDate", DBNull.Value);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@Status", Status);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LogID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("TrainersAttendanceLogData.AddNewLog", ex);
                    }
                }
            }

            return LogID;
        }

        public static bool CheckOut(int TrainerID, DateTime CheckOutDateTime, byte Status)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TrainersAttendanceLog
                                 SET CheckOutDateTime = @CheckOutDateTime,
                                     Status = @Status
                                 WHERE LogID = (
                                     SELECT TOP 1 LogID 
                                     FROM TrainersAttendanceLog 
                                     WHERE TrainerID = @TrainerID AND CheckOutDateTime IS NULL 
                                     ORDER BY LogID DESC
                                 );";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@TrainerID", TrainerID);
                    command.Parameters.AddWithValue("@CheckOutDateTime", CheckOutDateTime);
                    command.Parameters.AddWithValue("@Status", Status);

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("TrainersAttendanceLogData.CheckOut", ex);
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLog(int LogID)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM TrainersAttendanceLog WHERE LogID = @LogID;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@LogID", LogID);

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("TrainersAttendanceLogData.DeleteLog", ex);
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllTodayAttendanceLogs()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                            L.LogID,
                            L.TrainerID,
                            (P.FirstName + ' ' + P.LastName) AS FullName,
                            L.CheckInDate,
                            L.CheckOutDate,
                            L.Status,
                            L.CreatedByUserID 
                         FROM TrainersAttendanceLog L
                         INNER JOIN Trainers T ON L.TrainerID = T.TrainerID
                         INNER JOIN People P ON T.PersonID = P.PersonID
                         WHERE CAST(L.CheckInDate AS DATE) = CAST(GETDATE() AS DATE)
                         ORDER BY L.LogID DESC;"; 

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("TrainersAttendanceLogData.GetAllTodayAttendanceLogs", ex);
                    }
                }
            }

            return dt;
        }

        public static DataTable GetTrainersBySpecialization(int SpecializationID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    T.TrainerID,
                                    (P.FirstName + ' ' + P.LastName) AS FullName,
                                    T.SpecializationID,
                                    T.HireDate,
                                    T.IsActive
                                 FROM Trainers T
                                 INNER JOIN People P ON T.PersonID = P.PersonID
                                 WHERE T.SpecializationID = @SpecializationID;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@SpecializationID", SpecializationID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsTrainersData.GetTrainersBySpecialization", ex);
                    }
                }
            }

            return dt;
        }
    }
}
