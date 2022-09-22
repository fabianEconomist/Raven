using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.Datos;
using TallerMecanico.Models;

namespace TallerMecanico.Controllers
{
    public class MantenedorController : Controller
    {
        PersonaDatos _PersonaDatos = new PersonaDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _PersonaDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PersonaModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _PersonaDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int Idpersona)
        {
            //devuelve la vista
            var oPersona = _PersonaDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(PersonaModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _PersonaDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idpersona)
        {

            var oPersona = _PersonaDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(PersonaModelo oPersona)
        {
            var respuesta = _PersonaDatos.Eliminar(oPersona.Idpersona);

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