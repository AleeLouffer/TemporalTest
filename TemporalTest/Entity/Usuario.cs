using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TemporalTest.DTO;

namespace TemporalTest.Entity
{
    public class Usuario : Auditoria
    {
        public Usuario() { }

        public Usuario(CriarAtualizarUsuarioDTO model)
        {
            Nome = model.Nome;
            Login = model.Login;
            Email = model.Email;
            Senha = model.Senha;
            SituacaoId = 1;
            Criar(JsonConvert.SerializeObject(this), 1);
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public int SituacaoId { get; set; }

        internal void Atualizar(CriarAtualizarUsuarioDTO model)
        {
            Nome = model.Nome;
            Login = model.Login;
            Email = model.Email;
            Senha = model.Senha;
            SituacaoId = 2;
            AtualizarAuditoria(JsonConvert.SerializeObject(this), 1);
        }
    }
}
