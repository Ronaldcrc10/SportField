namespace SportField.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdCampo { get; set; } // FK
        public int IdCliente { get; set; } // FK
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; } = "Reservado"; // Reservado, Cancelado, Completado
    }
}
