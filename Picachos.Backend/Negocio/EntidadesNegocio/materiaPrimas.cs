//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Picachos.Backend.Negocio.EntidadesNegocio
{
    using System;
    using System.Collections.Generic;
    
    public partial class materiaPrimas
    {
        public materiaPrimas()
        {
            this.entradasalidaMateriaprimas = new HashSet<entradasalidaMateriaprimas>();
            this.productoTerminadoes = new HashSet<productoTerminadoes>();
        }
    
        public int materiaPrimaID { get; set; }
        public Nullable<int> productoID { get; set; }
        public string nombreMateria { get; set; }
        public Nullable<int> existencia { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<entradasalidaMateriaprimas> entradasalidaMateriaprimas { get; set; }
        public virtual ICollection<productoTerminadoes> productoTerminadoes { get; set; }
    }
}
