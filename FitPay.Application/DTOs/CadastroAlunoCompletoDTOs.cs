namespace FitPay.Application.DTOs;

using FitPay.Domain.Enums;

public record CadastroAlunoCompletoDto(
    string NomeAluno,
    string Cpf,
    TipoPagamento MetodoPagamento,
    decimal ValorMensalidade,
    string TipoPlano, // <-- ADICIONAMOS ISSO (Mensal ou Anual)
    string? QuatroUltimosDigitos,
    BandeiraCartao? Bandeira,
    string? TokenPagamento
);