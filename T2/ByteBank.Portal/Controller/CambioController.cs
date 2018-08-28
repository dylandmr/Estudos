using ByteBank.Portal.Infraestrutura;
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
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        public string MXN()
        {
            return View().Replace("VALOR_EM_BRL", _cambioService.Calcular("MXN", "BRL", 3).ToString());
        }

        public string USD()
        {
            return View().Replace("VALOR_EM_BRL", _cambioService.Calcular("USD", "BRL", 3).ToString());
        }
    }
}
