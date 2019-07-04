using Julio3.dal;
using Julio3.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Julio3.Controllers
{
    public class CategoriaController : Controller
    {
       

        public ActionResult Listar()
        {
            ViewBag.categorias=CategoriaDal.Listar();
            return View();
        }
        [HttpGet]
        public ActionResult Insertar()
        {
            //  formulario por defecto
            var modelo=new Categoria();
            return View(modelo);
        }
        [HttpPost] // alt+shift+f10
        public ActionResult Insertar(Categoria modelo)
        {
            // insertar el valor en la base de datos
            ViewBag.id= CategoriaDal.Insertar(modelo);
            // redireccionar a la pagina de listado
            Response.Redirect("/Categoria/Listar");

            return View(modelo);
        }
    }
}