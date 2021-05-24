using System;

namespace LojaVirtual.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}