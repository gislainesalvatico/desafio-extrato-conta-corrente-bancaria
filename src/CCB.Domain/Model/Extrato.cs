using System;
using System.Collections.Generic;
using System.Text;

namespace CCB.Domain.Model
{
    public class Extrato : Base
    {
        public DateTime Data { get; set; }
        public string Historico { get; set; }
        public decimal Valor { get; set; }
        public int Tipo { get; set; }
    }
}
