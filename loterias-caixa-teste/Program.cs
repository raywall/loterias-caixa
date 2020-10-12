using loterias_caixa;
using System;
using System.Collections.Generic;

namespace loterias_caixa_teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new loterias_caixa.Loterias();
            var jogos = new List<List<int>>
            {
                new List<int> { 5, 29, 37, 41, 55, 60 },
                new List<int> { 7, 13, 23, 25, 40, 41 },
                new List<int> { 6, 24, 36, 40, 41, 58 }
            };

            client.OnError += ((Exception ex) => {
                Console.WriteLine($"Error: {ex.Message}");
            });

            var mega = client.Concurso(TipoJogo.MEGA_SENA);
            Console.WriteLine($"Resultado: {string.Join(", ", mega.DezenasOrdemCrescente.ToArray())}");
            
            Console.WriteLine();
            Console.WriteLine();

            foreach (var jogo in jogos)
                Console.WriteLine($"{string.Join(", ", jogo.ToArray())} possui {mega.Acertos(jogo)} acertos.");

            Console.ReadLine();
        }
    }
}
