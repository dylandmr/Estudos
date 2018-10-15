using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCurso
{
    class Programa
    {
        static void Testar()
        {
            Aluno aluno = new Aluno();
            aluno.Adicionar(new Curso("JavaScript Básico"));
            aluno.Adicionar(new Curso("C# Intermediário"));
            aluno.Adicionar(new Curso("Java Avançado"));
        }

        static void Main(string[] args)
        {
            Testar();
        }
    }

    class Aluno
    {
        private readonly List<Curso> cursos;
        internal IReadOnlyCollection<Curso> Cursos {
            get => new ReadOnlyCollection<Curso>(cursos); }

        public Aluno()
        {
            cursos = new List<Curso>();
        }

        public void Adicionar(Curso curso)
        {
            cursos.Add(curso);
        }

        public void Remover(Curso curso)
        {
            cursos.Remove(curso);
        }
    }

    class Curso
    {
        readonly string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public Curso(string nome)
        {
            this.nome = nome;
        }
    }
}
