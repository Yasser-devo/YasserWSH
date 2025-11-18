using Microsoft.AspNetCore.JsonPatch;
using YasserWorkShop.DTOS;
using YasserWorkShop.Models;

namespace YasserWorkShop.Repositories
{
    public interface IEmployeerRepo
    {
        public  Task<List<EmployerDTO>> GetEmployersasync(string? filrteron = null,string? filterquery =null);
        public Task< EmployerDTO> GetEmployerasync(int id);
        public  Task<EmployerDTO> AddEmployerasync(EmployerDTO employer);
        public Task<EmployerDTO> UpdateEmployerasync(int id,EmployerDTO employer);
        public Task<EmployerDTO> PatchEmloyer(int id, JsonPatchDocument<EmployerDTO> employer);
        public Task<EmployerDTO> RemoveEmployerasync(int id);
    }
}
