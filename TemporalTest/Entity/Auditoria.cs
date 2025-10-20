using Newtonsoft.Json;

namespace TemporalTest.Entity
{
    public class Auditoria : Block
    {
        public string IP { get; set; } = null!;
        public string Localizacao { get; set; } = null!;
        public int PerfilAcessoInsercao { get; set; }

        internal void Criar(string obj, int usuarioInsercao)
        {
            Dados = JsonConvert.SerializeObject(obj);
            DataInsercao = DateTime.Now; ;
            PerfilAcessoInsercao = usuarioInsercao;
            IP = "TEste";
            Localizacao = "Teste";
            Hash = GenerateHash();
        }

        internal void AtualizarAuditoria(string obj, int usuarioAtualizacao)
        {
            Dados = JsonConvert.SerializeObject(obj);
            DataInsercao = DateTime.Now;
            PerfilAcessoInsercao = usuarioAtualizacao;
            OldHash = Hash;
            IP = "TEste";
            Localizacao = "Teste";
            Hash = GenerateHash();
        }
    }
}
