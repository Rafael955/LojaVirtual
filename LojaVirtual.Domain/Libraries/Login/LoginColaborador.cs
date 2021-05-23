using LojaVirtual.Domain.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Domain.Libraries
{
    public class LoginColaborador
    {
        private string Key = "Login.Colaborador";
        private Sessao sessao;

        public LoginColaborador(Sessao sessao)
        {
            this.sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            //Serializar colaborador
            var colaboradorJson = JsonConvert.SerializeObject(colaborador);
            sessao.Cadastrar(Key, colaboradorJson);
        }

        public Colaborador ObterColaborador()
        {
            if (sessao.Existe(Key))
            {
                var colaboradorJson = sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJson);
            }

            return null;
        }

        public void Logout()
        {
            sessao.RemoverTodos();
        }
    }
}