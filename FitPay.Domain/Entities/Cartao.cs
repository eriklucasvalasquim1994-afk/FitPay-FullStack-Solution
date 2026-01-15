namespace FitPay.Domain.Entities;

using FitPay.Domain.Enums;
using System.ComponentModel.DataAnnotations; // Adicione este using

public class Cartao
{
    [Key] // Isso diz ao banco: "Este é o identificador único"
    public int Id { get; set; }

    public string QuatroUltimosDigitos { get; set; }
    public BandeiraCartao Bandeira { get; set; }
    public string TokenPagamento { get; set; }

    public Cartao() { }
}