using RiraTask.Api.AutoMapper.Profiles;

namespace RiraTask.Api.AutoMapper;

public class AutoMapperConfiguration
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(AddProfiles);

        return config.CreateMapper();
    }

    private static void AddProfiles(IMapperConfigurationExpression cfg)
    {
        cfg.AddProfile(new UserMappingProfile());
    }
}