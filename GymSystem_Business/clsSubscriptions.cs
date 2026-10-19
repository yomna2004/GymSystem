using GymSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem_Business
{
    public class clsSubscriptions
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int SubscriptionID { get; set; }
        public int MemberID { get; set; }
        public int PlanID { get; set; }
        public int TrainerID { get; set; }
        public int SportID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public clsSubscriptions()
        {
            this.SubscriptionID = -1;
            this.MemberID = -1;
            this.PlanID = -1;
            this.TrainerID = -1;
            this.SportID = -1;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now.AddMonths(1);
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        private clsSubscriptions(int subscriptionID, int memberID, int planID, int trainerID, int sportID, DateTime startDate, DateTime endDate, bool isActive)
        {
            this.SubscriptionID = subscriptionID;
            this.MemberID = memberID;
            this.PlanID = planID;
            this.TrainerID = trainerID;
            this.SportID = sportID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.IsActive = isActive;
            this.Mode = enMode.Update;
        }

        private bool _AddNewSubscription()
        {
            this.SubscriptionID = clsSubscriptionsData.AddNewSubscription(
                this.MemberID,
                this.PlanID,
                this.TrainerID,
                this.SportID,
                this.StartDate,
                this.EndDate,
                this.IsActive
            );

            return (this.SubscriptionID != -1);
        }

        private bool _UpdateSubscription()
        {
            return clsSubscriptionsData.UpdateSubscription(
                this.SubscriptionID,
                this.MemberID,
                this.PlanID,
                this.TrainerID,
                this.SportID,
                this.StartDate,
                this.EndDate,
                this.IsActive
            );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubscription())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSubscription();
            }

            return false;
        }

        public static bool Delete(int subscriptionID)
        {
            return clsSubscriptionsData.DeleteSubscription(subscriptionID);
        }

        public static DataTable GetAllSubscriptions()
        {
            return clsSubscriptionsData.GetAllSubscriptions();
        }
    }
}
