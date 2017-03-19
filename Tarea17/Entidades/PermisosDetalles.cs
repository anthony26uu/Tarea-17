using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
  public  class PermisosDetalles
    {
        [Key]
        public int PermisosDetallesId { get; set; }
        public int Id { get; set; }
        public int PermisosId { get; set; }

        public PermisosDetalles()
        {

        }

        public PermisosDetalles(int permisosDetallesId,int id, int permisosId)
        {
            this.PermisosDetallesId = permisosDetallesId;
            this.Id = id;
            this.PermisosId = permisosId;
        }
                
    }
}
