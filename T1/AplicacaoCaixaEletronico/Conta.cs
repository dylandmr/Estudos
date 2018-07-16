using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benner.AplicacaoCaixaEletronico.Usuario;

namespace Benner.AplicacaoCaixaEletronico.Contas
{
    abstract class Conta
    {
        private Cliente titular;

        public int Numero { get; set; }
        public double Saldo { get; protected set; }
        public int Agencia { get; set; }
        public Cliente Titular { get; set; }

        public Conta(Cliente titular)
        {
            this.Titular = titular;
        }

        public abstract void Saca(double valor);

        public virtual void Deposita(double valor)
        {
            if (valor > 0) this.Saldo += valor;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public double RendimentoAnual()
        {
            double saldoprevisto = this.Saldo;
            for (int i = 0; i < 12; i++) saldoprevisto *= 1.007;
            return (saldoprevisto - this.Saldo);
        }
    }
}
