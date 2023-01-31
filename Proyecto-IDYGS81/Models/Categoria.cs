using System.ComponentModel.DataAnnotations;
using System;

namespace Proyecto_IDYGS81.Models
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }
        public string NombreCat { get; set; }
        public string Descripcion { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? RowVersion { get; set; }
    }
}
