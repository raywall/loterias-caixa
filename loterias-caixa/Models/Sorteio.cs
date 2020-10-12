using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace loterias_caixa.Models
{
    [Serializable]
    [JsonObject]
    public class Sorteio
    {
        [JsonProperty("tipoJogo")]
        public TipoJogo Jogo { get; set; }

        [JsonProperty("numero")]
        public int Concurso { get; set; }

        [JsonProperty("nomeMunicipioUFSorteio")]
        public string MunicipioSorteio { get; set; }

        [JsonProperty("dataApuracao")]
        public DateTime DataApuracao { get; set; }

        [JsonProperty("dataProximoConcurso")]
        public DateTime DataProximoConcurso { get; set; }

        [JsonProperty("valorArrecadado")]
        public decimal ValorArrecadado { get; set; }

        [JsonProperty("valorEstimadoProximoConcurso")]
        public decimal ValorEstimadoProximoConcurso { get; set; }

        [JsonProperty("valorAcumuladoProximoConcurso")]
        public decimal ValorAcumuladoProximoConcurso { get; set; }

        [JsonProperty("valorAcumuladoConcursoEspecial")]
        public decimal ValorAcumuladoConcursoEspecial { get; set; }

        [JsonProperty("valorAcumuladoConcurso_0_5")]
        public decimal ValorAcumuladoConcursoZero { get; set; }

        [JsonProperty("acumulado")]
        public bool Acumulado { get; set; }

        [JsonProperty("indicadorConcursoEspecial")]
        public int IndicadorConcursoEspecial { get; set; }

        [JsonProperty("dezenasSorteadasOrdemSorteio")]
        public List<int> DezenasSorteadas { get; set; }

        public List<int> DezenasOrdemCrescente => DezenasSorteadas.OrderBy(o => o).ToList();

        [JsonProperty("listaMunicipioUFGanhadores")]
        public List<MunicipioGanhador> Ganhadores { get; set; }

        [JsonProperty("listaRateioPremio")]
        public List<Faixa> Rateio { get; set; }
    }
}
