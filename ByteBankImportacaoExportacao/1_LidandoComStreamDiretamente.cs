using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var caminhoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(caminhoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024];

                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }

            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var encoding = Encoding.Default;

            var texto = encoding.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);

        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = Convert.ToInt32(campos[0]);

            var numero = Convert.ToInt32(campos[1]);

            var saldo = Convert.ToDouble(campos[2]);

            var nomeTitular = campos[3];

            var titular = new Cliente();

            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numero);

            resultado.Titular = titular;

            resultado.Depositar(saldo);

            return resultado;
        }

    }
}