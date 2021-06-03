using System;

namespace LojaVirtual.Domain.Models
{
    public class Produto : Entity<int>
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }
    }
}