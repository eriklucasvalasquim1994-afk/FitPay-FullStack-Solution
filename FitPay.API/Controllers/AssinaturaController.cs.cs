using FitPay.Application.DTOs;
using FitPay.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitPay.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssinaturaController : ControllerBase
    {
        private readonly AssinaturaService _assinaturaService;

        public AssinaturaController(AssinaturaService assinaturaService)
        {
            _assinaturaService = assinaturaService;
        }

        [HttpPost("cadastrar-completo")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroAlunoCompletoDto dados)
        {
            await _assinaturaService.ProcessarCadastroCompleto(dados);
            return Ok(new { mensagem = $"Aluno {dados.NomeAluno} cadastrado com sucesso!" });
        }

        // --- VOCÊ ACABOU DE INSERIR ISSO AQUI EMBAIXO ---
        [HttpGet("listar-todos")]
        public async Task<IActionResult> Listar()
        {
            var assinaturas = await _assinaturaService.ListarTodasAsync();
            return Ok(assinaturas);
        }
    }
}