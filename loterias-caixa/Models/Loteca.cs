using Newtonsoft.Json;
using System.Collections.Generic;

namespace loterias_caixa.Models
{
    public class Loteca : Sorteio
    {
        [JsonProperty("listaResultadoEquipeEsportiva")]
        public List<EquipeEsportiva> ResultadoEquipeEsportiva { get; set; }
    }
}
