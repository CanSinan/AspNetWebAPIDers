using AutoMapper;

namespace LMSServices.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.UserRequestModel, LMS.Data.Entities.User>().ReverseMap();

        }
    }
}
