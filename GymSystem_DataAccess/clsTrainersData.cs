using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsTrainersData
{
    public static bool GetTrainerInfoByID(int TrainerID, ref int PersonID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive, ref int createdByUserID)
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
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.GetTrainerInfoByID", ex);
                    isFound = false;
                }
            }
        }

        return isFound;
    }

    public static bool GetTrainerInfoByFullName(string FullName, ref int TrainerID, ref int PersonID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive, ref int createdByUserID)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = @"SELECT T.* 
                             FROM Trainers T
                             INNER JOIN People P ON T.PersonID = P.PersonID
                             WHERE (P.FirstName + ' ' + P.LastName) LIKE @FullName 
                                OR P.FirstName LIKE @FullName 
                                OR P.LastName LIKE @FullName;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FullName", "%" + FullName.Trim() + "%");

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            TrainerID = (int)reader["TrainerID"];
                            PersonID = (int)reader["PersonID"];
                            SpecializationID = reader["SpecializationID"] != DBNull.Value ? (int)reader["SpecializationID"] : -1;
                            HireDate = (DateTime)reader["HireDate"];
                            IsActive = (bool)reader["IsActive"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.GetTrainerInfoByFullName", ex);
                    isFound = false;
                }
            }
        }

        return isFound;
    }

    public static bool GetTrainerInfoByPersonID(int PersonID, ref int TrainerID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive, ref int createdByUserID)
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
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.GetTrainerInfoByPersonID", ex);
                    isFound = false;
                }
            }
        }

        return isFound;
    }

    public static int AddNewTrainer(int PersonID, int SpecializationID, DateTime HireDate, bool IsActive, int createdByUserID)
    {
        int trainerID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = @"INSERT INTO Trainers (PersonID, SpecializationID, HireDate, IsActive, CreatedByUserID)
                             VALUES (@PersonID, @SpecializationID, @HireDate, @IsActive, @CreatedByUserID);
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
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        trainerID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.AddNewTrainer", ex);
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
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.DeleteTrainer", ex);
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
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.UpdateTrainer", ex);
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
            string query = @"SELECT * FROM TrainersView ORDER BY FullName";

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
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.GetAllTrainers", ex);
                }
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
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.IsTrainerExist", ex);
                    isFound = false;
                }
            }
        }

        return isFound;
    }

    public static bool UpdateStatus(int TrainerID, bool IsActive)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "UPDATE Trainers SET IsActive = @IsActive WHERE TrainerID = @TrainerID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainerID", TrainerID);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LoggerHelperData.LogError("clsTrainersData.UpdateStatus", ex);
                    return false;
                }
            }
        }

        return (rowsAffected > 0);
    }
}