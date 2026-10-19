using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsSubscriptionsData
    {
        public static int AddNewSubscription(int memberID, int planID, int trainerID, int sportID, DateTime startDate, DateTime endDate, bool isActive)
        {
            int subscriptionID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Subscriptions 
                             (MemberID, PlanID, TrainerID, SportID, StartDate, EndDate, IsActive)
                             VALUES 
                             (@MemberID, @PlanID, @TrainerID, @SportID, @StartDate, @EndDate, @IsActive);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@PlanID", planID);

                    command.Parameters.AddWithValue("@TrainerID", trainerID != -1 ? (object)trainerID : DBNull.Value);
                    command.Parameters.AddWithValue("@SportID", sportID != -1 ? (object)sportID : DBNull.Value);

                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            subscriptionID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionsData.AddNewSubscription", ex);
                    }
                }
            }

            return subscriptionID;
        }

        public static bool UpdateSubscription(int subscriptionID, int memberID, int planID, int trainerID, int sportID, DateTime startDate, DateTime endDate, bool isActive)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Subscriptions 
                             SET MemberID = @MemberID,
                                 PlanID = @PlanID,
                                 TrainerID = @TrainerID,
                                 SportID = @SportID,
                                 StartDate = @StartDate,
                                 EndDate = @EndDate,
                                 IsActive = @IsActive
                             WHERE SubscriptionID = @SubscriptionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);
                    command.Parameters.AddWithValue("@MemberID", memberID);
                    command.Parameters.AddWithValue("@PlanID", planID);
                    command.Parameters.AddWithValue("@TrainerID", trainerID != -1 ? (object)trainerID : DBNull.Value);
                    command.Parameters.AddWithValue("@SportID", sportID != -1 ? (object)sportID : DBNull.Value);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionsData.UpdateSubscription", ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteSubscription(int subscriptionID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Subscriptions WHERE SubscriptionID = @SubscriptionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsSubscriptionsData.DeleteSubscription", ex);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllSubscriptions()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                Subscriptions.SubscriptionID, 
                                Subscriptions.MemberID, 
                                SubscriptionPlans.PlanName, 
                                Subscriptions.StartDate, 
                                Subscriptions.EndDate, 
                                Subscriptions.IsActive
                             FROM Subscriptions
                             INNER JOIN SubscriptionPlans ON Subscriptions.PlanID = SubscriptionPlans.PlanID
                             ORDER BY Subscriptions.SubscriptionID DESC";

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
                        LoggerHelperData.LogError("clsSubscriptionsData.GetAllSubscriptions", ex);
                    }
                }
            }

            return dt;
        }
    }
}
