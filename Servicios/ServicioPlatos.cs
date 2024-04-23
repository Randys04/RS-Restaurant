using RestaurantProject.Models;
using Newtonsoft.Json;
using System.Text;

namespace RestaurantProject.Servicios
{
    public class ServicioPlatos : IServicioPlatos
    {
        private string _baseurl;
        public ServicioPlatos()
        {
            _baseurl = "http://localhost:5193"; 
        }


        public async Task<bool> Editar(Platos plato)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(plato), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"GestionRestaurante/Platos/{plato.id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> Eliminar(Platos plato)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(plato), Encoding.UTF8, "application/json");

            var response = await cliente.DeleteAsync($"GestionRestaurante/Platos/{plato.id}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }

            return Respuesta;
        }

        public async Task<List<Platos>> getLista()
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

        public async Task<Platos> getPlato(int id)
        {
            Platos plato = new Platos();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync($"GestionRestaurante/Platos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<Platos>(json_respuesta);
                plato = resultado;
            }
            else
            {
                return null;
            }
            return plato;
        }

        public async Task<bool> Guardar(Platos plato)
        {
            bool Respuesta = false;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(plato), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"GestionRestaurante/Platos", contenido);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }
    }
}

