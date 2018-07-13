﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacaoCaixaEletronico
{
    public partial class Form1 : Form
    {
        //Conta conta = new Conta();
        //Cliente cliente = new Cliente("Victor");
        //Correção professor - só precisa declarar o atributo, não é necessário inicializá-lo:
        private Cliente cliente;
        private Conta conta;
        private ContaPoupanca contaPoupanca;

        //Correção professor, para evitar repetição de códigos, cria-se o método AtualizaTexto()
        private void AtualizaTexto()
        {
            textoTitular.Text = conta.Titular.Nome;
            textoSaldo.Text = conta.Saldo.ToString("n2");
            textoNumero.Text = conta.Numero.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            this.cliente = new Cliente("Victor");
            this.conta = new Conta(this.cliente);
            this.contaPoupanca = new ContaPoupanca(this.cliente);

            this.conta.Titular.Idade = 15;
            conta.Deposita(250.0);
            conta.Numero = 1;

            //textoTitular.Text = conta.Titular.Nome;
            //textoSaldo.Text = conta.Saldo.ToString("n2");
            //textoNumero.Text = conta.Numero.ToString();
            this.AtualizaTexto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conta.Deposita(Convert.ToDouble(textoValor.Text));
            //textoSaldo.Text = conta.Saldo.ToString("n2");
            this.AtualizaTexto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.conta.Saca(Convert.ToDouble(textoValor.Text))) this.AtualizaTexto();
            else MessageBox.Show("Saldo insuficiente.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.contaPoupanca.Titular.Idade = 20;
            this.contaPoupanca.Deposita(100);
            MessageBox.Show("Saldo após depósito: R$" + contaPoupanca.Saldo.ToString("n2"));
            this.contaPoupanca.Saca(10);
            MessageBox.Show("Saldo após saque: R$" + contaPoupanca.Saldo.ToString("n2"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //POLIMORFISMO: Método Adiciona da classe TotalizadorDeContas recebe uma Conta de referência
            //Porém aceita também ContaPoupanca e ContaCorrente, por serem filhas de Conta.

            TotalizadorDeContas totalizador = new TotalizadorDeContas();

            Conta c = new Conta(this.cliente);
            c.Deposita(100);
            totalizador.Adiciona(c);
            ContaPoupanca cp = new ContaPoupanca(this.cliente);
            cp.Deposita(200);
            totalizador.Adiciona(cp);
            ContaCorrente cc = new ContaCorrente(this.cliente);
            cc.Deposita(300);
            totalizador.Adiciona(cc);

            MessageBox.Show("Saldo total: R$" + totalizador.SaldoTotal.ToString("n2"));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cliente generico = new Cliente("Genérico");
            Conta[] contas = new Conta[10]; // <- Arrays em C# - Sintaxe.

            contas[0] = new Conta(generico);            //
            contas[1] = new ContaPoupanca(generico);    // POLIMORFISMO se aplica.
            contas[2] = new ContaCorrente(generico);    //

            int i;

            for (i = 3; i < 10; i++) contas[i] = new Conta(generico); // <- Populando array automaticamente.

            //MÉTODOS PARA PERCORRER:

            for (i = 0; i < contas.Length; i++ ) // <- .Length retorna o tamanho da array.
            {
                contas[i].Deposita((i+1)*100);
            }

            //ou FOREACH:
            i = 0;
            foreach (Conta conta in contas)
            {
                i++;
                MessageBox.Show("Saldo da conta "+ i + ": R$" + conta.Saldo.ToString("n2"));
            }
        }
    }
}
