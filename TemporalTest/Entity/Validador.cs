using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace TemporalTest.Entity
{
    public static class Validador
    {
        public static bool EstahValido(this List<Block> blocos)
        {
            for (int i = 1; i < blocos.Count; i++ )
            {
                var blocoAtual = blocos[i];
                var blocoAnterior = blocos[i - 1];

                if (blocoAtual.Hash != blocoAtual.GenerateHash() 
                    || blocoAtual.HashAnterior != blocoAnterior.Hash)
                    return false;
            }
            return true;

         }
    }

    public class Block
    {
        public string? HashAnterior { get; set; }
        public string Hash { get; set; } = null!;
        public DateTime DataInsercao { get; set; }

        [JsonIgnore]
        public string Dados { get; set; } = null!;

        public string GenerateHash()
        {
            var input = Encoding.ASCII.GetBytes($"{DataInsercao}-{HashAnterior ?? String.Empty}-{Dados}");
            var output = SHA256.HashData(input);
            return Convert.ToBase64String(output);
        }
    }
}
