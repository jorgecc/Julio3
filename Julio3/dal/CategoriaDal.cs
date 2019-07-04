using Julio3.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julio3.dal
{
    public class CategoriaDal
    {
        public static List<Categoria> Listar()
        {
            var lista=new List<Categoria>();
            using(var db=new Model1())
            {
                lista=db.Categoria.ToList();
            }
            return lista;
        }
        public static int Insertar(Categoria nueva)
        {
            int categoriaId=0;
            using (var db = new Model1())
            {
                db.Categoria.Add(nueva);
                db.SaveChanges();
                categoriaId=nueva.CategoriaId;
            }
            return categoriaId; // devuelve la identidad
        }
        public static void Modificar(Categoria cat)
        {
            using (var db = new Model1())
            {
                // leemos la categoria desde la base de datos
                var catAntigua=db.Categoria
                    .FirstOrDefault(c => c.CategoriaId==cat.CategoriaId);
                // modificamos la categoria leida usando el argumento (cat)
                catAntigua.Nombre=cat.Nombre;
                catAntigua.CategoriaId=cat.CategoriaId; // redundante
                db.SaveChanges(); // guarfamos los cambios.
            }
        } // fin modificar
        public static Categoria Leer(int CategoriaId)
        {
            var cat=new Categoria();
            using (var db = new Model1())
            {
                cat=db.Categoria.FirstOrDefault(c =>c.CategoriaId==CategoriaId);
            }
            return cat;
        } // fin leer

    }
}