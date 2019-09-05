using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args)
        {
            var caminhoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo, Encoding.Default))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    Console.WriteLine($"O número da conta: {contaCorrente.Numero}\n"+
                                      $"Agência: {contaCorrente.Agencia}\n" +
                                      $"Nome Tiular: {contaCorrente.Titular.Nome}\n" +
                                      $"Saldo da conta: {contaCorrente.Saldo}\n\n\n");
                    //Console.WriteLine(linha);
                }
            }           

            Console.ReadLine();
        }       
    }    
} 
 