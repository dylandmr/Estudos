using System;
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
        Conta conta = new Conta();
        Cliente cliente = new Cliente("Victor");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conta.Titular = cliente;
            conta.Deposita(250.0);
            conta.Numero = 1;
            textoTitular.Text = conta.Titular.Nome;
            textoSaldo.Text = conta.Saldo.ToString("n2");
            textoNumero.Text = conta.Numero.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conta.Deposita(Convert.ToDouble(textoValor.Text));
            textoSaldo.Text = conta.Saldo.ToString("n2");
        }
    }
}
