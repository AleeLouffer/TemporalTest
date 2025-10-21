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
            var jsSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            Dados = JsonConvert.SerializeObject(obj, formatting: Formatting.None, jsSettings);
            DataInsercao = DateTime.Now; ;
            PerfilAcessoInsercao = usuarioInsercao;
            IP = "TEste";
            Localizacao = "Teste";
            Hash = GenerateHash();
        }

        internal void AtualizarAuditoria(string obj, int usuarioAtualizacao)
        {
            var jsSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            Dados = JsonConvert.SerializeObject(obj, formatting: Formatting.None, jsSettings);
            DataInsercao = DateTime.Now;
            PerfilAcessoInsercao = usuarioAtualizacao;
            HashAnterior = Hash;
            IP = "TEste";
            Localizacao = "Teste";
            Hash = GenerateHash();
        }
    }
}
