using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Contato : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Texto { get; set; }
    }
}
