namespace SportField.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Teléfono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
