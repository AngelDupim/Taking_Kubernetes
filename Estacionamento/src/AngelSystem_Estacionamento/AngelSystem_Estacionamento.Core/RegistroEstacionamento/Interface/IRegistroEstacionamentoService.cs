﻿namespace AngelSystem_Estacionamento.Core.RegistroEstacionamento.Interface;

public interface IRegistroEstacionamentoService
{
    RegistroEstacionamentoResponseModel Adicionar(RegistroEstacionamentoRequestModel request);
    RegistroEstacionamentoResponseModel AtualizarValoresSaida(RegistroEstacionamentoRequestModel request);
}