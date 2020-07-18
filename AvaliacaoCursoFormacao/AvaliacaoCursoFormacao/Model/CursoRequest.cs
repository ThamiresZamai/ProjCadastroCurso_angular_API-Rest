namespace AvaliacaoCursoFormacao.Model
{
    public class CursoRequest
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public int qtdAluno { get; set; }
        public int categoriaid { get; set; }
        public Categoria categoria { get; set; }
    }
}
