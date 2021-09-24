using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Domain.Models
{
    public class Produto : Entity<int>
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        #region Frete Correios

        public double Peso { get; set; }

        public int Largura { get; set; }

        public int Altura { get; set; }

        public int Comprimento { get; set; }

        #endregion Frete Correios

        #region Relacionamento Entity Framework

        public int CategoriaId { get; set; } // Representa a chave estrangeira na tabela no BD

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; } //Propriedade Associativa --> Pega os dados de uma Categoria da tabela de Categorias.

        #endregion Relacionamento Entity Framework

        public ICollection<Imagem> Imagens { get; set; }
    }
}

//Banco de Dados - Relacionamento entre Tabelas
//POO - Associações entre Objetos
//Entity Framwork serve para unir esses dois: Banco de Dados à Programação Orientada a Objetos!!!
//EF é um ORM, faz o mapeamento objeto-relacional entre nossas classes em nosso Modelo e as Tabelas no Banco de Dados.
//Formas de mapeamento objeto-relacional:
// 1- Fluent API
// 2- Attributes(mais fáceis de serem implementados)