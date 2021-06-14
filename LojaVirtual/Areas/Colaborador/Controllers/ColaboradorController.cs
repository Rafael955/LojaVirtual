﻿using LojaVirtual.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuColaborador = LojaVirtual.Domain.Models.Colaborador;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [Route("[area]/[controller]")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pagina)
        {
            var colaboradores = await _colaboradorRepository.ObterTodosPaginado(pagina);
            return View(colaboradores);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Cadastrar([FromForm] MeuColaborador colaborador)
        {
            return View();
        }

        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            return View();
        }

        [HttpPost("[action]/{id:guid}")]
        public async Task<IActionResult> Atualizar([FromForm] MeuColaborador colaborador, Guid id)
        {
            return View();
        }

        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            return View();
        }
    }
}