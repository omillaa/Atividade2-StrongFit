namespace Atividade2.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string? Instagram { get; set; }
        public string? Telefone { get; set; }
        public int PersonalId { get; set; }
        public string? Observações { get; set; }
        public Personal Personal { get; set; }
        public ICollection<Treino>? Treinos { get; set; }
    }
}
