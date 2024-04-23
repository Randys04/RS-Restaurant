using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantProject.Models;
using RestaurantProject.Servicios;

namespace RestaurantProject.Controllers
{
    public class VentasController : Controller
    {
        private readonly IServicioVentas _iservicioVentas;
        private readonly IServicioPlatos _iservicioPlatos;
        public VentasController(IServicioVentas iservicioVentas, IServicioPlatos iservicioPlatos)
        {
            _iservicioVentas = iservicioVentas; 
            _iservicioPlatos = iservicioPlatos;         }

        public async Task<List<Platos>> obtenerListaDePlatos()
        {
            List<Models.Platos> laListaDePLatos;
            laListaDePLatos = await _iservicioPlatos.getLista();
            return laListaDePLatos;
        }

        // GET: VentasController
        public async Task<ActionResult> Index()
        {
            try
            {
                List<Models.Ventas> laListaDeVentas;
                laListaDeVentas = await _iservicioVentas.getLista();
                if (laListaDeVentas == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de las ventas");
                }
                return View(laListaDeVentas);
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de las ventas");
            }
        }

        // GET: VentasController/Details/5
        public async Task<ActionResult> Details(int id)  
        {
            try
            {
                Models.Ventas laVenta;
                laVenta = await _iservicioVentas.getVenta(id);
                if (laVenta == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
                }
                return View(laVenta);
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
            }
        }

        // GET: VentasController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                Models.Ventas laVenta = new Models.Ventas();
                laVenta.listPlatos = await _iservicioVentas.getListaPLatos();
                if (laVenta.listPlatos == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener información");
                }

                if (laVenta.listPlatos.Count > 0)
                {
                    return View(laVenta);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener información");
            }
        }

        // POST: VentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Ventas venta)
        {
            try
            {
                bool estado = await _iservicioVentas.Guardar(venta);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de guardar la venta");
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de guardar la venta");
            }
        }

        // GET: VentasController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                Models.Ventas laVenta;
                laVenta = await _iservicioVentas.getVenta(id);
                if (laVenta == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
                }
                laVenta.listPlatos = await _iservicioVentas.getListaPLatos();
                if (laVenta.listPlatos == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la lista de platos");
                }
                return View(laVenta);
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
            }
        }

        // POST: VentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Ventas venta) 
        {
            try
            {
                bool estado = await _iservicioVentas.Editar(venta);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de editar la venta");
            } 
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de editar la venta");
            }
        }

        // GET: VentasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Models.Ventas laVenta;
                laVenta = await _iservicioVentas.getVenta(id);
                if (laVenta == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
                }
                return View(laVenta);
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de la venta");
            } 
        }

        // POST: VentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Ventas venta)
        {
            try
            {
                bool estado = await _iservicioVentas.Eliminar(venta);
                if (estado) 
                {
                    return RedirectToAction(nameof(Index)); 
                }
                return View("Error", "Ha ocurrido un error a la hora de eliminar la venta");
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de eliminar la venta");
            }
        }
    }
}

