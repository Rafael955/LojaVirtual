﻿using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IColaboradorRepository : IRepository<Colaborador, Guid>
    {
        Task<Colaborador> Login(string email, string senha);

        Task<Colaborador> AtualizarSenha(Colaborador colaborador);
    }
}