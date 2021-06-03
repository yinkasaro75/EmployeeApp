using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee,EmployeeDto>();
            CreateMap<EmployeeDto,Employee>();
        }
    }
}