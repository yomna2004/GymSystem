using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsSpecializationData
    {
        public static bool GetSpecializationInfoByName(string SpecializationName, ref int ID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "Select * from Specialization Where specializationName = @specializationName";
                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("specializationName", SpecializationName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.Read())
                        {
                            isFound = true;
                            ID = (int)reader["specializationID"];
                        }
                        else
                        {
                            isFound = false;
                        }
                    }
                    catch(Exception ex) 
                    {
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool GetSpecializationInfoByID(int SpecializationID, ref string SpecializationName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT SpecializationName FROM Specializations WHERE SpecializationID = @SpecializationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SpecializationID", SpecializationID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                SpecializationName = (string)reader["SpecializationName"];
                            }
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
        public static DataTable GetAllSpecializations()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT SpecializationID, SpecializationName FROM Specializations ORDER BY SpecializationName ASC";

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
                    catch
                    {
                        // handle error if needed
                    }
                }
            }

            return dt;
        }
    }
}
