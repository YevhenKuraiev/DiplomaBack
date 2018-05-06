using AutoMapper;
using DiplomaBack.DAL.Entities;

namespace DiplomaBack.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, CourierRegistrationViewModel>();
            CreateMap<CourierRegistrationViewModel, UserModel>();
        }
    }
}
