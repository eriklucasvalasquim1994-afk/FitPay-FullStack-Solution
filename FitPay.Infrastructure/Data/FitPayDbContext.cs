using FitPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitPay.Infrastructure.Data;

///<summary>
/// Contexto do Banco de Dados para o sistema de academia
/// </summary>
public class FitPayDbContext : DbContext
{
    public FitPayDbContext(DbContextOptions<FitPayDbContext> options) : base(options) { }

    //Representa a tabela de assinatura no banco 
    public DbSet<Assinatura> Assinaturas { get; set; }
    public DbSet<Cartao> Cartoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da Assinatura (que já fizemos)
        modelBuilder.Entity<Assinatura>(entity =>
        {
            entity.HasKey(e => e.Cpf);
            entity.Property(e => e.Valor).HasColumnType("decimal(18,2)");
        });

        // ADICIONE ESTE BLOCO PARA O CARTÃO
        modelBuilder.Entity<Cartao>(entity =>
        {
            entity.HasKey(e => e.Id); // Define a chave primária
        });
    }
}