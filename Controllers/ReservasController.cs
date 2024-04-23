using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantProject.Servicios;

namespace RestaurantProject.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IServicioReservas _iservicioReservas;
        public ReservasController(IServicioReservas iservicioReservas)
        {
            _iservicioReservas = iservicioReservas;
        }


        // GET: ReservasController
        public async Task<ActionResult> Index() 
        {
            try 
            {
                List<Models.Reservas> laListaDeReservas;
                laListaDeReservas = await _iservicioReservas.getLista();
                if (laListaDeReservas == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de las reservas");
                }
                return View(laListaDeReservas);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de las reservas");
            }     
        }

        // GET: ReservasController/Details/5
        public async Task<ActionResult> Details(int id) 
        {
            try 
            {
                Models.Reservas laReserva;
                laReserva = await _iservicioReservas.getReserva(id);
                if (laReserva == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
                }
                return View(laReserva);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
            }
             
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Reservas reserva) 
        {
            try
            {
                bool estado = await _iservicioReservas.Guardar(reserva);
                if (estado) 
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de guardar la reserva");
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de guardar la reserva");
            }
        }

        // GET: ReservasController/Edit/5
        public async Task<ActionResult> Edit(int id) 
        {
            try
            {
                Models.Reservas laReserva;
                laReserva = await _iservicioReservas.getReserva(id);
                if (laReserva == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
                }
                return View(laReserva);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
            }
            
        }

        // POST: ReservasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Reservas reserva) 
        {
            try
            {
                bool estado = await _iservicioReservas.Editar(reserva);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de editar la reserva");
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de editar la reserva");
            }
        }

        // GET: ReservasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Models.Reservas laReserva;
                laReserva = await _iservicioReservas.getReserva(id);
                if (laReserva == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
                }
                return View(laReserva);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la reserva");
            }
            
        }

        // POST: ReservasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Reservas reserva)
        {
            try
            {
                bool estado = await _iservicioReservas.Eliminar(reserva);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de guardar la reserva");
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de eliminar la reserva");
            }
        }
    }
}

