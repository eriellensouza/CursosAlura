using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args)
        {
            CriarArquivo();

            if (ArquivoCriado())
            {
                Console.WriteLine("Arquivo criado com sucesso!!");
            }
            
            Console.ReadLine();
        }       
    }    
} 
 