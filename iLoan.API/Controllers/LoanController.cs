using iLoan.Library;
using iLoan.Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace iLoan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoanDTO loanDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loan = LoanFactory.CreateLoan(loanDto);
            var repaymentPlan = loan.CalculateRepaymentPlan();

            return Ok(repaymentPlan);
        }
    }
}