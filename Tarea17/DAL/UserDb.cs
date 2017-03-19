using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL
{
public    class UserDb : DbContext
    {
        public UserDb() :base ("ConStr")
        {

        }

        public DbSet<Usuarios> UsuarioDb { get; set; }
        public DbSet<Permisos> PermisosDb { get; set; }
        public DbSet<PermisosDetalles> PermisosDetallesDb { get; set; }
    }
}
