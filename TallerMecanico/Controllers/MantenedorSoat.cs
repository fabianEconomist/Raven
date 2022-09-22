using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Datos;
using TallerMecanico.Models;

namespace TallerMecanico.Controllers
{
    public class MantenedorSoat : Controller
    {
        SoatDatos _SoatDatos = new SoatDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _SoatDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(SoatModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _SoatDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdSoat)
        {
            //devuelve la vista
            var oPersona = _SoatDatos.Obtener(IdSoat);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(SoatModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _SoatDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdSoat)
        {

            var oPersona = _SoatDatos.Obtener(IdSoat);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(SoatModelo oPersona)
        {
            var respuesta = _SoatDatos.Eliminar(oPersona.IdSoat);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
