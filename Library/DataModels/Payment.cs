namespace iLoan.Library.DataModels
{
    public class Payment
    {
        public int Period { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal RemainingDebt { get; set; }
    }
}