using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsSubscriptionPlansData
    {
        public static bool GetPlanInfoByID(int PlanID, ref string PlanName, ref decimal Price, ref int? DurationInMonths, ref int? ClassesCount)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SubscriptionPlans WHERE PlanID = @PlanID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlanID", PlanID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PlanName = (string)reader["PlanName"];
                                Price = (decimal)reader["Price"];

                                DurationInMonths = reader["DurationInMonths"] != DBNull.Value ? (int?)reader["DurationInMonths"] : null;
                                ClassesCount = reader["ClassesCount"] != DBNull.Value ? (int?)reader["ClassesCount"] : null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionPlansData.GetPlanInfoByID", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static bool GetPlanInfoByName(string PlanName, ref int PlanID, ref decimal Price, ref int? DurationInMonths, ref int? ClassesCount)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SubscriptionPlans WHERE PlanName = @PlanName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlanName", PlanName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PlanID = (int)reader["PlanID"];
                                Price = (decimal)reader["Price"];

                                DurationInMonths = reader["DurationInMonths"] != DBNull.Value ? (int?)reader["DurationInMonths"] : null;
                                ClassesCount = reader["ClassesCount"] != DBNull.Value ? (int?)reader["ClassesCount"] : null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionPlansData.GetPlanInfoByName", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static DataTable GetAllPlans()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM SubscriptionPlans ORDER BY PlanID";

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
                        LoggerHelperData.LogError("clsSubscriptionPlansData.GetAllPlans", ex);
                    }
                }
            }

            return dt;
        }
        public static int AddNewPlan(string planName, decimal price, int? durationInMonths, int? classesCount)
        {
            int planID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO SubscriptionPlans (PlanName, Price, DurationInMonths, ClassesCount)
                         VALUES (@PlanName, @Price, @DurationInMonths, @ClassesCount);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlanName", planName);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@DurationInMonths", (object)durationInMonths ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ClassesCount", (object)classesCount ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            planID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionPlansData.AddNewPlan", ex);
                    }
                }
            }

            return planID;
        }

        public static bool UpdatePlan(int planID, string planName, decimal price, int? durationInMonths, int? classesCount)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE SubscriptionPlans 
                         SET PlanName = @PlanName,
                             Price = @Price,
                             DurationInMonths = @DurationInMonths,
                             ClassesCount = @ClassesCount
                         WHERE PlanID = @PlanID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlanID", planID);
                    command.Parameters.AddWithValue("@PlanName", planName);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@DurationInMonths", (object)durationInMonths ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ClassesCount", (object)classesCount ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionPlansData.UpdatePlan", ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePlan(int planID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM SubscriptionPlans WHERE PlanID = @PlanID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlanID", planID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionPlansData.DeletePlan", ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
    }
}
