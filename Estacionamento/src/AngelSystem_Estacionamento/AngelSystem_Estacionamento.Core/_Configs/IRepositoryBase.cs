namespace AngelSystem_Estacionamento.Core.Interfaces;

public interface IRepositoryBase<T>
{
    T Adicionar(T entity);
    T Atualizar(T entity);
    T Excluir(T entity);
    T ObterPorId(int id);
}