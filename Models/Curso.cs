namespace Trabalho.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }

        public int DepartamentoId { get; set; }

        public virtual Departamento? Departamento { get; set; }

        public virtual ICollection<CursoDisciplina>? CursoDisciplinas { get; set; }
    }
}
