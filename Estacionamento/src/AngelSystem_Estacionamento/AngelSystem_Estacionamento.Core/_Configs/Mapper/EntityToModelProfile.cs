using AngelSystem_Estacionamento.Core.Cliente;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento;
using AngelSystem_Estacionamento.Core.TabelaPreco;
using AngelSystem_Estacionamento.Core.Veiculo;
using AutoMapper;

namespace AngelSystem_Estacionamento.Core.Configs.Mapper;

public class EntityToModelProfile : Profile
{
    public EntityToModelProfile()
    {
        CreateMap<ClienteEntity, ClienteResponseModel>();
        CreateMap<ClienteEntity, ClienteResponseModel>();
        CreateMap<IEnumerable<ClienteEntity>, ListaClienteResponseModel>()
            .ForMember(dest => dest.ListaCliente, opt => opt.MapFrom(src => src));
        
        CreateMap<VeiculoEntity, VeiculoResponseModel>();
        CreateMap<IEnumerable<VeiculoEntity>, ListaVeiculoResponseModel>()
            .ForMember(dest => dest.Veiculos, opt => opt.MapFrom(src => src));

        CreateMap<RegistroEstacionamentoEntity, RegistroEstacionamentoResponseModel>();

        CreateMap<TabelaPrecoEntity, TabelaPrecoResponseModel>()
            .ForMember(dest => dest.DescricaoHora, opt => opt.MapFrom(src => src.DescricaoHora));

        CreateMap<IEnumerable<TabelaPrecoEntity>, ListaTabelaPrecoResponseModel>()
                .ForMember(dest => dest.TabelaPrecos, opt => opt.MapFrom(src => src));
    }
}