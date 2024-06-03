using AngelSystem_Estacionamento.Core.Interfaces;

namespace AngelSystem_Estacionamento.Core.Cliente.Interface
{
    public interface IClienteRepository : IRepositoryBase<ClienteEntity>
    {
        public IEnumerable<ClienteEntity> ObterPorNomeCpfCnpj(string nomeCompleto, string cpfCnpj);
    }
}
