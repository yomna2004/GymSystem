using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem_DataAccess;
namespace GymSystem_Business
{
    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public int SubscriptionID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }

        public clsPayment()
        {
            this.PaymentID = -1;
            this.SubscriptionID = -1;
            this.CreatedByUserID = -1;
            this.PaymentDate = DateTime.Now;
            this.AmountPaid = 0;
            Mode = enMode.AddNew;
        }

        private clsPayment(int paymentID, int subscriptionID, int createdByUserID, DateTime paymentDate, decimal amountPaid)
        {
            this.PaymentID = paymentID;
            this.SubscriptionID = subscriptionID;
            this.CreatedByUserID = createdByUserID;
            this.PaymentDate = paymentDate;
            this.AmountPaid = amountPaid;
            Mode = enMode.Update;
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.SubscriptionID, this.CreatedByUserID, this.PaymentDate, this.AmountPaid);
            return (this.PaymentID != -1);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    // لو احتجتِ تعديل بيانات دفع لاحقاً
                    return false;
            }

            return false;
        }
    }
}
