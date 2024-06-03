using AngelSystem_Estacionamento.Core.Cliente;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento;
using AngelSystem_Estacionamento.Core.Veiculo;
using AutoMapper;

namespace AngelSystem_Estacionamento.Core.Configs.Mapper;

public class ModelToEntityProfile : Profile
{
    public ModelToEntityProfile()
    {
        CreateMap<ClienteRequestModel, ClienteEntity>();
        CreateMap<ClienteResponseModel, ClienteEntity>();
       
        CreateMap<VeiculoRequestModel, VeiculoEntity>();
        CreateMap<VeiculoResponseModel, VeiculoEntity>();

        CreateMap<RegistroEstacionamentoRequestModel, RegistroEstacionamentoEntity>();
    }
}