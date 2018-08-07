using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class Conta
    {
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        public Conta() { }
        
        public Conta(string titular)
        {
            Titular = titular;
        }
        public void Deposita(double valor)
        {
            Saldo += valor;
        }
    }
}
