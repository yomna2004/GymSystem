using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GymSystem_Business
{
    public class clsMember
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string MemberCode { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }

        public clsMember()
        {
            this.MemberID = -1;
            this.PersonID = -1;
            this.MemberCode = string.Empty;
            this.JoinDate = DateTime.Now;
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsMember(int memberID, int personID, string memberCode, DateTime joinDate, bool isActive)
        {
            this.MemberID = memberID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            this.MemberCode = memberCode;
            this.JoinDate = joinDate;
            this.IsActive = isActive;

            Mode = enMode.Update;
        }

        public static bool IsMemberCodeExist(string memberCode)
        {
            return clsMembersData.IsMemberCodeExist(memberCode);
        }

        private string _GenerateUniqueMemberCode()
        {
            Random random = new Random();
            string newCode;

            do
            {
                newCode = random.Next(1000, 10000).ToString();
            }
            while (IsMemberCodeExist(newCode)); 

            return newCode;
        }

        private bool _AddNewMember()
        {
            if (string.IsNullOrWhiteSpace(this.MemberCode))
            {
                this.MemberCode = _GenerateUniqueMemberCode();
            }

            this.MemberID = clsMembersData.AddNewMember(this.PersonID, this.MemberCode, this.JoinDate, this.IsActive);
            return (this.MemberID != -1);
        }

        private bool _UpdateMember()
        {
            return clsMembersData.UpdateMember(this.MemberID, this.PersonID, this.MemberCode, this.JoinDate, this.IsActive);
        }

        public static clsMember FindByID(int memberID)
        {
            int personID = -1;
            string memberCode = string.Empty;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            if (clsMembersData.GetMemberInfoByID(memberID, ref personID, ref memberCode, ref joinDate, ref isActive))
            {
                return new clsMember(memberID, personID, memberCode, joinDate, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsMember FindByPersonID(int personID)
        {
            int memberID = -1;
            string memberCode = string.Empty;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            if (clsMembersData.GetMemberInfoByPersonID(personID, ref memberID, ref memberCode, ref joinDate, ref isActive))
            {
                return new clsMember(memberID, personID, memberCode, joinDate, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsMember FindByFullName(string fullName)
        {
            int memberID = -1;
            int personID = -1;
            string memberCode = string.Empty;
            DateTime joinDate = DateTime.Now;
            bool isActive = false;

            if (clsMembersData.GetMemberInfoByFullName(fullName, ref memberID, ref personID, ref memberCode, ref joinDate, ref isActive))
            {
                return new clsMember(memberID, personID, memberCode, joinDate, isActive);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMember();
            }

            return false;
        }

        public static bool DeleteMember(int memberID)
        {
            return clsMembersData.DeleteMember(memberID);
        }

        public static DataTable GetAllMembers()
        {
            return clsMembersData.GetAllMembers();
        }
    }
}

