//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Picachos.Backend.Negocio.EntidadesNegocio
{
    using System;
    using System.Collections.Generic;
    
    public partial class prestamoEquipo
    {
        public prestamoEquipo()
        {
            this.equipo = new HashSet<equipo>();
        }
    
        public int prestamoEquipoID { get; set; }
        public Nullable<int> clienteID { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual ICollection<equipo> equipo { get; set; }
    }
}
