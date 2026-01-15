using FitPay.Domain.Entities;

namespace FitPay.Domain.Interfaces;

public interface IPagamentoService
{
    //Esse método vai retornar a string do PIX ou o status do boleto
    Task<string> ProcessarCobranca(Assinatura assinatura);

}
