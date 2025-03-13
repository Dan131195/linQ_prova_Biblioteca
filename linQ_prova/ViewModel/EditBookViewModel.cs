namespace linQ_prova.ViewModel
{
    public class EditBookViewModel
    {
        public required Guid Id { get; set; }
        public required string Titolo { get; set; }
        public required string Autore { get; set; }
        public required string Genere { get; set; }
        public bool? Disponibilita { get; set; }
        public string? ImmagineCopertina { get; set; }
    }
}
