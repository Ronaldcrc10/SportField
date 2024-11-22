namespace SportField.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public int IdCampo { get; set; } // FK
        public string NombreEvento { get; set; } = string.Empty;
        public DateTime FechaEvento { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Descripción { get; set; } = string.Empty;
    }
}
