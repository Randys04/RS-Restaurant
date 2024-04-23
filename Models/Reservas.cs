namespace RestaurantProject.Models
{
    public class Reservas
    {
        public int id { get; set; } 
        public String nombreCliente { get; set; }
        public DateTime fechaYhora { get; set; }
        public int numPersonas { get; set; }

    }
}
