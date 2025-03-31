using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentUserController : ControllerBase
    {
        private IInvestmentUserService _investmentUserService;

        public InvestmentUserController(IInvestmentUserService investmentUserService)
        {
            _investmentUserService = investmentUserService;    
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate (AuthenticateRequest request)
        {
            var response = await _investmentUserService.Authenticate (request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
