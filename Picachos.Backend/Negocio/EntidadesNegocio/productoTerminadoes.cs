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
    
    public partial class productoTerminadoES
    {
        public int PDEntSalID { get; set; }
        public Nullable<int> productoID { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fechaES { get; set; }
        public Nullable<int> cantidadES { get; set; }
    
        public virtual productoTerminado productoTerminado { get; set; }
    }
}