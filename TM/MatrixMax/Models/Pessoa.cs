using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Telefone { get; set; }

        public char TipoPessoa { get; set; }
        [MaxLength(50)]
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        public Endereco Endereco { get; set; }

        public bool Valida()
        {
            if (TipoPessoa == 'F')
            {
                return true;
            }
            else if (TipoPessoa == 'J')
            {
                return true;
            }
            else return false;
        }

        public override bool Equals(object obj)
        {
            var outraPessoa = (Pessoa)obj;
            return Id == outraPessoa.Id &&
                Email == outraPessoa.Email &&
                Telefone == outraPessoa.Telefone &&
                TipoPessoa == outraPessoa.TipoPessoa &&
                NomeRazaoSocial == outraPessoa.NomeRazaoSocial &&
                CpfCnpj == outraPessoa.CpfCnpj &&
                InscricaoEstadual == outraPessoa.InscricaoEstadual &&
                NomeFantasia == outraPessoa.NomeFantasia;
        }

        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf == null || string.IsNullOrEmpty(cpf))
            {
                return false;
            }
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public bool ValidaCnpj(string cnpj)
        {
            if (cnpj == null || string.IsNullOrEmpty(cnpj))
            {
                return false;
            }
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}