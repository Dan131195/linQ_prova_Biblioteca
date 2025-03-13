using System.ComponentModel.DataAnnotations;

namespace linQ_prova.ViewModel
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(50)]
        public required string Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public required string Autore { get; set; }
        [Required]
        [StringLength(50)]
        public required string Genere { get; set; }

        public bool? Disponibilita { get; set; }
        public string? ImmagineCopertina { get; set; }
    }
}
