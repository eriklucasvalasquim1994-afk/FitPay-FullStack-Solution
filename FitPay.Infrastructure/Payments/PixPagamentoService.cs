using FitPay.Domain.Entities;
using FitPay.Domain.Enums;
using FitPay.Domain.Interfaces;


namespace FitPay.Infrastructure.Payments;
public class PixPagamentoService : IPagamentoService
{
    public async Task<string> ProcessarCobranca(Assinatura assinatura)
    {
        // Mantemos apenas o que é útil para a sua academia: o Débito
        if (assinatura.Metodo == TipoPagamento.DebitoAutomatico.ToString())
        {
            return $"[DÉBITO] Solicitação de débito enviada ao banco para o aluno {assinatura.NomeAluno}";
        }

        return "Método de pagamento não suportado nesta versão.";
    }
}