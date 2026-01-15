using FitPay.Application.DTOs;
using FitPay.Domain.Entities;
using FitPay.Domain.Interfaces;

namespace FitPay.Application.Services;

public class AssinaturaService
{
    private readonly IAssinaturaRepository _assinaturaRepository;
    private readonly ICartaoRepository _cartaoRepository;
    private readonly IPagamentoService _pagamentoService;

    public AssinaturaService(IAssinaturaRepository assinaturaRepository, ICartaoRepository cartaoRepository, IPagamentoService pagamentoService)
    {
        _assinaturaRepository = assinaturaRepository;
        _cartaoRepository = cartaoRepository;
        _pagamentoService = pagamentoService;
    }

    // 1. MANTÉM O QUE JÁ FUNCIONAVA (O Cadastro)
    public async Task ProcessarCadastroCompleto(CadastroAlunoCompletoDto dados)
    {
        var assinatura = new Assinatura
        {
            NomeAluno = dados.NomeAluno,
            Cpf = dados.Cpf,
            Metodo = dados.MetodoPagamento.ToString(),
            Valor = dados.ValorMensalidade,
            TipoPlano = dados.TipoPlano, // <-- COLE ESTA LINHA AQUI!
            ProximoVencimento = DateTime.Now // Garante que começa a valer a partir de hoje
        };
        var cartao = new Cartao
        {
            QuatroUltimosDigitos = dados.QuatroUltimosDigitos,
            Bandeira = dados.Bandeira ?? FitPay.Domain.Enums.BandeiraCartao.Visa,
            TokenPagamento = dados.TokenPagamento
        };

        await _assinaturaRepository.AdicionarAsync(assinatura);
        await _cartaoRepository.SalvarAsync(cartao);
        await _pagamentoService.ProcessarCobranca(assinatura);
    }

    // 2. ADICIONA O QUE ESTAVA FALTANDO (A Listagem)
    // Isso vai matar o erro CS1061 do Controller!
    public async Task<IEnumerable<Assinatura>> ListarTodasAsync()
    {
        return await _assinaturaRepository.ObterTodasAsync();
    }
}