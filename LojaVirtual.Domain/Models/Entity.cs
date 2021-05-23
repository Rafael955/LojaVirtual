using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}