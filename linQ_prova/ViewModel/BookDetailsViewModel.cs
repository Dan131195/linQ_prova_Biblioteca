using System.ComponentModel.DataAnnotations;

namespace linQ_prova.ViewModel
{
    public class BookDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string? Titolo { get; set; }
        public string? Autore { get; set; }
        public string? Genere { get; set; }
        public bool? Disponibilita { get; set; }
        public string? ImmagineCopertina { get; set; }
    }
}
