using loterias_caixa.Models;
using Newtonsoft.Json;
using System;

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

        public Sorteio Consulta(TipoJogo jogo, int concurso = 0)
        {
            var resultado = new Sorteio();
            var pagina = string.Empty;
            var c = concurso == 0 ? string.Empty : $"/p=concurso={concurso}";
            try
            {
                switch (jogo)
                {
                    case TipoJogo.MEGA_SENA:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.LOTOFACIL:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA0sTIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAcySpRM!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0J0VSC0AC4GLFAD2003/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.QUINA:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/quina/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/quina/!ut/p/a1/jc69DoIwAATgZ_EJepS2wFgoaUswsojYxXQyTfgbjM9vNS4Oordd8l1yxJGBuNnfw9XfwjL78dmduIikhYFGA0tzSFZ3tG_6FCmP4BxBpaVhWQuA5RRWlUZlxR6w4r89vkTi1_5E3CfRXcUhD6osEAHA32Dr4gtsfFin44Bgdw9WWSwj/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0J0VSC0AC4GLFAD20G6/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.LOTOMANIA:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotomania/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotomania/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA38jYEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAajYsZo!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0JGJVA0AKLR5T3K00V0/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.TIMEMANIA:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/timemania/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/timemania/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA1MzIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VASrq9qk!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0JGJVA0AKLR5T3K00M4/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.DIA_DE_SORTE:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/diadesorte/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/diadesorte/!ut/p/a1/jc5BDsIgFATQs3gCptICXdKSfpA2ujFWNoaVIdHqwnh-sXFr9c_qJ2-SYYGNLEzxmc7xkW5TvLz_IE6WvCoUwZPwArpTnZWD4SCewTGDlrQtZQ-gVGs401gj6wFw4r8-vpzGr_6BhZmIoocFYUO7toLemqYGz0H1AUsTZ7Cw4X7dj0hu9QIyUWUw/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO5GE0Q8PTB11800G3/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;

                    case TipoJogo.SUPER_SETE:
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/supersete/");
                        pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/supersete/!ut/p/a1/jc5BDsIgEAXQs3gCPralsISSAFK1XaiVjWFlSLS6MJ5fbNxanVnN5P3kk0AGEsb4TOf4SLcxXt53YCdrPKfcwHOtGvTdfiMK31OgzOCYQWOkLesW-cOXcFpZXYs14Nh_eXwZiV_5AwkTYbSFhcHKdE0FudVKoMiL6gPmKk5gpsP9uhuQ3OIFKJSbBA!!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0K85260Q5OIRSC420K6/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");
                        break;
                }

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Sorteio>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }
    }
}
