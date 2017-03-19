using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
 public   class PermisosDetallesBLL
    {
        public static bool Guardar(Entidades.PermisosDetalles n)
        {
            bool retono = false;
            using (var db = new UserDb())
            {
                try
                {


                    db.PermisosDetallesDb.Add(n);
                    db.SaveChanges();
                    retono = true;

                }
                catch (Exception)
                {

                    throw;
                }
                return retono;
            }

        }

        public static Entidades.PermisosDetalles Buscar(int id)
        {

            Entidades.PermisosDetalles nuevo;
            using (var db = new UserDb())
            {
                try
                {
                    nuevo = db.PermisosDetallesDb.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static bool Eliminar(Entidades.PermisosDetalles id)
        {
            using (var db = new UserDb())
            {
                try
                {
                    db.Entry(id).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Entidades.PermisosDetalles> GetList()
        {
            List<Entidades.PermisosDetalles> lista = new List<Entidades.PermisosDetalles>();
            using (var db = new UserDb())
            {
                try
                {
                    lista = db.PermisosDetallesDb.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<Entidades.PermisosDetalles> GetList(Expression<Func<Entidades.PermisosDetalles, bool>> criterioBusqueda)
        {
            List<Entidades.PermisosDetalles> lista = new List<Entidades.PermisosDetalles>();
            using (var db = new UserDb())
            {
                try
                {
                    lista = db.PermisosDetallesDb.Where(criterioBusqueda).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }
    }
}
