using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Domain.Models
{
    public class Imagem : Entity<Guid>
    {
        public Imagem()
        {
            Id = Guid.NewGuid();
        }

        public string Caminho { get; set; }

        #region Relacionamento Entity Framework

        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        #endregion Relacionamento Entity Framework
    }
}

//Banco de Dados - Relacionamento entre Tabelas
//POO - Associações entre Objetos
//Entity Framwork serve para unir esses dois: Banco de Dados à Programação Orientada a Objetos!!!
//EF é um ORM, faz o mapeamento objeto-relacional entre nossas classes em nosso Modelo e as Tabelas no Banco de Dados.
//Formas de mapeamento objeto-relacional:
// 1- Fluent API
// 2- Attributes(mais fáceis de serem implementados)