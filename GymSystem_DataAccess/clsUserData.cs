using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByUsernameAndPassword(string Username, string Password, ref int UserID
        , ref int PersonID, ref bool IsActive, ref int Permissons)
        {
            bool isFound = false;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];

                                Permissons = reader["Permissions"] != DBNull.Value ? Convert.ToInt32(reader["Permissions"]) : 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.GetUserInfoByUsernameAndPassword", ex);
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool GetUserInfoByUserID(int UserID, ref string Username, ref string Password,
        ref int PersonID, ref bool IsActive, ref int Permissions)
        {
            bool isFound = false;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
                                Permissions = reader["Permissions"] != DBNull.Value ? Convert.ToInt32(reader["Permissions"]) : 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.GetUserInfoByUserID", ex);
                        isFound = false;
                    }
                }
            }
            return isFound;
        }
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string Username,
        ref string Password, ref bool IsActive, ref int Permissions)
        {
            bool isFound = false;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                                Permissions = reader["Permissions"] != DBNull.Value ? Convert.ToInt32(reader["Permissions"]) : 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.GetUserInfoByPersonID", ex);
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static int AddNewUser(int PersonID, string Username, string Password,
        bool IsActive, int Permissions)
        {
            int userID = -1;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID, Username, Password, IsActive, Permissions)
                         VALUES (@PersonID, @Username, @Password, @IsActive, @Permissions);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@Permissions", Permissions);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            userID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.AddNewUser", ex);
                    }
                }
            }
            return userID;
        }
        public static bool UpdateUser(int UserID, int PersonID, string Username, string Password,
        bool IsActive, int Permissions)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users 
                         SET PersonID = @PersonID,
                             Username = @Username,
                             Password = @Password,
                             IsActive = @IsActive,
                             Permissions = @Permissions
                         WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@Permissions", Permissions);

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.UpdateUser", ex);
                        return false;
                    }
                }
            }
            return rowsAffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.DeleteUser", ex);
                        return false;
                    }
                }
            }
            return rowsAffected > 0;
        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Users.UserID, Users.PersonID,
                                (People.FirstName + ' ' + People.SecondName + ' ' + People.LastName) AS FullName,
                                Users.Username, Users.IsActive, Users.Permissions
                         FROM Users INNER JOIN People ON Users.PersonID = People.PersonID";

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
                        LoggerHelperData.LogError("clsUsersData.GetAllUsers", ex);
                    }
                }
            }
            return dt;
        }
        public static bool IsUserExist(string Username)
        {
            bool isFound = false;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.IsUserExistByUsername", ex);
                    }
                }
            }
            return isFound;
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsUsersData.IsUserExistForPersonID", ex);
                    }
                }
            }
            return isFound;
        }
    }
}
