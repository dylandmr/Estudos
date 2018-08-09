using CursoDesignPatterns.State.Exercício___Estados_Conta;
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
        public double Saldo { get; set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public IEstadoConta EstadoSaldo { get; set; }

        public Conta()
        {
            EstadoSaldo = new Positivo();
        }
        
        public Conta(string titular)
        {
            Titular = titular;
            EstadoSaldo = new Positivo();
        }

        public Conta(string titular, int agencia, int numero)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            EstadoSaldo = new Positivo();
        }

        public Conta(string titular, int agencia, int numero, DateTime dataAbertura)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            DataAbertura = dataAbertura;
            EstadoSaldo = new Positivo();
        }

        public void Deposita(double valor)
        {
            EstadoSaldo.Deposita(this, valor);
        }

        public void Saca(double valor)
        {
            EstadoSaldo.Saca(this, valor);
        }
    }
}
