using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_Business
{
    public class clsSubscriptionPlans
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public decimal Price { get; set; }
        public int? DurationInMonths { get; set; }
        public int? ClassesCount { get; set; }

        public clsSubscriptionPlans()
        {
            this.PlanID = -1;
            this.PlanName = "";
            this.Price = 0;
            this.DurationInMonths = null;
            this.ClassesCount = null;
            this.Mode = enMode.AddNew;
        }

        private clsSubscriptionPlans(int planID, string planName, decimal price, int? durationInMonths, int? classesCount)
        {
            this.PlanID = planID;
            this.PlanName = planName;
            this.Price = price;
            this.DurationInMonths = durationInMonths;
            this.ClassesCount = classesCount;
            this.Mode = enMode.Update;
        }

        public static clsSubscriptionPlans Find(int planID)
        {
            string planName = "";
            decimal price = 0;
            int? durationInMonths = null;
            int? classesCount = null;

            bool isFound = clsSubscriptionPlansData.GetPlanInfoByID(planID, ref planName, ref price, ref durationInMonths, ref classesCount);

            if (isFound)
            {
                return new clsSubscriptionPlans(planID, planName, price, durationInMonths, classesCount);
            }
            else
            {
                return null;
            }
        }

        public static clsSubscriptionPlans Find(string planName)
        {
            int planID = -1;
            decimal price = 0;
            int? durationInMonths = null;
            int? classesCount = null;

            bool isFound = clsSubscriptionPlansData.GetPlanInfoByName(planName, ref planID, ref price, ref durationInMonths, ref classesCount);

            if (isFound)
            {
                return new clsSubscriptionPlans(planID, planName, price, durationInMonths, classesCount);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllPlans()
        {
            return clsSubscriptionPlansData.GetAllPlans();
        }
        private bool _AddNewPlan()
        {
            this.PlanID = clsSubscriptionPlansData.AddNewPlan(this.PlanName, this.Price, this.DurationInMonths, this.ClassesCount);
            return (this.PlanID != -1);
        }

        private bool _UpdatePlan()
        {
            return clsSubscriptionPlansData.UpdatePlan(this.PlanID, this.PlanName, this.Price, this.DurationInMonths, this.ClassesCount);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPlan())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePlan();
            }

            return false;
        }

        public static bool Delete(int planID)
        {
            return clsSubscriptionPlansData.DeletePlan(planID);
        }
    }
}
