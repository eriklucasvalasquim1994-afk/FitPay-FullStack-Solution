using Microsoft.Extensions.Hosting;
using FitPay.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq; 

namespace FitPay.Application.Services;

public class CobrancaBackgroundService : BackgroundService
{
    private readonly IServiceProvider _services;

    public CobrancaBackgroundService(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IAssinaturaRepository>();
                var pagador = scope.ServiceProvider.GetRequiredService<IPagamentoService>();

                var assinaturas = await repo.ObterTodasAsync();

                // Filtra quem precisa pagar hoje
                var paraCobrar = assinaturas.Where(a => a.ProximoVencimento <= DateTime.Now).ToList();
                foreach (var aluno in paraCobrar)
                {
                    // Tenta cobrar o valor que está registrado (seja a parcela ou o total)
                    await pagador.ProcessarCobranca(aluno);

                    // DECISÃO INTELIGENTE:
                    if (aluno.TipoPlano == "Anual")
                    {
                        // Se for pagamento único anual, pula 1 ano inteiro
                        aluno.ProximoVencimento = aluno.ProximoVencimento.AddYears(1);
                    }
                    else
                    {
                        // Se for mensal (ou recorrência do anual), pula apenas 1 mês
                        aluno.ProximoVencimento = aluno.ProximoVencimento.AddMonths(1);
                    }

                    await repo.AtualizarAsync(aluno);
                }

            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}