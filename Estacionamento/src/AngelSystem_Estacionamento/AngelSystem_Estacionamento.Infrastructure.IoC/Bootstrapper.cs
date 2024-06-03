using AngelSystem_Estacionamento.Core.Cliente;
using AngelSystem_Estacionamento.Core.Cliente.Interface;
using AngelSystem_Estacionamento.Core.Configs.Mapper;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento;
using AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;
using AngelSystem_Estacionamento.Core.TabelaPreco;
using AngelSystem_Estacionamento.Core.TabelaPreco.Interface;
using AngelSystem_Estacionamento.Core.Veiculo;
using AngelSystem_Estacionamento.Core.Veiculo.Interface;
using AngelSystem_Estacionamento.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AngelSystem_Estacionamento.Infrastructure.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddRegistrosServico(this IServiceCollection servico)
    {
        RegistrarRepository(servico);
        RegistrarService(servico);

        return servico;
    }

    private static void RegistrarService(IServiceCollection servico)
    {
        servico.AddSingleton(MapperConfig.RegistarMapper());

        servico.AddTransient<IClienteService, ClienteService>();
        servico.AddTransient<IVeiculoService, VeiculoService>();
        servico.AddTransient<IRegistroEstacionamentoService, RegistroEstacionamentoService>();
        servico.AddTransient<ITabelaPrecoService, TabelaPrecoService>();
        
    }

    public static void RegistrarRepository(IServiceCollection servico) 
    {               
        servico.AddTransient<IClienteRepository, ClienteRepository>();
        servico.AddTransient<IVeiculoRepository, VeiculoRepository>();
        servico.AddTransient<IRegistroEstacionamentoRepository, RegistroEstacionamentoRepository>();
        servico.AddTransient<ITabelaPrecoRepository, TabelaPrecoRepository>();
    }
}