using AngelSystem_Estacionamento.Core.TabelaPreco.Interface;
using AutoMapper;

namespace AngelSystem_Estacionamento.Core.TabelaPreco;

public class TabelaPrecoService : ITabelaPrecoService
{
    private readonly ITabelaPrecoRepository _tabelaPrecoRepository;
    private IMapper _mapper;
    private ListaTabelaPrecoResponseModel _listaTabelaPrecoResponseModel;

    public TabelaPrecoService(ITabelaPrecoRepository tabelaPrecoRepository, IMapper mapper)
    {
        _tabelaPrecoRepository = tabelaPrecoRepository;
        _mapper = mapper;
    }

    public ListaTabelaPrecoResponseModel ObterTabelaPreco()
    {
        var retorno = _tabelaPrecoRepository.ObterTabelaPreco();
        return _mapper.Map<ListaTabelaPrecoResponseModel>(retorno);
    }

    public TabelaPrecoResponseModel AtualizarValor(TabelaPrecoRequestModel request)
    {
        var entity = new TabelaPrecoEntity(request.DescricaoHora.ToString(), request.Preco);
        var retorno = _tabelaPrecoRepository.AtualizarValor(entity);

        return _mapper.Map<TabelaPrecoResponseModel>(retorno);
    }

    public decimal? CalcularPrecoCobrar(TimeSpan totalHoraPermanencia)
    {
        var adicionais = ObterPreco(TabelaPrecoEnum.Horas_Adicionais);

        decimal? valorTotal = 0;

        valorTotal = totalHoraPermanencia.Hours switch
        {
            <= 1 => ObterPreco(TabelaPrecoEnum.Uma_Hora),
            <= 2 => ObterPreco(TabelaPrecoEnum.Duas_Horas),
            <= 3 => ObterPreco(TabelaPrecoEnum.Tres_Horas),
            <= 12 => ObterPreco(TabelaPrecoEnum.Doze_Horas),
            _ => ObterPreco(TabelaPrecoEnum.Doze_Horas) + (decimal)((Math.Ceiling(totalHoraPermanencia.TotalHours) - 12) * (double)adicionais)
        };

        return valorTotal;
    }

    private decimal? ObterPreco(TabelaPrecoEnum tabelaPreco)
    {
        if (_listaTabelaPrecoResponseModel is null)
        {
            _listaTabelaPrecoResponseModel = ObterTabelaPreco();
        }

        var preco = _listaTabelaPrecoResponseModel.TabelaPrecos.FirstOrDefault(x => x.DescricaoHora.Equals(tabelaPreco))?.Preco;

        return preco;
    }
}