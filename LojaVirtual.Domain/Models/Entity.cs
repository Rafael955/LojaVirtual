using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public abstract class Entity<T> where T : struct
    {
        [Key]
        public virtual T Id { get; protected set; }

        public DateTime DataCadastro { get; private set; } = DateTime.Now;
    }
}