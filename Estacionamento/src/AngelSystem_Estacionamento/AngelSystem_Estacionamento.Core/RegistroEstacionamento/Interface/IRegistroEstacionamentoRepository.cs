namespace AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;

public interface IRegistroEstacionamentoRepository
{
    public RegistroEstacionamentoEntity Adicionar(RegistroEstacionamentoEntity registroEstacionamento);
    public RegistroEstacionamentoEntity AtualizarValoresSaida(RegistroEstacionamentoEntity registroEstacionamento);
    IEnumerable<RegistroEstacionamentoEntity> ObterPorClienteIdVeiculoId(int? clienteId, int? veiculoId);
}