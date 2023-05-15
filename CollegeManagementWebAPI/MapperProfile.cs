using AutoMapper;
using CollegeManagementWebAPI.Models;
using CollegeManagementWebAPI.ViewModels;

namespace CollegeManagementWebAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
