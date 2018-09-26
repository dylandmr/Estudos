using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public int? CategoriaId { get; set; }

        public virtual Categoria CategoriaDaSubcategoria { get; set; }

        public bool Ativo { get; set; }

        public override bool Equals(object obj)
        {
            var outraCategoria = (Categoria)obj;

            return Id == outraCategoria.Id &&
                Nome == outraCategoria.Nome &&
                CategoriaId == outraCategoria.CategoriaId;
        }
    }
}