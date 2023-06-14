namespace Trabalho.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string? Nome { get; set; }
        public int InstituicaoId { get; set; }


        public virtual Instituicao? Instituicao { get; set; }
        public virtual ICollection<Curso>? Cursos { get; set; }
    }
}
