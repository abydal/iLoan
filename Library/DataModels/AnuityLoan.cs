using iLoan.Library.Interfaces;

namespace iLoan.Library.DataModels
{
    /*
    * kilde: http://www.dn.no/resources/html/annuitetslansakalk.html
    * Så etter denne for å finne korrekt utregning av nedbetalingsplan.
    */
    public class AnuityLoan : ILoan
    {
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public int RepaymentYears { get; set; }

        public IEnumerable<Payment> CalculateRepaymentPlan()
        {
            var payments = new List<Payment>();
            decimal monthlyInterest = Interest / 12;
            double terms = RepaymentYears*12;
            decimal previousValue = Amount;
                 
            for (int period = 1; period < terms+1; period++)
            {

                decimal annuitet = pmt(monthlyInterest, (terms+1) - period, -previousValue, 0, 0);
                decimal currentPaymentAmount = (annuitet - (previousValue*monthlyInterest));

                var payment = new Payment()
                {
                    Period = period,
                    TotalAmount = annuitet,
                    InterestAmount = previousValue*monthlyInterest,
                    PaymentAmount = currentPaymentAmount,
                    RemainingDebt = Amount - payments.Sum(p => p.PaymentAmount) - currentPaymentAmount
                };

                payments.Add(payment);
                previousValue = previousValue + payment.InterestAmount - annuitet;
            }

            return payments;
        }

        private decimal pmt(decimal rate, double periodsLeft, decimal presentValue, decimal futureValue, int type)
        {
            if (rate == 0)
            {
                return -presentValue / (decimal)periodsLeft;
            }

            decimal pvif = (decimal)Math.Pow(1L + (double)rate, periodsLeft);
            decimal fvifa = (pvif - 1M) / rate;
            decimal type1 = (type != 0) ? 1 : 0;
            return ((-presentValue * pvif - futureValue) / ((1 + rate * type1) * fvifa));
        }
    }
}
