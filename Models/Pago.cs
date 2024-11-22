namespace SportField.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; } // FK
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MétodoPago { get; set; } = "Tarjeta"; // Tarjeta, Efectivo
    }
}
