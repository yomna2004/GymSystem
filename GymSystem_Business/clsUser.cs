using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem_DataAccess;
namespace GymSystem_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permissions { get; set; }

        public clsPerson PersonInfo { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = true;
            this.Permissions = -1;

            this.Mode = enMode.AddNew;
        }

        private clsUser(int userID, int personID, string username, string password, bool isActive, int permissions)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.Username = username;
            this.Password = password;
            this.IsActive = isActive;
            this.Permissions = permissions;

            this.PersonInfo = clsPerson.Find(personID);

            this.Mode = enMode.Update;
        }

        public static clsUser Find(int userID)
        {
            string username = "", password = "";
            int personID = -1, permissions = 0;
            bool isActive = false;

            if (clsUserData.GetUserInfoByUserID(userID, ref username, ref password, ref personID, ref isActive, ref permissions))
            {
                return new clsUser(userID, personID, username, password, isActive, permissions);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByPersonID(int personID)
        {
            string username = "", password = "";
            int userID = -1, permissions = 0;
            bool isActive = false;

            if (clsUserData.GetUserInfoByPersonID(personID, ref userID, ref username, ref password, ref isActive, ref permissions))
            {
                return new clsUser(userID, personID, username, password, isActive, permissions);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByUsernameAndPassword(string username, string password)
        {
            int userID = -1, personID = -1, permissions = 0;
            bool isActive = false;

            if (clsUserData.GetUserInfoByUsernameAndPassword(username, password, ref userID, ref personID, ref isActive, ref permissions))
            {
                return new clsUser(userID, personID, username, password, isActive, permissions);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive, this.Permissions);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password, this.IsActive, this.Permissions);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static bool DeleteUser(int userID)
        {
            return clsUserData.DeleteUser(userID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(string username)
        {
            return clsUserData.IsUserExist(username);
        }

        public static bool IsUserExistForPersonID(int personID)
        {
            return clsUserData.IsUserExistForPersonID(personID);
        }
    }
}
