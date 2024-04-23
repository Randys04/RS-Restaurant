using Newtonsoft.Json;
using RestaurantProject.Models;
using System.Text;

namespace RestaurantProject.Servicios
{
    public class ServicioReservas : IServicioReservas
    {
        private string _baseurl; 

        public ServicioReservas()
        {
            _baseurl = "http://localhost:5193";
        }


        public async Task<bool> Editar(Reservas reserva)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(reserva), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"GestionRestaurante/Reservas/{reserva.id}", contenido);

            if (response.IsSuccessStatusCode) 
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> Eliminar(Reservas reserva)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(reserva), Encoding.UTF8, "application/json");

            var response = await cliente.DeleteAsync($"GestionRestaurante/Reservas/{reserva.id}");

            if (response.IsSuccessStatusCode) 
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Reservas>> getLista()
        {
            List<Reservas> lista = new List<Reservas>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("GestionRestaurante/Reservas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Reservas>>(json_respuesta);
                lista = resultado;
            }
            else
            {
                return null;
            }
            return lista;
        }

        public async Task<Reservas> getReserva(int id)
        {
            Reservas reserva = new Reservas(); 

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Reservas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<Reservas>(json_respuesta);
                reserva = resultado;
            }
            else
            {
                return null;
            }
            return reserva;
        }

        public async Task<bool> Guardar(Reservas reserva)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(reserva), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"GestionRestaurante/Reservas", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}

