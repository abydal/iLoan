using System.Collections.Generic;
using System.Linq;
using iLoan.Library.Interfaces;


namespace iLoan.Library.DataModels
{
    internal class SeriesLoan : ILoan
    {
        public int Amount { get; set; }
        public float Interest { get; set; }
        public int RepaymentYears { get; set; }
        public IEnumerable<Payment> CalculateRepaymentPlan()
        {
            var payments = new List<Payment>();
            var monthlyInterest = Interest / 12.0;
            var terms = RepaymentYears * 12;
            var previousValue = (float)Amount;
            var termPayment = Amount/terms; 

            for (int period = 1; period < terms + 1; period++)
            {

                var interest = previousValue*monthlyInterest;

                var payment = new Payment()
                {
                    Period = period,
                    TotalAmount = (float)(termPayment + interest),
                    InterestAmount = (float)(previousValue * monthlyInterest),
                    PaymentAmount = termPayment,
                    RemainingDebt = Amount - payments.Sum(p => p.PaymentAmount) - termPayment
                };

                payments.Add(payment);
                previousValue = (float)(previousValue-termPayment);
            }

            return payments;
        }
    }
}