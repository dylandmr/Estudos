using System;

namespace refatoracao
{
    class Program
    {
        private int redimensionado;
        private string plataforma;
        private string browser;

        static void Main(string[] args)
        {
        }

        void GerarListagem()
        {
            var plataformaMac = plataforma.ToUpper().IndexOf("MAC") > -1;
            var navegadorChrome = browser.ToUpper().IndexOf("Chrome") > -1;
            var foiRedimensionado = redimensionado > 0;
            if (plataformaMac 
                && navegadorChrome 
                && foiInicializado() 
                && foiRedimensionado)
            {
                // faça alguma coisa
            }
        }

        class CalculadoraDePrecos
        {
            decimal GetDescontoFinal(decimal descontoInicial
            , int quantidade
            , int clienteHaQuantosAnos)
            {
                var resultado = descontoInicial;
                if (resultado > 50M)
                {
                    resultado = 50M;
                }
                if (quantidade > 100)
                {
                    resultado += 15M;
                }
                if (clienteHaQuantosAnos > 4)
                {
                    resultado += 10M;
                }
                return resultado;
            }
        }

        private bool foiInicializado()
        {
            throw new NotImplementedException();
        }

        class Produto
        {
            private readonly string descricao;
            private bool promocional;
            private readonly decimal precoBase;
            private readonly decimal acrescimo;
            private readonly decimal desconto;

            public string Descricao { get => descricao; }
            public bool Promocional { get => promocional; }
            public decimal PrecoBase { get => precoBase; }
            public decimal Acrescimo { get => acrescimo; }
            public decimal Desconto { get => desconto; }

            public Produto(string descricao, decimal precoBase, decimal acrescimo, decimal desconto)
            {
                this.descricao = descricao;
                this.precoBase = precoBase;
                this.acrescimo = acrescimo;
                this.desconto = desconto;

                var preco = Preco(precoBase, acrescimo, desconto);

                Console.WriteLine($"ANTES: O preço é {preco}");
            }

            decimal Preco(decimal precoBase, decimal acrescimo, decimal desconto)
            {
                return new GeradoraDePrecos(this, precoBase, acrescimo, desconto).Calcula();
            }

            public void HabilitarPromocao()
            {
                if (desconto == 0)
                {
                    this.promocional = true;
                }
                else
                {
                    throw new Exception("Produto com desconto não pode ser transformado em produto promocional!");
                }
            }
        }

        class GeradoraDePrecos
        {
            private readonly Produto produto;
            private decimal precoBase;
            private decimal acrescimo;
            private decimal desconto;

            public GeradoraDePrecos(Produto produto, decimal precoBase, decimal acrescimo, decimal desconto)
            {
                this.produto = produto;
                this.precoBase = precoBase;
                this.acrescimo = acrescimo;
                this.desconto = desconto;
            }

            public decimal Calcula()
            {
                var resultado = precoBase;

                if (produto.Promocional && desconto > 0)
                {
                    throw new Exception("Produto já é promocional e não pode ter desconto!");
                }

                if (desconto > 20)
                {
                    desconto = 20;
                }

                if (acrescimo > 15)
                {
                    acrescimo = 15;
                }

                return precoBase + precoBase * (acrescimo - desconto);
            }
        }
    }

    class ContaCorrente
    {
        public decimal GetTaxaChequeEspecial()
        {
            return tipo.GetTaxaChequeEspecial(this);
        }

        public ContaCorrente(TipoConta type)
        {
            this.tipo = type;
        }

        private readonly TipoConta tipo;
        public TipoConta Tipo { get { return tipo; } }

        private int diasEmDescoberto;
        public int DiasEmDescoberto
        {
            get { return diasEmDescoberto; }
        }
    }

    class TipoConta
    {
        public bool EhPremium { get; set; }

        public decimal GetTaxaChequeEspecial(ContaCorrente conta)
        {
            if (EhPremium)
            {
                var result = 10.0M;
                if (conta.DiasEmDescoberto > 7)
                {
                    result += (conta.DiasEmDescoberto - 7) * 0.01M;
                }
                return result;
            }

            return conta.DiasEmDescoberto * 1.75M;
        }
    }
}
