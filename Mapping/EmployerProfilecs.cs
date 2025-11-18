using AutoMapper;
using YasserWorkShop.DTOS;
using YasserWorkShop.Models;

namespace YasserWorkShop.Mapping
{
    public class EmployerProfilecs:Profile
    {
        public EmployerProfilecs()
        {
            //from model to dto
            CreateMap<Employer, EmployerDTO>();

            //from dto to model
            CreateMap<EmployerDTO, Employer>();
        }

    }
}
