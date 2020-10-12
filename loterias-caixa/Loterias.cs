using loterias_caixa.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace loterias_caixa
{
    public class Loterias
    {
        private RequisicaoHttp client = null;
        private string BaseURL = "http://loterias.caixa.gov.br/";

        #region Events
        public delegate void ErrorOcurredHandler(Exception ex);
        public event ErrorOcurredHandler OnError;
        #endregion

        public Loterias()
        {
            client = new RequisicaoHttp(true);

            client.AcceptHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36";
            client.AcceptLanguage = "pt-BR,pt;q=0.9";
            client.Timeout = 3000;
        }

        public MegaSena Concurso(TipoJogo jogo, int concurso = 0)
        {
            var resultado = new MegaSena();
            var pagina = string.Empty;
            var c = concurso == 0 ? string.Empty : $"/p=concurso={concurso}";
            try
            {
                switch (jogo)
                {
                    case TipoJogo.MEGA_SENA:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/megasena/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                        if (string.IsNullOrEmpty(pagina))
                            return null;

                        return JsonConvert.DeserializeObject<MegaSena>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" }); ;
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }
    }
}
