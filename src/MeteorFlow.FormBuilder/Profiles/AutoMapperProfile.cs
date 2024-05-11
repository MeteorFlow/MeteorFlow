using AutoMapper;
using MeteorFlow.Domain.App;
using MeteorFlow.FormBuilder.Models;
using Newtonsoft.Json;

namespace MeteorFlow.FormBuilder.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FormDefinition, Core.Entities.AppDefinitions>();
        CreateMap<Core.Entities.AppDefinitions, FormDefinition>()
            .AfterMap((_, dest) =>
                JsonConvert.DeserializeObject<AppDefinitions>(JsonConvert.SerializeObject(dest)));

        CreateMap<FormBlock, Entities.FormBlocks>().ReverseMap();
        CreateMap<FormElement, Entities.FormElements>().ReverseMap();
        CreateMap<ElementSchema, Entities.ElementSchemas>().ReverseMap();
        
    }
}