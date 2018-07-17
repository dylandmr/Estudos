using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Benner.AplicacaoCaixaEletronico.Usuario;
using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico
{
    public partial class CadastroDeContas : Form
    {
        private Form1 AplicacaoPrincipal;

        public CadastroDeContas(Form1 aplicacaoPrincipal)
        {
            this.AplicacaoPrincipal = aplicacaoPrincipal;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente_novo = new Cliente()
            {
                Nome = textoNome.Text,
                Rg = textoRG.Text,
                Cpf = textoCPF.Text,
                Endereco = textoEndereco.Text,
                Idade = Convert.ToInt32(textoIdade.Text)
            };

            ContaCorrente conta_nova = new ContaCorrente(cliente_novo)
            {
                Agencia = Convert.ToInt32(textoAgencia.Text),
                Numero = Convert.ToInt32(textoNumero.Text)
            };

            this.AplicacaoPrincipal.AdicionaConta(conta_nova);
            this.Close();
        }
    }
}
