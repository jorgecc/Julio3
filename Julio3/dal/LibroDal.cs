using Julio3.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Julio3.dal
{
    public class LibroDal
    {
        public static List<Libro> Listar()
        {
            var lista=new List<Libro>();
            using(var db=new Model1())
            {
                lista=db.Libro.Include("Categoria").ToList();
            }
            return lista;
        }
        public static int Insertar(Libro nueva)
        {
            int LibroId=0;
            using (var db = new Model1())
            {
                db.Libro.Add(nueva);
                db.SaveChanges();
                LibroId=nueva.LibroId;
            }
            return LibroId; // devuelve la identidad
        }
        public static void Modificar(Libro libro)
        {
            using (var db = new Model1())
            {
                // leemos la Libro desde la base de datos
                var libroAntigua=db.Libro
                    .FirstOrDefault(c => c.LibroId==libro.LibroId);
                // modificamos la Libro leida usando el argumento (libro)
                libroAntigua.Nombre=libro.Nombre;
                libroAntigua.CategoriaId=libro.CategoriaId;
                libroAntigua.Precio=libro.Precio;              
                //libroAntigua.LibroId=libro.LibroId; // redundante
                db.SaveChanges(); // guarfamos los cambios.
            }
        } // fin modificar
        public static Libro Leer(int LibroId)
        {
            var libro=new Libro();
            using (var db = new Model1())
            {
                libro=db.Libro.FirstOrDefault(c =>c.LibroId==LibroId);
            }
            return libro;
        } // fin leer
        public static void Borrar(int LibroId)
        {
            using (var db = new Model1())
            {
                var libro = db.Libro
                    .FirstOrDefault(c => c.LibroId == LibroId);
                //db.Database.SqlQuery("delete from Libro where libroegoryid=?"
                //    ,LibroId)
                db.Libro.Remove(libro);
                db.SaveChanges();
            }
        }

    }
}