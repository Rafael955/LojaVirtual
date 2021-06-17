using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Categoria : Entity<int>
    {
        [Display(Name = "Código")]
        public override int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(4, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        //TODO - Criar validação de nome único de categoria no banco de dados.
        public string Nome { get; set; }

        /**
         * Nome da categoria: Telefone sem fio
         * Slug: telefone-sem-fio
         * URL normal: www.lojavirtual.com.br/categoria/5
         * URL amigável(com slug): www.lojavirutal.com.br/categoria/informatica (Url amigável)
         */

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(4, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Slug { get; set; }

        /**
         * Técnica Auto-relacionamento
         * Informática
         * - Mouse
         * -- Mouse sem fio
         * -- Mouse Gamer
         */

        [Display(Name = "Categoria Pai")]  //Usar caso queira renderizar os nomes das labels no html sem definir entre as tags, sem o annotation Display o nome exibido seria CategoriaPaiId
        public int? CategoriaPaiId { get; set; }

        /*
         * ORM - EntityFrameworkCore
         */

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
    }
}