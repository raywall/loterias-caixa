using Newtonsoft.Json;
using System.Collections.Generic;

namespace loterias_caixa.Models
{
    public class DuplaSena : Sorteio
    {
        [JsonProperty("listaDezenas")]
        public List<int> DezenasPrimeiroSorteio { get; set; }

        [JsonProperty("listaDezenasSegundoSorteio")]
        public List<int> DezenasSegundoSorteio { get; set; }
    }
}
