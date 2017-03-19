﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        UserDb Contex = null;

        public Repositorio()
        {
            Contex = new UserDb();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.Where(criterioBusqueda).ToList();
            }
            catch (Exception)
            {
                throw;
                return new List<TEntity>();
            }
        }

        //propiedad que nos permite acceder al entityset actual con el que se instancion el repositorio
        private DbSet<TEntity> EntitySet
        {
            get
            {
                //devolver del contexto un entityset, esta es la entidad que necesitamos para realizar las operaciones
                return Contex.Set<TEntity>();
            }
        }

        public TEntity Guardar(TEntity laEntidad)
        {
            TEntity Result = null;

            try
            {
                EntitySet.Add(laEntidad);
                Contex.SaveChanges();
                Result = laEntidad;
            }
            catch (Exception)
            {
                throw;
            }

            return Result;
        }

        public bool Modificar(TEntity laEntidad)
        {
            bool Result = false;

            try
            {
                //para que el contexto lo considere como si estubiera recien agregado
                EntitySet.Attach(laEntidad);

                //Para que entityframework sepa que la va a actualizar.
                Contex.Entry<TEntity>(laEntidad).State = EntityState.Modified;

                Result = Contex.SaveChanges() > 0;
            }
            catch { }

            return Result;
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            TEntity Result = null;

            try
            {
                Result = EntitySet.FirstOrDefault(criterioBusqueda);
            }
            catch { }

            return Result;
        }

        public bool Eliminar(TEntity laEntidad)
        {
            bool Result = false;

            try
            {
                //para que el contexto lo considere como si estubiera recien agregado
                EntitySet.Attach(laEntidad);
                EntitySet.Remove(laEntidad);
                Result = Contex.SaveChanges() > 0;
            }
            catch { }

            return Result;
        }

        public List<TEntity> Lista(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criterioBusqueda).ToList();
            }
            catch { }

            return Result;
        }


        public List<TEntity> ListaTodo()
        {
            using (var Conec = new DAL.UserDb())
            {
                try
                {
                    return EntitySet.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }

        public void Dispose()
        {
            if (Contex != null)
                Contex.Dispose();
        }
    }
}
