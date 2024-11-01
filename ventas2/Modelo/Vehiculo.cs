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
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Facturas = new HashSet<Factura>();
        }
    
        public int IdVehiculo { get; set; }
        public string NombreVehiculo { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public Nullable<int> Año { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> Motor { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Transmision { get; set; }
        public byte[] Imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual MarcaVehiculo MarcaVehiculo { get; set; }
    }
}
