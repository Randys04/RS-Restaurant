using Newtonsoft.Json;
using RestaurantProject.Models;
using System.Text;

namespace RestaurantProject.Servicios
{
    //esta clase implementa la interfaz IServicioVentas
    public class ServicioVentas : IServicioVentas
    {
        private string _baseurl; // URL base 
        public ServicioVentas()
        {
            _baseurl = "http://localhost:5193"; 
        }

        public async Task<bool> Editar(Ventas venta)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");

            
            var response = await cliente.PutAsync($"GestionRestaurante/Ventas/{venta.id}", contenido);

            if (response.IsSuccessStatusCode) 
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> Eliminar(Ventas venta)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");

            var response = await cliente.DeleteAsync($"GestionRestaurante/Ventas/{venta.id}");

            if (response.IsSuccessStatusCode) 
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Ventas>> getLista()
        {
            List<Ventas> lista = new List<Ventas>(); 

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("GestionRestaurante/Ventas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Ventas>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<List<Ventas>> getListaRangoFechas(DateTime inicio, DateTime fin)
        {
            List<Ventas> lista = new List<Ventas>();

            var cliente = new HttpClient();
            
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Ventas/Rangofechas?inicio={inicio.ToString("yyyy-MM-ddT00:00:00.000Z")}&fin={fin.ToString("yyyy-MM-ddT23:59:59.999Z")}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Ventas>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<List<Ventas>> getListaRangoMes(DateTime mes)
        {
            List<Ventas> lista = new List<Ventas>(); 

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Ventas/RangoMes?mes={mes.ToString("yyyy-MM-01T00:00:00.000Z")}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Ventas>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<List<Ventas>> getListaRangoDia(DateTime dia)
        {
            List<Ventas> lista = new List<Ventas>(); 

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Ventas/RangoDia?dia={dia.ToString("yyyy-MM-ddT00:00:00.000Z")}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Ventas>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<List<Platos>> getListaPLatos()
        {
            List<Platos> lista = new List<Platos>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("GestionRestaurante/Platos");

            if (response.IsSuccessStatusCode) 
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Platos>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<Ventas> getVenta(int id)
        {
            Ventas venta = new Ventas(); 

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Ventas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<Ventas>(json_respuesta);
                venta = resultado;
            }
            else
            {
                return null;
            }
            return venta;
        }

        public async Task<bool> Guardar(Ventas venta)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"GestionRestaurante/Ventas", contenido);

            if (response.IsSuccessStatusCode)
            {
                
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}
