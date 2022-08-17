using iLoan.Library.Interfaces;


namespace iLoan.Library.DataModels
{
    internal class SeriesLoan : ILoan
    {
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public int RepaymentYears { get; set; }
        public IEnumerable<Payment> CalculateRepaymentPlan()
        {
            var payments = new List<Payment>();
            decimal monthlyInterest = Interest / 12.0M;
            var terms = RepaymentYears * 12;
            decimal previousValue = Amount;
            var termPayment = Amount/terms; 

            for (int period = 1; period < terms + 1; period++)
            {

                var interest = previousValue*monthlyInterest;

                var payment = new Payment()
                {
                    Period = period,
                    TotalAmount = termPayment + interest,
                    InterestAmount = previousValue * monthlyInterest,
                    PaymentAmount = termPayment,
                    RemainingDebt = Amount - payments.Sum(p => p.PaymentAmount) - termPayment
                };

                payments.Add(payment);
                previousValue = previousValue-termPayment;
            }

            return payments;
        }
    }
}