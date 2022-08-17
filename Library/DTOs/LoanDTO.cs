using System.ComponentModel.DataAnnotations;
using iLoan.Library.Interfaces;

namespace iLoan.Library.DTOs
{
    public class LoanDTO
    {
        [Range(0,10000000)]
        public int Amount { get; set; }

        [Range(0,1)]
        public decimal Interest { get; set; }

        [Range(1,30)]
        public int RepaymentYears { get; set; }

        public LoanType Type { get; set; }
    }
}
