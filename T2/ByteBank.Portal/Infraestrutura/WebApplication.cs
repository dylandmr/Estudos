using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;

        public WebApplication(string[] prefixos)
        {
            _prefixos = prefixos ?? throw new ArgumentNullException(nameof(prefixos));
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
                httpListener.Prefixes.Add(prefixo);

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;
            var path = requisicao.Url.AbsolutePath;
            var assembly = Assembly.GetExecutingAssembly();

            switch (path)
            {
                case "/Assets/css/styles.css":
                    //Retorna o styles.css
                    var resourceStream = assembly.GetManifestResourceStream("ByteBank.Portal.Assets.css.styles.css");
                    var bytesResource = new byte[resourceStream.Length];

                    resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);

                    resposta.ContentType = "text/css; charset=utf-8";

                    resposta.StatusCode = 200;

                    resposta.ContentLength64 = resourceStream.Length;

                    resposta.OutputStream.Write(bytesResource, 0, bytesResource.Length);

                    resposta.OutputStream.Close();

                    break;
                case "/Assets/js/main.js":
                    //Retorna o main.js
                    resourceStream = assembly.GetManifestResourceStream("ByteBank.Portal.Assets.js.main.js");
                    bytesResource = new byte[resourceStream.Length];

                    resourceStream.Read(bytesResource, 0, (int)resourceStream.Length);

                    resposta.ContentType = "application/js; charset=utf-8";

                    resposta.StatusCode = 200;

                    resposta.ContentLength64 = resourceStream.Length;

                    resposta.OutputStream.Write(bytesResource, 0, bytesResource.Length);

                    resposta.OutputStream.Close();

                    break;
            }

            httpListener.Stop();
        }
    }
}
