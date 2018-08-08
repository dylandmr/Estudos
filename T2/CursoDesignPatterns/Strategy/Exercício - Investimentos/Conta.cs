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
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public DateTime DataAbertura { get; private set; }

        public Conta() { }
        
        public Conta(string titular)
        {
            Titular = titular;
        }

        public Conta(string titular, int agencia, int numero)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
        }

        public Conta(string titular, int agencia, int numero, DateTime dataAbertura)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            DataAbertura = dataAbertura;
        }

        public void Deposita(double valor)
        {
            Saldo += valor;
        }
    }
}
