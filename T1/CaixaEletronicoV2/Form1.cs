using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronicoV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta novaconta = new Conta();
            Cliente novocliente = new Cliente();

            novaconta.titular = novocliente;

            novocliente.rg = "6653359";

            novaconta.titular.cpf = "096.387.469-12";

            novaconta.saldo = 10000.0;

            MessageBox.Show("RG: " + novocliente.rg + "\nCPF: " + novaconta.titular.cpf);
            //Tanto novaconta.cliente.<campo> quanto cliente.<campo> referenciam o MESMO objeto.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.idade = 17;
            MessageBox.Show(cliente.MaiordeIdade() ? "É maior de idade." : "É menor de idade."); 
        }
    }
}
