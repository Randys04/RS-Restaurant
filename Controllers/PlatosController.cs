using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantProject.Servicios;
using System.Collections.Generic;

namespace RestaurantProject.Controllers
{
    public class PlatosController : Controller
    {
        private readonly IServicioPlatos _iservicioPlatos;
        public PlatosController(IServicioPlatos iservicioPlatos)
        {
            _iservicioPlatos = iservicioPlatos;
        }


        // GET: PlatosController
        public async Task<ActionResult> Index() 
        {
            try
            {
                List<Models.Platos> laListaDePLatos;
                laListaDePLatos = await _iservicioPlatos.getLista();
                if (laListaDePLatos == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información de los platos");
                }
                return View(laListaDePLatos);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de los platos");
            }
        }

        // GET: PlatosController/Details/5
        public async Task<ActionResult> Details(int id) 
        {
            try
            {
                Models.Platos elPlato;
                elPlato = await _iservicioPlatos.getPlato(id);
                if (elPlato == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información del plato");
                }
                return View(elPlato);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información del plato");

            }

        }

        // GET: PlatosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Platos plato) 
        {
            try
            {
                bool estado = await _iservicioPlatos.Guardar(plato);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de crear el plato");
            }
            catch(Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de crear el plato");
            }
        }

        // GET: PlatosController/Edit/5
        public async Task<ActionResult> Edit(int id) 
        {
            try
            {
                Models.Platos elPlato;
                elPlato = await _iservicioPlatos.getPlato(id);
                if (elPlato == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la información del plato");
                }
                return View(elPlato);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información del plato");
            }
        }

        // POST: PlatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Platos plato) 
        {
            try
            {
                bool estado = await _iservicioPlatos.Editar(plato);
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de editar el plato");
            }
            catch(Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de editar el plato");
            }
        }

        // GET: PlatosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Models.Platos elPlato;
                elPlato = await _iservicioPlatos.getPlato(id);
                if (elPlato == null)
                {
                    return View("Error", "Ha ocurrido un error a la hora de obtener la informacion del el plato");
                }
                return View(elPlato);
            }
            catch (Exception ex)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la informacion del el plato");
            }  
        }

        // POST: PlatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Models.Platos plato)
        {
            try
            {
                bool estado = await _iservicioPlatos.Eliminar(plato); 
                if (estado)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error", "Ha ocurrido un error a la hora de eliminar el plato");   
            }
            catch
            {
                return View("Error", "Ha ocurrido un error a la hora de eliminar el plato");

            }
        }
    }
}

