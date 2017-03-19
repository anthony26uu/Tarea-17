using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
 public   class PermisosBLL
    {
        public static bool Guardar(Permisos nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Permisos>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }


        public static bool Eliminar(Permisos IdUser)
        {
            bool resultado = false;
            using (var db = new Repositorio<Permisos>())
            {
                resultado = db.Eliminar(IdUser);

            }
            return resultado;
        }

        public static bool Mofidicar(Permisos existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Permisos>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }
        public static List<Entidades.Permisos> GetListodo()
        {
            List<Entidades.Permisos> lista = new List<Entidades.Permisos>();
            using (var db = new UserDb())
            {
                try
                {
                    lista = db.PermisosDb.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static Entidades.Permisos BuscarB(int id)
        {

            Entidades.Permisos nuevo;
            using (var db = new UserDb())
            {
                try
                {
                    nuevo = db.PermisosDb.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static Permisos Buscar(Expression<Func<Permisos, bool>> criterio)
        {
            Permisos Result = null;
            using (var repoitorio = new Repositorio<Permisos>())
            {
                Result = repoitorio.Buscar(criterio);
            }

            return Result;
        }
    }
}
