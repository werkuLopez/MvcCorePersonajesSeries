using Microsoft.AspNetCore.Mvc;
using MvcCorePersonajesSeries.Models;
using MvcCorePersonajesSeries.Services;

namespace MvcCorePersonajesSeries.Controllers
{
    public class SeriesController : Controller
    {
        private ServicePersonajesSeries service;

        public SeriesController(ServicePersonajesSeries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes =
                await this.service.GetAllPersonajes();

            return View(personajes);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            Personaje personaje =
                await this.service.GetPersonajeByIdAsync(id);

            return View(personaje);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personaje personaje)
        {
            Personaje pers = await this.service.CreatePersonaje(personaje);
            return RedirectToAction("Detalles", new { id = pers.IdPersonaje });
        }
    }
}
