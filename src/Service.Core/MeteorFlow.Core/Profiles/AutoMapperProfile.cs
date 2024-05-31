using AutoMapper;
using MeteorFlow.Domain.App;
using Newtonsoft.Json;
using AppDefinitions = MeteorFlow.Core.Entities.AppDefinitions;
using AppInstances = MeteorFlow.Core.Entities.AppInstances;
using AppSettings = MeteorFlow.Core.Entities.AppSettings;
using AppVersionControls = MeteorFlow.Core.Entities.AppVersionControls;

namespace MeteorFlow.Core.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.App.AppSettings, AppSettings>().ReverseMap();

        CreateMap<Domain.App.AppVersionControls, AppVersionControls>().ReverseMap();

        CreateMap<Domain.App.AppDefinitions, AppDefinitions>();

        CreateMap<AppDefinitions, Domain.App.AppDefinitions>()
            .AfterMap((_, dest) =>
                JsonConvert.DeserializeObject<Domain.App.AppDefinitions>(JsonConvert.SerializeObject(dest)));

        CreateMap<Domain.App.AppInstances, AppInstances>().ReverseMap();
    }
}