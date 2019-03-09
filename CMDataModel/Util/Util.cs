using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace CMDataModel.Util
{
    public static class Util
    {
        public static string DecompressGZip(string text)
        {
            var bytes = Convert.FromBase64String(text);

            using (var msi = new MemoryStream(bytes))

            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    var bytesAux = new byte[4096];

                    int cnt;

                    while ((cnt = gs.Read(bytesAux, 0, bytesAux.Length)) != 0)
                        mso.Write(bytesAux, 0, cnt);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static string FormatarCnpjCpf(string cnpjCpf)
        {
            if (string.IsNullOrEmpty(cnpjCpf))
                return string.Empty;

            if (cnpjCpf.Count() == 14)
                return Convert.ToUInt64(cnpjCpf).ToString(@"00\.000\.000\/0000\-00");

            if (cnpjCpf.Count() == 11)
                return Convert.ToUInt64(cnpjCpf).ToString(@"000\.000\.000\-00");

            return cnpjCpf;
        }

        public static string FormatarIe(string Ie)
        {
            if (string.IsNullOrEmpty(Ie))
                return string.Empty;

            if (Ie.Count() == 12)
                return Convert.ToUInt64(Ie).ToString(@"000\.000\.000\.000");

            return Ie;
        }

        public static void TransferirValoresPropriedadesObjeto<T>(T objetoOrigem, T objetoDestino)
        {
            foreach (var propriedade in typeof(T).GetProperties())
            {
                if (!propriedade.CanWrite)
                    return;

                if (propriedade.PropertyType == typeof(string)
                   || propriedade.PropertyType == typeof(int)
                   || propriedade.PropertyType == typeof(int?)
                   || propriedade.PropertyType == typeof(decimal)
                   || propriedade.PropertyType == typeof(decimal?)
                   || propriedade.PropertyType == typeof(bool)
                   || propriedade.PropertyType == typeof(bool?)
                   || propriedade.PropertyType == typeof(char)
                   || propriedade.PropertyType == typeof(char?)
                   || propriedade.PropertyType == typeof(DateTime)
                   || propriedade.PropertyType == typeof(DateTime?))

                    propriedade.SetValue(objetoDestino, propriedade.GetValue(objetoOrigem));
            }
        }
    }
}
