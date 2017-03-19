using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
 public   class Permisos
    {
        [Key]
        public int PermisosId { get; set; }
        public string  Descripcon { get; set; }
        //  public int PermisoId { get; set; }

        public Permisos()
        {

        }

    }
}
