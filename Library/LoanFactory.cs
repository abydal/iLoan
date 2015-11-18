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
            var amount = int.Parse(loanDto.Amount);
            var years = int.Parse(loanDto.RepaymentYears);
            var type = loanDto.Type.ToLower() == "1" ? LoanType.Anuity : LoanType.Series;
            var interest = float.Parse(loanDto.Interest);

            switch (type)
            {
                case LoanType.Series:
                    return new SeriesLoan() {Amount = amount, Interest = interest, RepaymentYears = years};
                    break;
                case LoanType.Anuity:
                    return new AnuityLoan() {Amount = amount, Interest = interest, RepaymentYears = years};
                    break;
            }

            throw new ArgumentException("Arguments could not be parsed correctly.");
        }
    }
}
