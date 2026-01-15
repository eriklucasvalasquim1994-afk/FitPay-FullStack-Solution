     using Microsoft.EntityFrameworkCore;
     using FitPay.Application.Services;


// Substitua "FitPay" pelo namespace exato do seu projeto se for diferente
using FitPay.Infrastructure.Data;

bin /
obj /
.vs /
appsettings.Development.json
appsettings.json
*.user
*.suo

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÃO DO BANCO DE DADOS (SQL Server)
// Certifique-se de que a ConnectionString "DefaultConnection" está no seu appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FitPayDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Esta linha faz as bandeiras aparecerem como nomes (Visa, Master) no Swagger
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// --- INJEÇÃO DE DEPENDÊNCIA (O coração do sistema) ---


// 1. Repositório de Assinaturas
builder.Services.AddScoped<FitPay.Domain.Interfaces.IAssinaturaRepository, FitPay.Infrastructure.Repositories.AssinaturaRepository>();

// 2. REPOSITÓRIO DE CARTÕES (A linha que falta para matar o erro da imagem a9e767!)
builder.Services.AddScoped<FitPay.Domain.Interfaces.ICartaoRepository, FitPay.Infrastructure.Repositories.CartaoRepository>();

// 3. O Serviço que orquestra tudo
builder.Services.AddScoped<FitPay.Application.Services.AssinaturaService>();

// 4. O Serviço de Cobrança (Débito Automático)
builder.Services.AddScoped<FitPay.Domain.Interfaces.IPagamentoService, FitPay.Infrastructure.Payments.PixPagamentoService>();

// 5. CONFIGURAÇÃO DO SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//6. Aqui é feita a conexão com o Hosted
// Aqui você liga o "segurança" da academia
builder.Services.AddHostedService<CobrancaBackgroundService>();

// -----------------------------------------------------------------


var app = builder.Build();

// 3. CONFIGURAÇÃO DO PIPELINE (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();