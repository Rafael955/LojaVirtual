using LojaVirtual.Domain.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Domain.Libraries
{
    /// <summary>
    /// Classe que gerencia uma Sessão com os dados do Login do Cliente
    /// </summary>
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao sessao;

        public LoginCliente(Sessao sessao)
        {
            this.sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Serializar cliente
            var clienteJson = JsonConvert.SerializeObject(cliente);
            sessao.Cadastrar(Key, clienteJson);
        }

        public Cliente ObterCliente()
        {
            if (sessao.Existe(Key))
            {
                var clienteJson = sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJson);
            }

            return null;
        }

        public void Logout()
        {
            sessao.RemoverTodos();
        }
    }
}