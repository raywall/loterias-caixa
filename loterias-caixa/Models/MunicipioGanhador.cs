using Newtonsoft.Json;

namespace loterias_caixa.Models
{
    [JsonObject]
    public class MunicipioGanhador
    {
        [JsonProperty("posicao")]
        public int Posicao { get; set; }

        [JsonProperty("ganhadores")]
        public int Ganhadores { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }
    }
}
