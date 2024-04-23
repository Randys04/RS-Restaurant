using RestaurantProject.Models;

namespace RestaurantProject.Servicios
{
    public interface IServicioVentas
    {
        public Task<List<Ventas>> getLista();
        public Task<List<Platos>> getListaPLatos();
        public Task<List<Ventas>> getListaRangoFechas(DateTime inicio, DateTime fin);
        public Task<List<Ventas>> getListaRangoMes(DateTime mes);
        public Task<List<Ventas>> getListaRangoDia(DateTime dia);
        public Task<Ventas> getVenta(int id);
        public Task<bool> Guardar(Ventas venta);
        public Task<bool> Eliminar(Ventas venta);
        public Task<bool> Editar(Ventas venta);
    }
}
