using FitPay.Domain.Entities;

namespace FitPay.Domain.Interfaces;

public interface IAssinaturaRepository
{
    Task AdicionarAsync(Assinatura assinatura);
    Task<IEnumerable<Assinatura>> ObterTodasAsync();

    Task AtualizarAsync(Assinatura assinatura);
}