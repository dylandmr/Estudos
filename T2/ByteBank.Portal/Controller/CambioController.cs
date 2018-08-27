using ByteBank.Service;
using ByteBank.Service.Cambio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CambioController
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        public string MXN()
        {
            var valorCambio = _cambioService.Calcular("MXN", "BRL", 10);
            var assembly = Assembly.GetExecutingAssembly();

            var streamPagina = assembly.GetManifestResourceStream("ByteBank.Portal.View.Cambio.MXN.html");
            var streamLeitura = new StreamReader(streamPagina);

            var textoPagina = streamLeitura.ReadToEnd();

            var textoCalculado = textoPagina.Replace("VALOR_EM_BRL", valorCambio.ToString());

            return textoCalculado;
        }

        public string USD()
        {

            return null;
        }
    }
}
