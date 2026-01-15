using FitPay.Domain.Enums;


namespace FitPay.Domain.Entities
{
    public class Assinatura
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Metodo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string TipoPlano { get; set; } = "Mensal"; // Pode ser "Mensal" ou "Anual"

        // Essa linha é a que estava faltando para o robô funcionar!
        public DateTime ProximoVencimento { get; set; } = DateTime.Now;
    }
}