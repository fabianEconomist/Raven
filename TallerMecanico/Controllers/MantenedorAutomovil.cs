using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using TallerMecanico.Datos;
using TallerMecanico.Models;


namespace TallerMecanico.Controllers
{
    public class MantenedorAutomovil : Controller
    {
        AutomovilDatos _AutomovilDatos = new AutomovilDatos();

        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _AutomovilDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AutomovilModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _AutomovilDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdAutomovil)
        {
            //devuelve la vista
            var oPersona = _AutomovilDatos.Obtener(IdAutomovil);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(AutomovilModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _AutomovilDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdAutomovil)
        {

            var oPersona = _AutomovilDatos.Obtener(IdAutomovil);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(AutomovilModelo oPersona)
        {
            var respuesta = _AutomovilDatos.Eliminar(oPersona.IdAutomovil);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        
    }
}
