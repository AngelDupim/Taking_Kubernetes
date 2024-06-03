using AngelSystem_Estacionamento.Core.Interfaces;

namespace AngelSystem_Estacionamento.Core.Veiculo.Interface
{
    public interface IVeiculoRepository : IRepositoryBase<VeiculoEntity>
    {
        public IEnumerable<VeiculoEntity> ObterPorPlacaCidadeEstado(string? placa, string? cidade, string? uf);
    }
}