using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_IDYGS81.Models
{
    public class DetalleVenta
    {
        [Key]
        public int PkDetalle { get; set; }


        [ForeignKey("Ventas")]
        public int FKVenta { get; set; }
        public Venta Ventas { get; set; }


        [ForeignKey("Producto")]
        public int FKProducto { get; set; }
        public Productos Producto { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? RowVersion { get; set; }

    }
}
