using RiraTask.Core.Utilities;

namespace RiraTask.Api.AutoMapper.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<Domain.Models.User, Protos.User>()
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("o")));

        CreateMap<Protos.User, Domain.Models.User>()
            .BeforeMap((src, _) => { ValidationHelper.ValidateNationalId(src.NationalId); })
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDay)));
    }
}