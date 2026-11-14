using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsPaymentData
    {
        public static int AddNewPayment(int subscriptionID, int createdByUserID, DateTime paymentDate, decimal amountPaid)
        {
            int paymentID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Payments (SubscriptionID, CreatedByUserID, PaymentDate, AmountPaid)
                             VALUES (@SubscriptionID, @CreatedByUserID, @PaymentDate, @AmountPaid);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubscriptionID", subscriptionID);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    command.Parameters.AddWithValue("@AmountPaid", amountPaid);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            paymentID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        LoggerHelperData.LogError("clsPaymentData.AddNewPayment", ex);
                    }
                }
            }

            return paymentID;
        }
    }
}
