using System.ComponentModel.DataAnnotations;

namespace Rodriguez_Franco.Models
{
    public class Disciplina
    {
        [Key]
        public int IdDisciplina { get; set; }
        [Required]
        public string NombreDisciplina { get; set; }

    }
}
