using AutoMapper;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using PFSoftware.TimeClockApi.Models.ViewModels;

namespace PFSoftware.TimeClockApi.Profiles
{
    public class TimeClockProfile : Profile
    {
        public TimeClockProfile()
        {
            //Source -> Target
            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<Role, CreateEditRoleRequest>().ReverseMap();
            CreateMap<Shift, ShiftViewModel>().ReverseMap();
            CreateMap<Shift, CreateEditShiftRequest>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, CreateEditUserRequest>().ReverseMap();
        }
    }
}