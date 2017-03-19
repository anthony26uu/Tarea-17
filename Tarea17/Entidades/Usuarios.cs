﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
  public  class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PassUsuario { get; set; }
        public string Tipo { get; set; }
        public Usuarios(int id, string nombreUsuario, string passUsuario)
        {
           this.PassUsuario = passUsuario;
           this.Id = id;
           this.NombreUsuario = nombreUsuario;
          
        }

        public Usuarios()
        {

        }
    }
}
