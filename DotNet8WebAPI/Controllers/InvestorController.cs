using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorService _investorService;

        public InvestorController(IInvestorService investorService)
        {
            _investorService = investorService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool isActive)
        {
            return Ok(_investorService.GetAllInvestors(isActive));
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var investor = _investorService.GetInvestorsById(id);
            if (investor == null)
            {
                return NotFound();
            }
            return Ok(investor);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateInvestor investor)
        {
            var inv = _investorService.AddInvestor(investor);
            if (inv == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Investor has been created successfully",
                id = inv.Id
            });
        }

        [HttpPut]        
        public IActionResult Put([FromQuery] int id, [FromBody] AddUpdateInvestor investor)
        {
            var inv = _investorService.UpdateInvestor(id, investor);
            if (inv == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Investor has been updated successfully",
                id = inv.Id
            });
        }

        [HttpDelete]        
        public IActionResult Delete([FromQuery] int id)
        {
            if(!_investorService.DeleteInvestor(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Investor has been deleted successfully",
                id = id
            });

        }
    }
}
