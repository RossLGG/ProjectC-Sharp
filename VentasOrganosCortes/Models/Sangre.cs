//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentasOrganosCortes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sangre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sangre()
        {
            this.Detalle = new HashSet<Detalle>();
        }
    
        public int sang_id { get; set; }
        public string sang_tipo { get; set; }
        public int sang_cant { get; set; }
        public bool sang_infec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}
