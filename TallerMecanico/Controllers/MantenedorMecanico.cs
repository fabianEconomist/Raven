using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Datos;
using TallerMecanico.Models;

namespace TallerMecanico.Controllers
{
    public class MantenedorMecanico : Controller
    {
        MecanicoDatos _MecanicoDatos = new MecanicoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _MecanicoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(MecanicoModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _MecanicoDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int Idpersona)
        {
            //devuelve la vista
            var oPersona = _MecanicoDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(MecanicoModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _MecanicoDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idpersona)
        {

            var oPersona = _MecanicoDatos.Obtener(Idpersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(MecanicoModelo oPersona)
        {
            var respuesta = _MecanicoDatos.Eliminar(oPersona.Idpersona);

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
