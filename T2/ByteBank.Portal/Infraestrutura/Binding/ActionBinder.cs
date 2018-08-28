using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBinder
    {
        public object ObterMethodInfo(object controller, string path)
        {
            // /Cambio/Calculo?moedaOrigem=BRL&moedaDestino=USD&valor=10
            // /Cambio/Calculo?moedaDestino=USD&moedaOrigem=BRL&valor=10
            // /Cambio/Calculo?valor=10&moedaOrigem=BRL&moedaDestino=USD
            // /Cambio/Calculo?moedaDestino=USD&valor=10

            var indexInterrogacao = path.IndexOf('?');
            var temInterrogacao = (indexInterrogacao >= 0);

            if (!temInterrogacao)
            {
                var nomeAction = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                controller.GetType().InvokeMember("Calcular", BindingFlags.DeclaredOnly, null, null, new object[2]);
                return controller.GetType().GetMethod(nomeAction);     
            }
            else
            {
                var nomeControllereActionSemParametros = path.Substring(0, indexInterrogacao);
                var nomeAction = nomeControllereActionSemParametros.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];

                var queryString = path.Substring(indexInterrogacao + 1);

                var argumentosNomeValor = ObterArgumentoNomeValores(queryString);
            }
        }

        private IEnumerable<ArgumentoNomeValor> ObterArgumentoNomeValores(string queryString)
        {
            var argumentosSeparados = queryString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var argumento in argumentosSeparados)
            {
                var nomeEValorArgumento = argumento.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                yield return new ArgumentoNomeValor(nomeEValorArgumento[0], nomeEValorArgumento[1]);
            }
        }
    }
}
