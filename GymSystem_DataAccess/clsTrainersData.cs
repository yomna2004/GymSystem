using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace GymSystem_DataAccess
{
    public class clsTrainersData
    {
      
            public static bool GetTrainerInfoByID(int TrainerID, ref int PersonID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive)
            {
                bool isFound = false;
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Trainers WHERE TrainerID = @TrainerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", TrainerID);
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    isFound = true;
                                    PersonID = (int)reader["PersonID"];
                                    SpecializationID = reader["SpecializationID"] != DBNull.Value ? (int)reader["SpecializationID"] : -1;
                                    HireDate = (DateTime)reader["HireDate"];
                                    IsActive = (bool)reader["IsActive"];
                                }
                            }
                        }
                        catch { isFound = false; }
                    }
                }
                return isFound;
            }

            public static bool GetTrainerInfoByPersonID(int PersonID, ref int TrainerID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive)
            {
                bool isFound = false;
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Trainers WHERE PersonID = @PersonID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    isFound = true;
                                    TrainerID = (int)reader["TrainerID"];
                                    SpecializationID = reader["SpecializationID"] != DBNull.Value ? (int)reader["SpecializationID"] : -1;
                                    HireDate = (DateTime)reader["HireDate"];
                                    IsActive = (bool)reader["IsActive"];
                                }
                            }
                        }
                        catch { isFound = false; }
                    }
                }
                return isFound;
            }

            public static int AddNewTrainer(int PersonID, int SpecializationID, DateTime HireDate, bool IsActive)
            {
                int trainerID = -1;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"INSERT INTO Trainers (PersonID, SpecializationID, HireDate, IsActive)
                                 VALUES (@PersonID, @SpecializationID, @HireDate, @IsActive);
                                 SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        if (SpecializationID != -1)
                            command.Parameters.AddWithValue("@SpecializationID", SpecializationID);
                        else
                            command.Parameters.AddWithValue("@SpecializationID", DBNull.Value);

                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null && int.TryParse(result.ToString(), out int insertedID))
                            {
                                trainerID = insertedID;
                            }
                        }
                        catch
                        {
                            trainerID = -1;
                        }
                    }
                }
                return trainerID;
            }

            public static bool DeleteTrainer(int TrainerID)
            {
                int rowsAffected = 0;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Trainers WHERE TrainerID = @TrainerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", TrainerID);

                        try
                        {
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }

                return (rowsAffected > 0);
            }

            public static bool UpdateTrainer(int TrainerID, int PersonID, int SpecializationID, DateTime HireDate, bool IsActive)
            {
                int rowsAffected = 0;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"UPDATE Trainers
                                 SET PersonID = @PersonID,
                                     SpecializationID = @SpecializationID,
                                     HireDate = @HireDate,
                                     IsActive = @IsActive
                                 WHERE TrainerID = @TrainerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", TrainerID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        if (SpecializationID != -1)
                            command.Parameters.AddWithValue("@SpecializationID", SpecializationID);
                        else
                            command.Parameters.AddWithValue("@SpecializationID", DBNull.Value);

                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        try
                        {
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }

                return (rowsAffected > 0);
            }

            public static DataTable GetAllTrainers()
            {
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = @"SELECT 
                                    T.TrainerID,
                                    T.PersonID,
                                    P.FirstName + ' ' + ISNULL(P.SecondName, '') + ' ' + ISNULL(P.LastName, '') AS FullName,
                                    P.Phone,
                                    ISNULL(S.SpecializationName, 'N/A') AS SpecializationName,
                                    T.HireDate,
                                    T.IsActive
                                 FROM Trainers T
                                 INNER JOIN People P ON T.PersonID = P.PersonID
                                 LEFT JOIN Specializations S ON T.SpecializationID = S.SpecializationID
                                 ORDER BY T.TrainerID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    dt.Load(reader);
                                }
                            }
                        }
                        catch { }
                    }
                }

                return dt;
            }

            public static bool IsTrainerExist(int TrainerID)
            {
                bool isFound = false;

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT 1 FROM Trainers WHERE TrainerID = @TrainerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", TrainerID);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                isFound = true;
                            }
                        }
                        catch
                        {
                            isFound = false;
                        }
                    }
                }

                return isFound;
            }
        }
}