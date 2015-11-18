namespace iLoan.Library.DataModels
{
    public class Payment
    {
        public int Period { get; set; }

        public float TotalAmount { get; set; }

        public float InterestAmount { get; set; }

        public float PaymentAmount { get; set; }

        public float RemainingDebt { get; set; }
    }
}