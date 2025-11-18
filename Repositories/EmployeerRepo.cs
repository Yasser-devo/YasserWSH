using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using YasserWorkShop.Data;
using YasserWorkShop.DTOS;
using YasserWorkShop.Models;

namespace YasserWorkShop.Repositories
{
    public class EmployeerRepo : IEmployeerRepo
    {
        private readonly WSHDBContext _context;
        private readonly IMapper _mapper;
        public EmployeerRepo(WSHDBContext wSHDB ,IMapper mapper)
        {
            _context=wSHDB;
            _mapper=mapper;
        }
        public async Task< EmployerDTO> AddEmployerasync(EmployerDTO employer)
        {

            //mapping it to model to add it to database
            var emp = _mapper.Map<Employer>(employer);

           await _context.employers.AddAsync(emp);
            await _context.SaveChangesAsync();
            //return dto
            return(employer);
        }

        public async Task <EmployerDTO> GetEmployerasync(int id)
        {
            // take the id and search in database for the record
            var employeer=await _context.employers.SingleOrDefaultAsync(o=>o.Id==id);
            if (employeer==null)
            {
                return null;
            }
            // maping the model i get from database to dto to return it 
            var emp = _mapper.Map<EmployerDTO>(employeer);
            return (emp);

        }

        public async Task< List<EmployerDTO>> GetEmployersasync(string? filrteron = null, string? filterquery = null)
        {
            //retern list of all models in database
            var lists = _context.employers.AsQueryable();
            if (string.IsNullOrWhiteSpace(filrteron) == false && string.IsNullOrWhiteSpace(filterquery)==false)
            {
                if (filrteron.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    lists=lists.Where(o=>o.Name.Contains(filterquery));
                }
            }

            var list = await lists.ToListAsync();
            // declare empty dto list 
            var listDto = new List<EmployerDTO>() ;

            //loop in model list and map each model to dto then add it to dto list
            foreach(var emp in list)
            {
                listDto.Add(_mapper.Map<EmployerDTO>(emp));
                
                    
             
            }

            return (listDto);
        }

        public async Task< EmployerDTO> RemoveEmployerasync(int id)
        {
            var employeer = await _context.employers.SingleOrDefaultAsync(o => o.Id == id);

            if (employeer == null)
            {
                return null;
            }
            //mapping model to dto 
            var emp = _mapper.Map<EmployerDTO>(employeer);
            _context.employers.Remove(employeer);
            await _context.SaveChangesAsync();
            return (emp);
        }
        public async Task<EmployerDTO> PatchEmloyer(int id, JsonPatchDocument<EmployerDTO> employer)
        {

            //get the model from database by id 
            var model = await _context.employers.SingleOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return null;
            }

            // mapping model to dto
            var dto =_mapper.Map<EmployerDTO>(model);
            //aplly patching on dto 
            employer.ApplyTo(dto);

            // maping dto to model again to save it in database
            _mapper.Map(dto,model);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task <EmployerDTO> UpdateEmployerasync(int id,EmployerDTO employer)
        {
            // get model from database by id
            var model = await _context.employers.SingleOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return null;
            }

            //maping model to dto
            var dto = _mapper.Map<EmployerDTO>(model);

            //aplly update on dto
            dto.Name = employer.Name;
            dto.Position = employer.Position;
            dto.Descripton = employer.Descripton;
            dto.EMail = employer.EMail;

            //  mapping dtos to model to save in database
            _mapper.Map(dto,model); 

            await _context.SaveChangesAsync();
            return dto;
            
             
    
        }
    }
}
