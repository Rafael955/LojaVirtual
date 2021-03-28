using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }
    }
}
