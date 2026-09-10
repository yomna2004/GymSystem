using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(
            int PersonID,
            ref string NationalNo,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref short Gender,
            ref string Phone,
            ref string Email,
            ref string Address,
            ref DateTime DateOfBirth,
            ref string ImagePath)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";

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

                                NationalNo = reader["NationalNo"] != DBNull.Value ? (string)reader["NationalNo"] : "";
                                FirstName = (string)reader["FirstName"];
                                SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                                ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                                LastName = (string)reader["LastName"];
                                Gender = Convert.ToInt16(reader["Gender"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                                Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : "";
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
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
        public static bool GetPersonInfoByNationalNo(
    string NationalNo,
    ref int PersonID,
    ref string FirstName,
    ref string SecondName,
    ref string ThirdName,
    ref string LastName,
    ref short Gender,
    ref string Phone,
    ref string Email,
    ref string Address,
    ref DateTime DateOfBirth,
    ref string ImagePath)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = reader["SecondName"] != DBNull.Value ? (string)reader["SecondName"] : "";
                                ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                                LastName = (string)reader["LastName"];
                                Gender = Convert.ToInt16(reader["Gender"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                                Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : "";
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
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
        public static int AddNewPerson(
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            short Gender,
            string Phone,
            string Email,
            string Address,
            DateTime DateOfBirth,
            string ImagePath)
        {
            int personID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO People 
                                (NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, Phone, Email, Address, DateOfBirth, ImagePath)
                                VALUES 
                                (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @Gender, @Phone, @Email, @Address, @DateOfBirth, @ImagePath);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (string.IsNullOrEmpty(NationalNo))
                        command.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    command.Parameters.AddWithValue("@FirstName", FirstName);

                    if (string.IsNullOrEmpty(SecondName))
                        command.Parameters.AddWithValue("@SecondName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@SecondName", SecondName);

                    if (string.IsNullOrEmpty(ThirdName))
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (string.IsNullOrEmpty(Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    if (string.IsNullOrEmpty(Address))
                        command.Parameters.AddWithValue("@Address", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Address", Address);

                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                    if (string.IsNullOrEmpty(ImagePath))
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            personID = insertedID;
                        }
                    }
                    catch
                    {
                        personID = -1;
                    }
                }
            }

            return personID;
        }

        public static bool UpdatePerson(
            int PersonID,
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            short Gender,
            string Phone,
            string Email,
            string Address,
            DateTime DateOfBirth,
            string ImagePath)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE People
                                 SET NationalNo = @NationalNo,
                                     FirstName = @FirstName,
                                     SecondName = @SecondName,
                                     ThirdName = @ThirdName,
                                     LastName = @LastName,
                                     Gender = @Gender,
                                     Phone = @Phone,
                                     Email = @Email,
                                     Address = @Address,
                                     DateOfBirth = @DateOfBirth,
                                     ImagePath = @ImagePath
                                 WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    if (string.IsNullOrEmpty(NationalNo))
                        command.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    command.Parameters.AddWithValue("@FirstName", FirstName);

                    if (string.IsNullOrEmpty(SecondName))
                        command.Parameters.AddWithValue("@SecondName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@SecondName", SecondName);

                    if (string.IsNullOrEmpty(ThirdName))
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (string.IsNullOrEmpty(Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    if (string.IsNullOrEmpty(Address))
                        command.Parameters.AddWithValue("@Address", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Address", Address);

                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

                    if (string.IsNullOrEmpty(ImagePath))
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

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

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    PersonID,
                                    NationalNo,
                                    FirstName,
                                    SecondName,
                                    ThirdName,
                                    LastName,
                                    (FirstName + ' ' + ISNULL(SecondName + ' ', '') + ISNULL(ThirdName + ' ', '') + LastName) AS FullName,
                                    CASE WHEN Gender = 0 THEN 'Male' ELSE 'Female' END AS GenderCaption,
                                    Phone,
                                    Email,
                                    Address,
                                    DateOfBirth,
                                    ImagePath
                                 FROM People
                                 ORDER BY PersonID DESC";

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

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

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
