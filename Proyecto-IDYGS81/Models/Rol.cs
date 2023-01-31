using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_IDYGS81.Models
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? RowVersion { get; set; }



    }
}
