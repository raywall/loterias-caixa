using Newtonsoft.Json;
using System;

namespace loterias_caixa.Models
{
    [JsonObject]
    public class EquipeEsportiva
    {
        [JsonProperty("nuSequencial")]
        public int ID { get; set; }

        [JsonProperty("nuJogo")]
        public int Jogo { get; set; }

        [JsonProperty("nuConcurso")]
        public int Concurso { get; set; }

        [JsonProperty("dtJogo")]
        public DateTime DataJogo { get; set; }

        [JsonProperty("nomeEquipeUm")]
        public string EquipeUm { get; set; }

        [JsonProperty("siglaUFUm")]
        public string UFEquipeUm { get; set; }

        [JsonProperty("siglaPaisUm")]
        public string PaisEquipeUm { get; set; }

        [JsonProperty("nuGolEquipeUm")]
        public int GolsEquipeUm { get; set; }

        [JsonProperty("nomeEquipeDois")]
        public string EquipeDois { get; set; }

        [JsonProperty("siglaUFDois")]
        public string UFEquipeDois { get; set; }

        [JsonProperty("siglaPaisDois")]
        public string PaisEquipeDois { get; set; }

        [JsonProperty("nuGolEquipeDois")]
        public int GoolsEquipeDois { get; set; }

        [JsonProperty("nomeCampeonato")]
        public string Campeonato { get; set; }

        [JsonProperty("icSorteioResultado")]
        public int SorteioResultado { get; set; }

        [JsonProperty("diaSemana")]
        public string DiaSemana { get; set; }
    }
}
