using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using iLoan.Library;
using iLoan.Library.DataModels;
using iLoan.Library.DTOs;

namespace iLoan.API.Controllers
{
    public class LoanController : ApiController
    {
        [System.Web.Http.HttpPost]
        public JsonResult<IEnumerable<Payment>> Post(LoanDTO loanDto)
        {
            var loan = LoanFactory.CreateLoan(loanDto);

            return Json(loan.CalculateRepaymentPlan());
        }
    }
}