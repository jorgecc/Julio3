using Julio3.dal;
using Julio3.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Julio3.Controllers
{
    public class LibroController : Controller
    {
        public ActionResult Listar()
        {
            ViewBag.libros = LibroDal.Listar();
            return View();
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            //  formulario por defecto
            var modelo = new Libro();
            ViewBag.categorias=CategoriaDal.Listar();
            return View(modelo);
        }
        [HttpPost] // alt+shift+f10
        public ActionResult Insertar(Libro modelo)
        {
            // insertar el valor en la base de datos
            ViewBag.id = LibroDal.Insertar(modelo);
            ViewBag.categorias = CategoriaDal.Listar();
            // redireccionar a la pagina de listado
            Response.Redirect("/Libro/Listar");

            return View(modelo);
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            //  formulario por defecto
            var modelo = LibroDal.Leer(id);
            ViewBag.categorias = CategoriaDal.Listar();
            return View(modelo);
        }
        [HttpPost] // alt+shift+f10
        public ActionResult Modificar(Libro modelo)
        {
            // insertar el valor en la base de datos
            LibroDal.Modificar(modelo);
            ViewBag.categorias = CategoriaDal.Listar();
            // redireccionar a la pagina de listado
            Response.Redirect("/Libro/Listar");

            return View(modelo);
        }
    }

}