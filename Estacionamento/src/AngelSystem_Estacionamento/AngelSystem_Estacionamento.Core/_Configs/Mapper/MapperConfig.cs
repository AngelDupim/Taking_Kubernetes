using AutoMapper;

namespace AngelSystem_Estacionamento.Core.Configs.Mapper;

public class MapperConfig
{
    public static IMapper RegistarMapper()
    {
        return new MapperConfiguration(mc =>
        {
            mc.AddProfile(new EntityToModelProfile());
            mc.AddProfile(new ModelToEntityProfile());
        }).CreateMapper();
    }
}