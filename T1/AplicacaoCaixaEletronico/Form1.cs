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
            if (conta.Saca(Convert.ToDouble(textoValor.Text))) this.AtualizaTexto();
            else MessageBox.Show("Saldo insuficiente.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliente clientePoupanca = new Cliente("Teste");
            ContaPoupanca contaPoupanca = new ContaPoupanca(clientePoupanca);
            contaPoupanca.Titular.Idade = 20;
            contaPoupanca.Deposita(100);
            contaPoupanca.Saca(10);
            MessageBox.Show("Novo saldo: R$" + contaPoupanca.Saldo.ToString("n2"));
        }
    }
}
