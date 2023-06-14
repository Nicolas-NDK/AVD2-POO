namespace Trabalho.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<CursoDisciplina>? CursoDisciplinas { get; set; }
    }
}
