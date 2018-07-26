using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelagemInicial
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        

        public string Senha { get; set; }


        public string ImagemPerfil { get; set; }


        public string Nome { get; set; }


        public string Cpf { get; set; }

    }
}