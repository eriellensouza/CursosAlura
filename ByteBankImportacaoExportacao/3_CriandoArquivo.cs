using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "ContasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {

                var contaComoString = "12345; 2345; 234.50; Gabriel Soares";

                var encoding = Encoding.Default;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static bool ArquivoCriado()
        {
            var caminhoNovoArquivo = "ContasExportadas.csv";

            if (File.Exists(caminhoNovoArquivo))
            {
                return true;
            }
            CriarArquivo();
            return false;
        }
    }
}