namespace Atividade2.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }
        public string? NomeExer { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Treino>? Treinos { get; set; }

    }
}
