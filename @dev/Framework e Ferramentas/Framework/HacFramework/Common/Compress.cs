using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace HospitalAnaCosta.Framework.Compress
{
    public class HacCompress
    {

        public HacCompress()
        {
        }
        /// <summary>
        /// Compacta o array informado
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>array compactado</returns>
        public static byte[] Compactar(byte[] bytes)
        {
            MemoryStream MSsaida = new MemoryStream();
            GZipStream gzip = new GZipStream(MSsaida,
                              CompressionMode.Compress, true);
            gzip.Write(bytes, 0, bytes.Length);
            gzip.Close();

            gzip.Dispose();

            gzip = null;

            return MSsaida.ToArray();
        }


        /// <summary>
        /// Descompacta o array informado
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>array Descompactado</returns>
        public static byte[] Descompactar(byte[] bytes)
        {
            MemoryStream MSentrada = new MemoryStream();
            MSentrada.Write(bytes, 0, bytes.Length);
            MSentrada.Position = 0;
            GZipStream gzip = new GZipStream(MSentrada,
                              CompressionMode.Decompress, true);
            MemoryStream MSsaida = new MemoryStream();
            byte[] buffer = new byte[64];
            int leitura = -1;
            leitura = gzip.Read(buffer, 0, buffer.Length);
            while (leitura > 0)
            {
                MSsaida.Write(buffer, 0, leitura);
                leitura = gzip.Read(buffer, 0, buffer.Length);
            }
            gzip.Close();

            gzip.Dispose();

            gzip = null;
            return MSsaida.ToArray();
        }
    }
}
