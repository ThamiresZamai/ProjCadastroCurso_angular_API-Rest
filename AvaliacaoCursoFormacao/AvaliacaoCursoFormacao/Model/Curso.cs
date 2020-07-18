using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoCursoFormacao.Model
{
    public class Curso
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int qtdAluno { get; set; }
        public int categoriaid { get; set; }        
        public Categoria categoria { get; set; }

        public Curso() { }

        public Curso(int id, string descricao, DateTime dataIncio, DateTime dataFim, int qtdAluno, Categoria categoria)
        {
            this.id = id;
            this.descricao = descricao;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.qtdAluno = qtdAluno;
            this.categoria = categoria;
        }
    }
}
