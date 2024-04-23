using RestaurantProject.Models;

namespace RestaurantProject.Servicios
{
    public interface IServicioPlatos
    {
        public Task<List<Platos>> getLista();
        public Task<Platos> getPlato(int id);
        public Task<bool> Guardar(Platos plato);
        public Task<bool> Eliminar(Platos plato);
        public Task<bool> Editar(Platos plato);
    }
}
