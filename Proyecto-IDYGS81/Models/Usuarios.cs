﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Proyecto_IDYGS81.Models
{
    public class Usuarios
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        [ForeignKey("Roles")]
        public int FKRol { get; set; }
        public Rol Roles { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? RowVersion { get; set; }
    }
}
