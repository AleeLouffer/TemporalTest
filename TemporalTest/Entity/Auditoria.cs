namespace TemporalTest.Entity
{
    public class Auditoria : Block
    {
        public string IP { get; set; } = null!;
        public string Localizacao { get; set; } = null!;
        public int PerfilAcessoInsercao { get; set; }

        internal void Criar(int usuarioInsercao)
        {
            DataInsercao = DateTime.Now.FormatarDateTime();
            PerfilAcessoInsercao = usuarioInsercao;
            IP = "Teste";
            Localizacao = "Teste";
        }

        internal void AtualizarAuditoria(int usuarioAtualizacao)
        {
            DataInsercao = DateTime.Now.FormatarDateTime();
            PerfilAcessoInsercao = usuarioAtualizacao;
            HashAnterior = Hash;
            IP = "Teste";
            Localizacao = "Teste";
        }
    }
}
