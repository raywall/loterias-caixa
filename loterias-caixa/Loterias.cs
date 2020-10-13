using loterias_caixa.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Contracts;

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

        public MegaSena Megasena(int concurso = 0)
        {
            var resultado = new MegaSena();
            var pagina = string.Empty;

            var c = concurso == 0 
                ? string.Empty 
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<MegaSena>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Lotofacil Lotofacil(int concurso = 0)
        {
            var resultado = new Lotofacil();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotofacil/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA0sTIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAcySpRM!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0J0VSC0AC4GLFAD2003/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Lotofacil>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Quina Quina(int concurso = 0)
        {
            var resultado = new Quina();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/quina/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/quina/!ut/p/a1/jc69DoIwAATgZ_EJepS2wFgoaUswsojYxXQyTfgbjM9vNS4Oordd8l1yxJGBuNnfw9XfwjL78dmduIikhYFGA0tzSFZ3tG_6FCmP4BxBpaVhWQuA5RRWlUZlxR6w4r89vkTi1_5E3CfRXcUhD6osEAHA32Dr4gtsfFin44Bgdw9WWSwj/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0J0VSC0AC4GLFAD20G6/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Quina>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Lotomania Lotomania(int concurso = 0)
        {
            var resultado = new Lotomania();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotomania/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotomania/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA38jYEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAajYsZo!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0JGJVA0AKLR5T3K00V0/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Lotomania>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Timemania Timemania(int concurso = 0)
        {
            var resultado = new Timemania();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/timemania/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/timemania/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA1MzIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VASrq9qk!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0JGJVA0AKLR5T3K00M4/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Timemania>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public DuplaSena DuplaSena(int concurso = 0)
        {
            var resultado = new DuplaSena();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/duplasena/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/duplasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA2cDIAKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQGgnyPS/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_61L0H0G0J0I280A4EP2VJV30N4/res/id=buscaResultado/c=cacheLevelPage/{0}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<DuplaSena>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Federal LoteriaFederal(int concurso = 0)
        {
            var resultado = new Federal();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/federal/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/federal/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA0MzIAKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAYe29yM!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0K0L710QUKB6OH80004/res/id=buscaResultado/c=cacheLevelPage/{0}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Federal>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Loteca Loteca(int concurso = 0)
        {
            var resultado = new Loteca();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/loteca/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/loteca/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbz8vTxNDRy9_Y2NQ13CDA3cDYEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wBmoxN_FydLAGAgNTKEK8DkRrACPGwpyQyMMMj0VAbNnwlU!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KOCO10AFFGUTGU0004/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Loteca>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public Lotogol Lotogol(int concurso = 0)
        {
            var resultado = new Lotogol();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotogol/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/lotogol/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjE18zYAKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQFTuNFd/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KGBQD0ARPT1QLG1041/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<Lotogol>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public DiaSorte DiaDeSorte(int concurso = 0)
        {
            var resultado = new DiaSorte();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/diadesorte/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/diadesorte/!ut/p/a1/jc5BDsIgFATQs3gCptICXdKSfpA2ujFWNoaVIdHqwnh-sXFr9c_qJ2-SYYGNLEzxmc7xkW5TvLz_IE6WvCoUwZPwArpTnZWD4SCewTGDlrQtZQ-gVGs401gj6wFw4r8-vpzGr_6BhZmIoocFYUO7toLemqYGz0H1AUsTZ7Cw4X7dj0hu9QIyUWUw/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO5GE0Q8PTB11800G3/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<DiaSorte>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }

        public SuperSete SuperSete(int concurso = 0)
        {
            var resultado = new SuperSete();
            var pagina = string.Empty;

            var c = concurso == 0
                ? string.Empty
                : $"/p=concurso={concurso}";

            try
            {
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/supersete/");
                pagina = client.CarregarHtml($"{BaseURL}/wps/portal/loterias/landing/supersete/!ut/p/a1/jc5BDsIgEAXQs3gCPralsISSAFK1XaiVjWFlSLS6MJ5fbNxanVnN5P3kk0AGEsb4TOf4SLcxXt53YCdrPKfcwHOtGvTdfiMK31OgzOCYQWOkLesW-cOXcFpZXYs14Nh_eXwZiV_5AwkTYbSFhcHKdE0FudVKoMiL6gPmKk5gpsP9uhuQ3OIFKJSbBA!!/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0K85260Q5OIRSC420K6/res/id=buscaResultado/c=cacheLevelPage/{c}?timestampAjax={DateTime.Now.TimeStamp()}");

                if (string.IsNullOrEmpty(pagina))
                    return null;

                return JsonConvert.DeserializeObject<SuperSete>(pagina, new JsonSerializerSettings { DateFormatString = "dd/MM/yyyy" });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex);
            }

            return null;
        }
    }
}
