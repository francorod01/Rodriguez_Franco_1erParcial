using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Franco.Models
{
    public class Competidor
    {
        [Key]
        public int IdCompetidor { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int IdDisciplina { get; set; }       
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero")]
        public int Edad {  get; set; }
        [Required]
        public string CiudadResidencia {  get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
