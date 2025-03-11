using System.ComponentModel.DataAnnotations;

namespace linQ_prova.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public required string Autore { get; set; }
        [Required]
        [StringLength(50)]
        public required string Genere { get; set; }

        public string? Disponibilità { get; set; }
        public string? ImmagineCopertina { get; set; }

    }
}
