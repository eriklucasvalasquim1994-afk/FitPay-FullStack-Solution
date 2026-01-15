using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FitPay.Infrastructure.Data;

public class FitPayDbContextFactory : IDesignTimeDbContextFactory<FitPayDbContext>
{
    public FitPayDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FitPayDbContext>();

        // COLOQUE SUA STRING DE CONEXÃO AQUI (Igual a do appsettings.json)
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FitPayDb;Trusted_Connection=True;");

        return new FitPayDbContext(optionsBuilder.Options);
    }
}