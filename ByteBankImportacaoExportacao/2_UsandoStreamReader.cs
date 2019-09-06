using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsanrStreamReader()
        {
            var caminhoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo, Encoding.Default))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Nome Tiular: {contaCorrente.Titular.Nome}\n" +
                              $"O número da conta: {contaCorrente.Numero}\n" +
                              $"Agência: {contaCorrente.Agencia}\n" +
                              $"Saldo da conta: {contaCorrente.Saldo}\n\n\n";

                    Console.WriteLine(msg);
                }
            }

        }
          
    }
}