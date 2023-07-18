using AutoMapper;
using LeaveManagement.MVC.Services.Base;
using LeaveManager.MVC.Models;

namespace LeaveManager.MVC.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
