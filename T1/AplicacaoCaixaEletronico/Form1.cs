using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Benner.AplicacaoCaixaEletronico.Contas;
using Benner.AplicacaoCaixaEletronico.Processamento;
using Benner.AplicacaoCaixaEletronico.Usuario;
using Benner.AplicacaoCaixaEletronico.Excecoes;

namespace Benner.AplicacaoCaixaEletronico
{
    public partial class Form1 : Form
    {
        Banco banco;
        //Conta conta = new Conta();
        //Cliente cliente = new Cliente("Victor");
        //Correção professor - só precisa declarar o atributo, não é necessário inicializá-lo:
        private Cliente cliente;
        private Conta conta;
        private ContaPoupanca contaPoupanca;

        //Correção professor, para evitar repetição de códigos, cria-se o método AtualizaTexto()
        private void AtualizaTexto()
        {
            ContaComNome contacomnome = (ContaComNome)comboContas.SelectedItem;
            textoTitular.Text = contacomnome.Conta.Titular.ToString();
            textoNumero.Text = contacomnome.Conta.Numero.ToString();
            textoSaldo.Text = "R$" + contacomnome.Conta.Saldo.ToString("n2");

            //Deprecado - Código de exercícios anteriores:
            //textoTitular.Text = conta.Titular.Nome;
            //textoSaldo.Text = conta.Saldo.ToString("n2");
            //textoNumero.Text = conta.Numero.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //VARIÁVEIS IMPLÍCITAS - Tipo "var":
            var tamanho = 5; // <- Inteira;
            var nome = "teste"; // <- String;
            var umcliente = new Cliente(); // <- Funciona com objetos
            //var qualquer;    <- NÃO COMPILA | Pois a variável implícita requer atribuição de valor 
            //var nula = null; <- NÃO COMPILA | na declaração.

            this.banco = new Banco();

            this.cliente = new Cliente("Victor");
            this.cliente.Idade = 17;
            this.conta = new ContaCorrente(this.cliente);
            banco.Contas[0] = this.conta;
            //this.contaPoupanca = new ContaPoupanca(new Cliente("Cliente Poupança"));
            //banco.Contas[1] = this.contaPoupanca;

            this.conta.Titular.Idade = 15;
            conta.Deposita(250.0);
            conta.Numero = 1;

            comboContas.DisplayMember = "Nome";
            destinoDaTransferencia.DisplayMember = "Nome";

            comboContas.Items.Add(new ContaComNome(banco.Contas[0]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContaComNome contacomnome = (ContaComNome)comboContas.SelectedItem;
            contacomnome.Conta.Deposita(Convert.ToDouble(textoValor.Text));
            //textoSaldo.Text = conta.Saldo.ToString("n2");
            this.AtualizaTexto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ContaComNome contacomnome = (ContaComNome)comboContas.SelectedItem;
                contacomnome.Conta.Saca(Convert.ToDouble(textoValor.Text));
                this.AtualizaTexto();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show("Valor inválido.");
            }
            catch (SaldoInsuficienteException exception)
            {
                MessageBox.Show("Saldo insuficiente.");
            }
            catch (SaqueMenorDeIdadeException exception)
            {
                MessageBox.Show("Valor acima do limite para menores de idade.");
            }
            finally
            {
                textoValor.Text = null;
            }
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

            Conta c = new ContaCorrente(this.cliente);
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

            contas[0] = new ContaCorrente(generico);            //
            contas[1] = new ContaPoupanca(generico);    // POLIMORFISMO se aplica.
            contas[2] = new ContaCorrente(generico);    //

            int i;

            for (i = 3; i < 10; i++) contas[i] = new ContaCorrente(generico); // <- Populando array automaticamente.

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

            int[] listadeInteiros = new int[] { 1, 2, 3, 4, 5, 6, 7 }; // Auto implementa uma array!!! Atalho C#
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Banco banco = new Banco();

            for (int i = 0; i < 10; i++)
            {
                banco.Adiciona(new ContaCorrente(new Cliente()));
                banco.Contas[i].Deposita((i + 1) * 1000);
            }

            foreach (Conta conta in banco.Contas) MessageBox.Show(conta.Saldo.ToString("n2"));
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AtualizaTexto();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.banco.Contas[comboContas.SelectedIndex].Transfere(Convert.ToDouble(textoValor.Text), this.banco.Contas[destinoDaTransferencia.SelectedIndex]);
            this.AtualizaTexto();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ContaPoupanca cp = new ContaPoupanca(new Cliente());
            cp.Deposita(100);
            ContaInvestimento ci = new ContaInvestimento(new Cliente());
            ci.Deposita(203);
            SeguroDeVida sv = new SeguroDeVida();

            GerenciadorDeImposto gerenciador = new GerenciadorDeImposto();
            gerenciador.Adiciona(cp);
            gerenciador.Adiciona(ci);
            gerenciador.Adiciona(sv);

            //gerenciador.Adiciona(new ContaCorrente(new Cliente())); 
            //^ Não compila, pois ContaCorrente não é ITributavel!

            MessageBox.Show("Total de impostos: R$" + gerenciador.Total.ToString("n2") + ".");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ContaCorrente cc = new ContaCorrente(new Cliente());
            MessageBox.Show(ContaCorrente.TotalDeContas + "ª conta corrente criada com sucesso.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ContaCorrente.TotalDeContas + " contas criadas. \nPróxima conta: " + ContaCorrente.ProximaConta() + ".");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (Conta conta in banco.Contas)
            {
                MessageBox.Show(conta.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cliente cliente1 = new Cliente("João");
            cliente1.Rg = "1.234.568";
            Cliente cliente2 = new Cliente("Maria");
            cliente2.Rg = "1.234.567";
            MessageBox.Show( cliente1.Equals(cliente2) ? "Clientes iguais!" : "Clientes diferentes.");
        }

        public void AdicionaConta(Conta conta)
        {
            this.banco.Contas[ContaCorrente.ProximaConta()] = conta;
            this.comboContas.Items.Add(new ContaComNome(conta));
            this.comboContas.SelectedIndex = this.comboContas.SelectedIndex = this.comboContas.Items.Count - 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CadastroDeContas cadastro = new CadastroDeContas(this);
            cadastro.ShowDialog();
        }
    }
}
