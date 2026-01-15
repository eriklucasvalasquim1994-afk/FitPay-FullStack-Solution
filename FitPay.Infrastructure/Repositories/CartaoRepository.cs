using FitPay.Domain.Entities;
using FitPay.Domain.Interfaces;
using FitPay.Infrastructure.Data;

namespace FitPay.Infrastructure.Repositories // ESTA LINHA É A CHAVE
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly FitPayDbContext _context;

        public CartaoRepository(FitPayDbContext context)
        {
            _context = context;
        }

        // DICA: Verifique se na sua Interface ICartaoRepository o nome é SalvarAsync ou AdicionarAsync
        public async Task SalvarAsync(Cartao cartao)
        {
            await _context.Cartoes.AddAsync(cartao);
            await _context.SaveChangesAsync();
        }
    }
}