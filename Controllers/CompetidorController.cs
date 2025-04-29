using Microsoft.AspNetCore.Mvc;
using Rodriguez_Franco.Datos;
using Rodriguez_Franco.Models;

namespace Rodriguez_Franco.Controllers
{
    public class CompetidorController : Controller
    {
        public TorneoDatos _BD = new TorneoDatos();
        public IActionResult Index()
        {
            return View(_BD.ListarCompetidor());
        }
        public IActionResult Create()
        {
            ViewBag.Disciplina = _BD.ListarDisciplina();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Competidor competidor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _BD.Crear(competidor);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
