using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsMembersData
    {
        public static bool GetMemberInfoByID(int MemberID, ref int PersonID, ref string MemberCode, ref DateTime JoinDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT PersonID, MemberCode, JoinDate, IsActive 
                         FROM Members 
                         WHERE MemberID = @MemberID;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MemberID", MemberID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                MemberCode = reader["MemberCode"] != DBNull.Value ? reader["MemberCode"].ToString() : string.Empty;
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.GetMemberInfoByID", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static bool GetMemberInfoByPersonID(int PersonID, ref int MemberID, ref string MemberCode, ref DateTime JoinDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT MemberID, MemberCode, JoinDate, IsActive 
                             FROM Members 
                             WHERE PersonID = @PersonID;";

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
                                MemberID = (int)reader["MemberID"];
                                MemberCode = reader["MemberCode"] != DBNull.Value ? reader["MemberCode"].ToString() : string.Empty;
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.GetMemberInfoByPersonID", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool GetMemberInfoByFullName(string FullName, ref int MemberID, ref int PersonID, ref string MemberCode, ref DateTime JoinDate, ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Members.MemberID, Members.PersonID, Members.MemberCode, Members.JoinDate, Members.IsActive 
                             FROM Members 
                             INNER JOIN People ON Members.PersonID = People.PersonID
                             WHERE (People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName) LIKE @FullName;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@FullName", "%" + FullName.Trim() + "%");

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                MemberID = (int)reader["MemberID"];
                                PersonID = (int)reader["PersonID"];
                                MemberCode = reader["MemberCode"] != DBNull.Value ? reader["MemberCode"].ToString() : string.Empty;
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]);
                                IsActive = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.GetMemberInfoByFullName", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int AddNewMember(int PersonID, string MemberCode, DateTime JoinDate, bool IsActive)
        {
            int memberID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Members (PersonID, MemberCode, JoinDate, IsActive)
                             VALUES (@PersonID, @MemberCode, @JoinDate, @IsActive);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@MemberCode", string.IsNullOrEmpty(MemberCode) ? (object)DBNull.Value : MemberCode);
                    command.Parameters.AddWithValue("@JoinDate", JoinDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            memberID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.AddNewMember", ex);
                    }
                }
            }

            return memberID;
        }

        public static bool UpdateMember(int MemberID, int PersonID, string MemberCode, DateTime JoinDate, bool IsActive)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Members
                             SET PersonID = @PersonID,
                                 MemberCode = @MemberCode,
                                 JoinDate = @JoinDate,
                                 IsActive = @IsActive
                             WHERE MemberID = @MemberID;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MemberID", MemberID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@MemberCode", string.IsNullOrEmpty(MemberCode) ? (object)DBNull.Value : MemberCode);
                    command.Parameters.AddWithValue("@JoinDate", JoinDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.UpdateMember", ex);
                    }
                }
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteMember(int MemberID)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM Members 
                         WHERE MemberID = @MemberID;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MemberID", MemberID);

                    try
                    {
                        conn.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.DeleteMember", ex);
                        rowsAffected = 0;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool IsMemberCodeExist(string memberCode)
        {
            bool isFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Found=1 FROM Members WHERE MemberCode = @MemberCode;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MemberCode", memberCode);

                    try
                    {
                        conn.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelperData.LogError("clsMembersData.IsMemberCodeExist", ex);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static DataTable GetAllMembers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Members.MemberID, Members.PersonID, 
                                    (People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + People.LastName) AS FullName,
                                    People.Phone, Members.MemberCode, Members.JoinDate, Members.IsActive
                             FROM Members 
                             INNER JOIN People ON Members.PersonID = People.PersonID;";

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
                        LoggerHelperData.LogError("clsMembersData.GetAllMembers", ex);
                    }
                }
            }

            return dt;
        }
    }
}