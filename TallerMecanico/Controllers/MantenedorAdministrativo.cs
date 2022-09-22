using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Datos;
using TallerMecanico.Models;

namespace TallerMecanico.Controllers
{
    public class MantenedorAdministrativo : Controller
    {
        AdministrativoDatos _AdministrativoDatos = new AdministrativoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _AdministrativoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AdministrativoModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _AdministrativoDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int Idpersona)
        {
            //devuelve la vista
            var oPersona = _AdministrativoDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(AdministrativoModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _AdministrativoDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idpersona)
        {

            var oPersona = _AdministrativoDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(AdministrativoModelo oPersona)
        {
            var respuesta = _AdministrativoDatos.Eliminar(oPersona.Idpersona);

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
