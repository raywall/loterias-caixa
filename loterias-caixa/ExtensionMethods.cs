using Mono.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;

namespace loterias_caixa
{
    public enum TipoJogo
    {
        MEGA_SENA = 0,
        LotoFacil = 1,
        Quina = 2,
        LotoMania = 3,
        TimeMania = 4,
        DuplaSena = 5,
        Federal = 6,
        Loteca = 7,
        LotoGol = 8,
        DiaSorte = 9,
        SuperSete = 10
    }

    public static class ExtensionMethods
    {
        private const int BUFFER_SIZE = 1024;

        public static string DataEncoder(this string value)
        {
            try
            {
                return HttpUtility.UrlEncode(Encoding.GetEncoding("ISO-8859-1").GetBytes(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] ReadAllBytes(this Stream stream)
        {
            var buffer = new byte[BUFFER_SIZE];
            var bytesRead = 0;
            var inStream = new BufferedStream(stream);
            var outStream = new MemoryStream();

            while ((bytesRead = inStream.Read(buffer, 0, BUFFER_SIZE)) > 0)
                outStream.Write(buffer, 0, bytesRead);

            return outStream.GetBuffer();
        }

        public static Dictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            var dict = new Dictionary<string, string>();

            try
            {
                foreach (var key in collection.AllKeys)
                    dict.Add(key, collection[key]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dict;
        }

        public static int ToInt(this string value)
        {
            int.TryParse(value, out int result);
            return result;
        }

        public static DateTime ToDate(this string value)
        {
            DateTime.TryParse(value, out DateTime date);
            return date;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal.TryParse(value.Replace(".", ","), out decimal result);
            return result;
        }

        public static string TimeStamp(this DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static int Acertos(this Models.MegaSena mega, List<int> jogo)
        {
            var acertos = 0;

            try
            {
                foreach (var n in jogo)
                    acertos += mega.DezenasSorteadas.Contains(n) ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return acertos;
        }
    }
}
