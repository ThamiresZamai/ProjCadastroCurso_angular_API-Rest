using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoCursoFormacao.Model
{
    public class Categoria
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public ICollection<Curso> cursos { get; set; }

        public Categoria(string descricao) {
            
            this.descricao = descricao;
        }

        public Categoria()
        {
            this.cursos = new HashSet<Curso>();
        }
    }
}
