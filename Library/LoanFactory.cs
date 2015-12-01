using System;
using iLoan.Library.DataModels;
using iLoan.Library.DTOs;
using iLoan.Library.Interfaces;

namespace iLoan.Library
{
    public static class LoanFactory
    {
        public static ILoan CreateLoan(LoanDTO loanDto)
        {
            switch (loanDto.Type)
            {
                case LoanType.Series:
                    return new SeriesLoan {Amount = loanDto.Amount, Interest = loanDto.Interest, RepaymentYears = loanDto.RepaymentYears};
                case LoanType.Anuity:
                    return new AnuityLoan {Amount = loanDto.Amount, Interest = loanDto.Interest, RepaymentYears = loanDto.RepaymentYears};
            }

            throw new ArgumentException("Arguments could not be parsed correctly.");
        }
    }
}
