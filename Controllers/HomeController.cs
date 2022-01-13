using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly IConfiguration configuration;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, 
            IRepositorioProyectos repositorioProyectos,
            ServicioUnico servicioUnico,
            ServicioTransitorio servicioTransitorio,
            ServicioDelimitado servicioDelimitado,
            IConfiguration configuration,
            IServicioEmail servicioEmail
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado = servicioDelimitado;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            //var persona = new Persona()
            //{
            //    Nombre = "Jorge",
            //    Edad = 38
            //};
            //ViewBag.Edad = "38";
            //return View( persona);

            //var apellido = configuration.GetValue<string>("Apellido");
            //_logger.LogCritical("Éste es un mensaje de Critical" + apellido);
            //_logger.LogError("Éste es un mensaje de Error");
            //_logger.LogWarning("Éste es un mensaje de Warning");

            //_logger.LogInformation("Éste es un mensaje de información");
            //_logger.LogDebug("Éste es un mensaje de debug");
            //_logger.LogTrace("Éste es un mensaje de trace");

            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var guidViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid

            };
            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
                EjemploGUID_1 = guidViewModel
            };
            return View(modelo);
        }

        

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(Contacto contacto)
        {
            await servicioEmail.Enviar(contacto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}