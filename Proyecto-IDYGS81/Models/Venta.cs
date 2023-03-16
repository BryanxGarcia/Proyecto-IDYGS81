using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_IDYGS81.Models
{
    public class Venta
    {
        [Key]
        public int PkVenta { get; set; }

        [ForeignKey("Usuario")]
        public int FKUsuario { get; set; }
        public Usuarios Usuario { get; set; }

  
        [ForeignKey("DetalleVenta")]
        public int FKDetalleVenta { get; set; }
        public DetalleVenta DetalleVenta { get; set; }

        public DateTime FechaVenta { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? RowVersion { get; set; }

    }
}
