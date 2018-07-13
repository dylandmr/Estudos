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
    public partial class Form2 : Form
    {
        Banco banco;

        public Form2()
        {
            InitializeComponent();
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            textoTitular.Text = banco.Contas[comboContas.SelectedIndex].Titular.Nome;
            textoNumero.Text = banco.Contas[comboContas.SelectedIndex].Numero.ToString();
            textoSaldo.Text = "R$"+banco.Contas[comboContas.SelectedIndex].Saldo.ToString("n2");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.banco = new Banco();

            for (int i = 0; i < 10; i++)
            {
                banco.Adiciona(new Conta(new Cliente("Titular "+ i)));
                banco.Contas[i].Deposita((i + 1) * 1000);
                banco.Contas[i].Numero = i + 1;
            }

            foreach (Conta conta in banco.Contas)
            {
                comboContas.Items.Add(conta.Titular.Nome);
            }
        }
    }
}
