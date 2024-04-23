using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Servicios;

namespace RestaurantProject.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IServicioVentas _iservicioVentas;
        private readonly IServicioPlatos _iservicioPlatos;
        public ReportesController(IServicioVentas iservicioVentas, IServicioPlatos iservicioPlatos)
        {
            _iservicioVentas = iservicioVentas; 
            _iservicioPlatos = iservicioPlatos; 
        }

        // GET: ReportesController
        public async Task<ActionResult> Index()
        {
            try
            {
                DateTime Inicio = new DateTime(2023, 7, 7);
                DateTime Fin = new DateTime(2023, 7, 31);
                List<Models.Ventas> laListaDeVentas;
                laListaDeVentas = await _iservicioVentas.getListaRangoFechas(Inicio, Fin);
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

        public ActionResult SeleccionarFiltros() 
        {
            return View(); 
        }

        public async Task<ActionResult> ListaRangoFechas(DateTime inicio, DateTime fin)
        {
            try
            {
                List<Models.Ventas> laListaDeVentas;
                laListaDeVentas = await _iservicioVentas.getListaRangoFechas(inicio, fin);
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

        public async Task<ActionResult> ListaMes(DateTime mes)
        {
            try
            {
                List<Models.Ventas> laListaDeVentas;
                laListaDeVentas = await _iservicioVentas.getListaRangoMes(mes);
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

        public async Task<ActionResult> ListaDia(DateTime dia)
        {
            try
            {
                List<Models.Ventas> laListaDeVentas;
                laListaDeVentas = await _iservicioVentas.getListaRangoDia(dia);
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

        public IActionResult RedirectToListView1(DateTime fechaInicio, DateTime fechaFin, string btnAction)
        {
            try
            {
                return RedirectToAction("ListaRangoFechas", "Reportes", new { inicio = fechaInicio, fin = fechaFin });
            }
            catch (Exception)
            {
                return View("Error", "Ha ocurrido un error a la hora de obtener la información de las ventas");
            }
            
        }

        public IActionResult RedirectToListView2(DateTime fechaMes, string btnAction)
        {
            return RedirectToAction("ListaMes", "Reportes", new { mes = fechaMes });
        }

        public IActionResult RedirectToListView3(DateTime fechaDia, string btnAction)
        {
            return RedirectToAction("ListaDia", "Reportes", new { dia = fechaDia });
        }
    }
}
