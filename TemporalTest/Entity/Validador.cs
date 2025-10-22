using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace TemporalTest.Entity
{
    public class BlockValidator<T> where T: Block
    {
        public bool EstahValido(List<T> blocos)
        {
            for (int i = 1; i < blocos.Count; i++ )
            {
                var blocoAtual = blocos[i];
                var blocoAnterior = blocos[i - 1];
                blocoAtual.DataInsercao = blocoAtual.DataInsercao.FormatarDateTime();

                var hashAtual = blocoAtual.GenerateHash(JsonConvert.SerializeObject(blocoAtual));

                if (blocoAtual.Hash != hashAtual
                    || blocoAtual.HashAnterior != blocoAnterior.Hash)
                    return false;
            }
            return true;

         }
    }

    public class Block
    {
        [JsonIgnore]
        public string? HashAnterior { get; set; }
        [JsonIgnore]
        public string Hash { get; set; } = null!;
        public DateTime DataInsercao { get; set; }

        public string GenerateHash(string dados)
        {
            var input = Encoding.ASCII.GetBytes($"{DataInsercao}-{HashAnterior ?? String.Empty}-{dados}");
            var output = SHA256.HashData(input);
            return Convert.ToBase64String(output);
        }
    }

    public static class Funcoes
    {
        public static DateTime FormatarDateTime(this DateTime data) => new(data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second);
    }
}
