using System.Net;
using System.Net.Http;
using System.Web.Http;
using iLoan.Library;
using iLoan.Library.DTOs;

namespace iLoan.API.Controllers
{
    public class LoanController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(LoanDTO loanDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var loan = LoanFactory.CreateLoan(loanDto);
            var repaymentPlan = loan.CalculateRepaymentPlan();

            return Request.CreateResponse(HttpStatusCode.OK, repaymentPlan);
        }
    }
}