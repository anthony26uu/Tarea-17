﻿using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class UserBLL
    {
        public static bool Guardar(Usuarios nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Usuarios>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }
        public static Entidades.Usuarios GuardarBool(Entidades.Usuarios n)
        {
            bool retono = false;
            using (var db = new UserDb())
            {
                try
                {


                    db.UsuarioDb.Add(n);
                    db.SaveChanges();
                    return n;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }



        public static bool Eliminar(Usuarios IdUser)
        {
            bool resultado = false;
            using (var db = new Repositorio<Usuarios>())
            {
                resultado = db.Eliminar(IdUser);

            }
            return resultado;
        }

        public static bool Mofidicar(Usuarios existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Usuarios>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }

        public static Entidades.Usuarios BuscarB(int id)
        {

            Entidades.Usuarios nuevo;
            using (var db = new UserDb())
            {
                try
                {
                    nuevo = db.UsuarioDb.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }


        public static Usuarios Buscar(Expression<Func<Usuarios, bool>> criterio)
        {
            Usuarios Result = null;
            using (var repoitorio = new Repositorio<Usuarios>())
            {
                Result = repoitorio.Buscar(criterio);
            }

            return Result;
        }

    }
}
