namespace Atividade2.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public Aluno? Alunos { get; set; }
        public ICollection<Exercicio>? Exercicios { get; set; }
    }
}
