using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CCB.Web.Models
{
    public class Extrato
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto")]
        [Display(Name = "Data")] 
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo histórico é obrigatório")]
        [StringLength(100, ErrorMessage = "O histórico precisa ter no máximo 100 caracteres")]
        [Display(Name = "Histórico")] 
        public string Historico { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo tipo é obrigatório")]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        public string TipoMovimentacao => this.Tipo == 1 ? "C" : "D";

        public string CorTipoMovimentacao => this.Tipo == 1 ? "black" : "red";

        public decimal Saldo(List<Extrato> extrato)
        {
            var credito = extrato.Where(e => e.Tipo == 1).Sum(e => e.Valor);
            var debito = extrato.Where(e => e.Tipo == 2).Sum(e => e.Valor);
            return credito - debito;
        }

        public bool SaldoInsuficiente(decimal saldo, decimal valorDebito)
        {
            return saldo < valorDebito;
        }

        public Extrato()
        {
            Data = DateTime.Now;
        }
    }
}