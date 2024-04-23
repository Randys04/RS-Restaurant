using RestaurantProject.Models;

namespace RestaurantProject.Servicios
{
    public interface IServicioReservas
    {
        public Task<List<Reservas>> getLista();
        public Task<Reservas> getReserva(int id);
        public Task<bool> Guardar(Reservas reserva);
        public Task<bool> Eliminar(Reservas reserva);
        public Task<bool> Editar(Reservas reserva);
    }
}
