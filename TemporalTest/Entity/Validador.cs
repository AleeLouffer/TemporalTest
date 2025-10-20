using System.Security.Cryptography;
using System.Text;

namespace TemporalTest.Entity
{
    public static class Validador
    {
        public static bool EstahValido(this List<Block> blocos)
        {
            for (int i = 1; i < blocos.Count; i++ )
            {
                var currentBlock = blocos[i];
                var previousBlock = blocos[i - 1];
                if (currentBlock.Hash != currentBlock.GenerateHash())
                {
                    return false;
                }
                if (currentBlock.OldHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;

         }
    }

    public class Block
    {
        public string? OldHash { get; set; }
        public string Hash { get; set; } = null!;
        public DateTime DataInsercao { get; set; }
        public string Dados { get; set; } = null!;

        public string GenerateHash()
        {
            var input = Encoding.ASCII.GetBytes($"{DataInsercao}-{OldHash ?? String.Empty}-{Dados}");
            var output = SHA256.HashData(input);
            return Convert.ToBase64String(output);
        }
    }
}
