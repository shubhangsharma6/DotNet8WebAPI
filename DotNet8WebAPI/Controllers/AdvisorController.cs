using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;

        public AdvisorController(IAdvisorService advisorService)
        {
            _advisorService = advisorService;  
        }

        [HttpGet]
        public async Task <IActionResult> Get([FromQuery] bool isActive)
        {
            var advisors = await _advisorService.GetAllAdvisors(isActive);
            if(advisors == null)
            {
                return NotFound();
            }
            return Ok(advisors);
        }

        [HttpGet("id")]
        public async Task <IActionResult> Get(int id)
        {
            var advisor = await _advisorService.GetAdvisorById(id);
            if (advisor == null) 
            {
                return NotFound();
            }
            return Ok(advisor);
        }

        [HttpPost]
        public async Task <IActionResult> Post([FromBody] AddUpdateAdvisor advisor)
        {
            var newAdvisor = await _advisorService.AddAdvisor(advisor)!;

            if (newAdvisor == null) 
            {
                return BadRequest();
            }

            return Ok(new
            {
            message = "Advisor added successfully",
            id = newAdvisor.Id,
            });
        }

        [HttpPut]
        public async Task <IActionResult> Put([FromQuery] int id, [FromBody] AddUpdateAdvisor advisor)
        {
            var updatedAdvisor = await _advisorService.UpdateAdvisor(id, advisor)!;
            if (updatedAdvisor == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Advisor updated successfully",
                id = updatedAdvisor.Id,
            });
        }

        [HttpDelete("id")]
        public async Task <IActionResult> Delete([FromQuery] int id)
        {
            if(!await _advisorService.DeleteAdvisor(id)!)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Advisor deleted successfully",
                id = id
            });
        }
    }
}
