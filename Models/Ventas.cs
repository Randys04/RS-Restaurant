namespace RestaurantProject.Models
{
    public class Ventas
    {
        public int id { get; set; } 
        public DateTime fechaYhora { get; set; }
        public String platos { get; set; }
        public int  cantidad { get; set; }
        public List<Platos> listPlatos { get; set; }
    }
}
