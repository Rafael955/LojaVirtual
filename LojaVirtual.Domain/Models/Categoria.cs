using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        /**
         * Nome da categoria: Telefone sem fio
         * Slug: telefone-sem-fio
         * URL normal: www.lojavirtual.com.br/categoria/5
         * URL amigável(com slug): www.lojavirutal.com.br/categoria/informatica (Url amigável)
         */
        public string Slug { get; set; }

        /**
         * Técnica Auto-relacionamento
         * Informática
         * - Mouse
         * -- Mouse sem fio
         * -- Mouse Gamer
         */

        public Guid? CategoriaPaiId { get; set; }

        /*
         * ORM - EntityFrameworkCore
         */

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
    }
}