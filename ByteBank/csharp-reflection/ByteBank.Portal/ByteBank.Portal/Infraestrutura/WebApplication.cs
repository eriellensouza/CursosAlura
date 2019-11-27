using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;

        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
            {
                throw new ArgumentNullException(nameof(prefixos));
            }                
            _prefixos = prefixos;
        }
        public void Iniciar()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
                httpListener.Prefixes.Add(prefixo);

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.AbsolutePath;

            if (path == "/Assets/css/styles.css")
            {
                //Retornar o documento
                var assembly = Assembly.GetExecutingAssembly();
                var nameSouce = "styles.css";

                var resourceStream = assembly.GetManifestResourceStream(nameSouce);
                var byteResource = new byte[resourceStream.Length];

                resourceStream.Read(byteResource, 0, (int)resourceStream.Length);

                //var respostaConteudo = "Olá amigos!";
                //var respostaConteudoBytes = Encoding.UTF8.GetBytes(respostaConteudo);

                resposta.ContentType = "text/html; charset=utf-8";
                resposta.StatusCode = 200; 
                resposta.ContentLength64 = resourceStream.Length;

                resposta.OutputStream.Write(byteResource, 0, byteResource.Length);
                resposta.OutputStream.Close();

            }
            else if (path == "/Assets/js/main.js")
            {
                //Retornar o documento
            }

            
            httpListener.Stop();
        }
    }
}
