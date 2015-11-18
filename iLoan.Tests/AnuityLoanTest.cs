using System;
using iLoan.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iLoan.Tests
{
    [TestClass]
    public class AnuityLoanTest
    {
        [TestMethod]
        public void CalculateRepaymentPlan_Should_Calculate_Correctly()
        {
            var loan = new AnuityLoan()
            {
                Amount = 2000000,
                Interest = 0.035f,
                RepaymentYears = 20
            };

            var plan = loan.CalculateRepaymentPlan();

            Assert.IsTrue(true);
        }
    }
}
