using loterias_caixa;
using System;
using System.Collections.Generic;

namespace loterias_caixa_teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixaClient = new loterias_caixa.Loterias();
            var jogos = new List<List<int>>
            {
                new List<int> { 5, 29, 37, 41, 55, 60 },
                new List<int> { 7, 13, 23, 25, 40, 41 },
                new List<int> { 6, 24, 36, 40, 41, 58 }
            };

            caixaClient.OnError += ((Exception ex) => {
                Console.WriteLine($"Error: {ex.Message}");
            });

            var mega = caixaClient.Consulta(TipoJogo.MEGA_SENA);
            var lotofacil = caixaClient.Consulta(TipoJogo.LOTOFACIL);
            var quina = caixaClient.Consulta(TipoJogo.QUINA);
            var lotomania = caixaClient.Consulta(TipoJogo.LOTOMANIA);
            var timemania = caixaClient.Consulta(TipoJogo.TIMEMANIA);
            var diasorte = caixaClient.Consulta(TipoJogo.DIA_DE_SORTE);
            var supersete = caixaClient.Consulta(TipoJogo.SUPER_SETE);

            Console.WriteLine($"Resultado MegaSena {mega.Concurso}: {string.Join(", ", mega.DezenasOrdemCrescente.ToArray())}");
            Console.WriteLine();

            Console.WriteLine($"Resultado Lotofacil {lotofacil.Concurso}: {string.Join(", ", lotofacil.DezenasOrdemCrescente.ToArray())}");
            Console.WriteLine();

            foreach (var jogo in jogos)
                Console.WriteLine($"{string.Join(", ", jogo.ToArray())} possui {mega.Acertos(jogo)} acertos.");

            Console.WriteLine();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
