//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ventas2.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administrador
    {
        public int IdAdmin { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public Nullable<int> IdPuestoTrabajo { get; set; }
    
        public virtual PuestoTrabajo PuestoTrabajo { get; set; }
    }
}