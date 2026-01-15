using FitPay.Domain.Entities;

namespace FitPay.Domain.Interfaces;

public interface ICartaoRepository
{
    Task SalvarAsync(Cartao cartao); // Termina com ponto e vírgula, sem chaves!
}