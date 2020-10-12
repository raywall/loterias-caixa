using Newtonsoft.Json;

namespace loterias_caixa.Models
{
    [JsonObject]
    public class Faixa
    {
        [JsonProperty("faixa")]
        public int ID { get; set; }

        [JsonProperty("numeroDeGanhadores")]
        public int NumeroGanhadores { get; set; }

        [JsonProperty("valorPremio")]
        public decimal ValorPremio { get; set; }

        [JsonProperty("descricaoFaixa")]
        public string Descricao { get; set; }
    }
}
