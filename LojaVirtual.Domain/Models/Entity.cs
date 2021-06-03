using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public abstract class Entity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}