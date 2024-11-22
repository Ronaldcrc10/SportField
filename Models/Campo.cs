namespace SportField.Models
{
    public class Campo
    {
        public int IdCampo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // Fútbol, Básquetbol, etc.
        public string Ubicación { get; set; } = string.Empty;
        public decimal TarifaHora { get; set; }

      
    }
}
