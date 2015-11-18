using System;
using System.Collections.Generic;
using System.Linq;
using iLoan.Library.Interfaces;

namespace iLoan.Library.DataModels
{
    /*
    * kilde: http://www.dn.no/resources/html/annuitetslansakalk.html
    * Så etter denne for å finne korrekt utregning av nedbetalingsplan.
    */
    public class AnuityLoan : ILoan
    {
        public int Amount { get; set; }
        public float Interest { get; set; }
        public int RepaymentYears { get; set; }

        public IEnumerable<Payment> CalculateRepaymentPlan()
        {
            var payments = new List<Payment>();
            var monthlyInterest = Interest / 12.0;
            var terms = RepaymentYears*12;
            var previousValue = (float)Amount;
                 
            for (int period = 1; period < terms+1; period++)
            {

                var annuitet = pmt(monthlyInterest, (terms+1) - period, -previousValue, 0, 0);
                var currentPaymentAmount = (float) (annuitet - (previousValue*monthlyInterest));

                var payment = new Payment()
                {
                    Period = period,
                    TotalAmount = (float)annuitet,
                    InterestAmount = (float) (previousValue*monthlyInterest),
                    PaymentAmount = currentPaymentAmount,
                    RemainingDebt = Amount - payments.Sum(p => p.PaymentAmount) - currentPaymentAmount
                };

                payments.Add(payment);
                previousValue = (float)(previousValue + payment.InterestAmount - annuitet);
            }

            return payments;
        }

        private double pmt(double rate, double periodsLeft, double presentValue, double futureValue, double type)
        {
            if (rate == 0)
            {
                return -presentValue / periodsLeft;
            }
            else
            {
                var pvif = Math.Pow(1 + rate, periodsLeft);
                var fvifa = (Math.Pow(1 + rate, periodsLeft) - 1) / rate;
                var type1 = (type != 0) ? 1 : 0;
                return ((-presentValue * pvif - futureValue) / ((1 + rate * type1) * fvifa));
            }
        }
    }
}
