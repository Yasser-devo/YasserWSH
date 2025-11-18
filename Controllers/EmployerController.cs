using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using YasserWorkShop.CustomModelValidation;
using YasserWorkShop.DTOS;
using YasserWorkShop.Models;
using YasserWorkShop.Repositories;

namespace YasserWorkShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployeerRepo _repo;
        public EmployerController(IEmployeerRepo repo)
        {
            _repo=repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployers([FromQuery] string? filteron, [FromQuery]string? filterquery)
        {
            var Employers = await _repo.GetEmployersasync(filteron,filterquery);
            if (Employers.Count() == 0)
            {
                return NotFound($"there is no employers in your data base");
            }
            return Ok(Employers);
        }
        [HttpGet("id")]
        public async Task<IActionResult> Getemployer(int id)
        {
            var employer = await _repo.GetEmployerasync(id);
            if(employer==null)
            {
                return NotFound($"The Employer with That Id {id} is Not Exist");
            }
            return Ok(employer);
        }
        [HttpPost]
        [ModelValidate]
        public async Task<IActionResult> AddEmployer(EmployerDTO employer)
        {
            
            var emp = await _repo.AddEmployerasync(employer);
            return Ok(emp);
        }
        [HttpPatch]
        public async Task<IActionResult> PatchEmloyer(int id, [FromBody]JsonPatchDocument<EmployerDTO> employer)
        {
            var newEmployer = await _repo.PatchEmloyer(id, employer);
            if (newEmployer == null)
            {
                return NotFound($"The Employer with That Id {id} is Not Exist");
            }
            return Ok(newEmployer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployer(EmployerDTO employer,int id)
        {
            var newEmployer = await _repo.UpdateEmployerasync(id,employer);
            if(newEmployer==null)
            {
                return NotFound($"The Employer with That Id {id} is Not Exist");
            }
            return Ok(newEmployer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var deletedemp = await _repo.RemoveEmployerasync(id);
            if(deletedemp==null)
            {
                return NotFound($"The Employer with That Id {id} is Not Exist");
            }
            return Ok(deletedemp); 

        }
    }
}
