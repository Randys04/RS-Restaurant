using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.Drawing;

namespace RestaurantProject.Models
{
    public class Platos
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public double precio { get; set; }
        public String categoria { get; set; }
        public String imagen { get; set; }
    }
}
