using AutoMapper;
using DiplomaBack.DAL.Entities;
using DiplomaBack.Models;

namespace DiplomaBack.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<CourierRegistrationViewModel, UserModel>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
