using FitPay.Domain.Entities;
using FitPay.Domain.Interfaces;
using FitPay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitPay.Infrastructure.Repositories;

public class AssinaturaRepository : IAssinaturaRepository
{
    private readonly FitPayDbContext _context;

    public AssinaturaRepository(FitPayDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Assinatura assinatura)
    {
        await _context.Assinaturas.AddAsync(assinatura);
        await _context.SaveChangesAsync();
    }
    // Mantenha o que já existe até a linha 21...

    public async Task<IEnumerable<Assinatura>> ObterTodasAsync()
    {
        // O ToListAsync() vai "acender" o framework lá no topo!
        return await _context.Assinaturas.ToListAsync();
    }
    public async Task AtualizarAsync(Assinatura assinatura)
    {
        _context.Assinaturas.Update(assinatura);
        await _context.SaveChangesAsync();
    }
}