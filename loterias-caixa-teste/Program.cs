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

            var mega = caixaClient.Megasena();
            var lotofacil = caixaClient.Lotofacil();
            var quina = caixaClient.Quina();
            var lotomania = caixaClient.Lotomania();
            var timemania = caixaClient.Timemania();
            var duplasena = caixaClient.DuplaSena();
            var federal = caixaClient.LoteriaFederal();
            var loteca = caixaClient.Loteca();
            var lotogol = caixaClient.Lotogol();
            var diasorte = caixaClient.DiaDeSorte();
            var supersete = caixaClient.SuperSete();

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
