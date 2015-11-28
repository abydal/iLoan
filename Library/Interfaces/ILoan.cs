using System.Collections.Generic;
using iLoan.Library.DataModels;

namespace iLoan.Library.Interfaces
{
    public enum LoanType
    {
        Anuity = 1,
        Series = 2
    }
    public interface ILoan
    {
        decimal Amount { get; set; }

        decimal Interest { get; set; }

        int RepaymentYears { get; set; }

        IEnumerable<Payment> CalculateRepaymentPlan();
    }
}